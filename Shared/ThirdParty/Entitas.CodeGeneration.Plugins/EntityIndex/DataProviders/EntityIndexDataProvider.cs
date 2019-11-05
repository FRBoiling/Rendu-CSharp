using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesperateDevs.CodeGeneration;
using DesperateDevs.CodeGeneration.CodeGenerator;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Attributes;

namespace Entitas.CodeGeneration.Plugins
{
    public class EntityIndexDataProvider : IDataProvider, IConfigurable, ICachable, IDoctor
    {
        private readonly AssembliesConfig _assembliesConfig = new AssembliesConfig();

        private readonly CodeGeneratorConfig _codeGeneratorConfig = new CodeGeneratorConfig();
        private readonly ContextsComponentDataProvider _contextsComponentDataProvider = new ContextsComponentDataProvider();
        private readonly IgnoreNamespacesConfig _ignoreNamespacesConfig = new IgnoreNamespacesConfig();

        private readonly Type[] _types;

        public EntityIndexDataProvider() : this(null)
        {
        }

        public EntityIndexDataProvider(Type[] types)
        {
            _types = types;
        }

        public Dictionary<string, object> objectCache { get; set; }

        public Dictionary<string, string> defaultProperties =>
            _assembliesConfig.defaultProperties
                .Merge(_ignoreNamespacesConfig.defaultProperties,
                    _contextsComponentDataProvider.defaultProperties);

        public void Configure(Preferences preferences)
        {
            _codeGeneratorConfig.Configure(preferences);
            _assembliesConfig.Configure(preferences);
            _ignoreNamespacesConfig.Configure(preferences);
            _contextsComponentDataProvider.Configure(preferences);
        }

        public string name => "Entity Index";
        public int priority => 0;
        public bool runInDryMode => true;

        public CodeGeneratorData[] GetData()
        {
            var types = _types ?? PluginUtil
                            .GetCachedAssemblyResolver(objectCache, _assembliesConfig.assemblies, _codeGeneratorConfig.searchPaths)
                            .GetTypes();

            var entityIndexData = types
                .Where(type => !type.IsAbstract)
                .Where(type => type.ImplementsInterface<IComponent>())
                .ToDictionary(
                    type => type,
                    type => type.GetPublicMemberInfos())
                .Where(kv => kv.Value.Any(info => info.attributes.Any(attr => attr.attribute is AbstractEntityIndexAttribute)))
                .SelectMany(kv => createEntityIndexData(kv.Key, kv.Value));

            var customEntityIndexData = types
                .Where(type => !type.IsAbstract)
                .Where(type => Attribute.IsDefined(type, typeof(CustomEntityIndexAttribute)))
                .Select(createCustomEntityIndexData);

            return entityIndexData
                .Concat(customEntityIndexData)
                .ToArray();
        }

        public Diagnosis Diagnose()
        {
            var isStandalone = AppDomain.CurrentDomain
                .GetAllTypes()
                .Any(type => type.FullName == "DesperateDevs.CodeGeneration.CodeGenerator.CLI.Program");

            if (isStandalone)
            {
                var typeName = typeof(EntityIndexDataProvider).FullName;
                if (_codeGeneratorConfig.dataProviders.Contains(typeName))
                    return new Diagnosis(
                        typeName + " loads and reflects " + string.Join(", ", _assembliesConfig.assemblies) + " and therefore doesn't support server mode!",
                        "Don't use the code generator in server mode with " + typeName,
                        DiagnosisSeverity.Hint
                    );
            }

            return Diagnosis.Healthy;
        }

        public bool Fix()
        {
            return false;
        }

        private EntityIndexData[] createEntityIndexData(Type type, List<PublicMemberInfo> infos)
        {
            var hasMultiple = infos.Count(i => i.attributes.Count(attr => attr.attribute is AbstractEntityIndexAttribute) == 1) > 1;
            return infos
                .Where(i => i.attributes.Count(attr => attr.attribute is AbstractEntityIndexAttribute) == 1)
                .Select(info =>
                {
                    var data = new EntityIndexData();
                    var attribute = (AbstractEntityIndexAttribute) info.attributes.Single(attr => attr.attribute is AbstractEntityIndexAttribute).attribute;

                    data.SetEntityIndexType(getEntityIndexType(attribute));
                    data.IsCustom(false);
                    data.SetEntityIndexName(type.ToCompilableString().ToComponentName(_ignoreNamespacesConfig.ignoreNamespaces));
                    data.SetKeyType(info.type.ToCompilableString());
                    data.SetComponentType(type.ToCompilableString());
                    data.SetMemberName(info.name);
                    data.SetHasMultiple(hasMultiple);
                    data.SetContextNames(_contextsComponentDataProvider.GetContextNamesOrDefault(type));

                    return data;
                }).ToArray();
        }

        private EntityIndexData createCustomEntityIndexData(Type type)
        {
            var data = new EntityIndexData();

            var attribute = (CustomEntityIndexAttribute) type.GetCustomAttributes(typeof(CustomEntityIndexAttribute), false)[0];

            data.SetEntityIndexType(type.ToCompilableString());
            data.IsCustom(true);
            data.SetEntityIndexName(type.ToCompilableString().RemoveDots());
            data.SetHasMultiple(false);
            data.SetContextNames(new[] {attribute.contextType.ToCompilableString().ShortTypeName().RemoveContextSuffix()});

            var getMethods = type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => Attribute.IsDefined(method, typeof(EntityIndexGetMethodAttribute)))
                .Select(method => new MethodData(
                    method.ReturnType.ToCompilableString(),
                    method.Name,
                    method.GetParameters()
                        .Select(p => new MemberData(p.ParameterType.ToCompilableString(), p.Name))
                        .ToArray()
                )).ToArray();

            data.SetCustomMethods(getMethods);

            return data;
        }

        private string getEntityIndexType(AbstractEntityIndexAttribute attribute)
        {
            switch (attribute.entityIndexType)
            {
                case EntityIndexType.EntityIndex:
                    return "Entitas.EntityIndex";
                case EntityIndexType.PrimaryEntityIndex:
                    return "Entitas.PrimaryEntityIndex";
                default:
                    throw new Exception("Unhandled EntityIndexType: " + attribute.entityIndexType);
            }
        }
    }
}