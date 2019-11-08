using System.Collections.Generic;
using Entitas.CodeGeneration.Plugins.Component;
using Entitas.CodeGeneration.Plugins.Configs;
using Entitas.CodeGeneration.Plugins.EntityIndex.DataProviders;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.EntityIndex.CodeGenerators
{
    public class EntityIndexGenerator : ICodeGenerator, IConfigurable
    {
        private const string CLASS_TEMPLATE =
            @"public partial class Contexts {

${indexConstants}

    [Entitas.CodeGeneration.Entitas.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
${addIndices}
    }
}

public static class ContextsExtensions {

${getIndices}
}";

        private const string INDEX_CONSTANTS_TEMPLATE = @"    public const string ${IndexName} = ""${IndexName}"";";

        private const string ADD_INDEX_TEMPLATE =
            @"        ${contextName}.AddEntityIndex(new ${IndexType}<${ContextName}Entity, ${KeyType}>(
            ${IndexName},
            ${contextName}.GetGroup(${ContextName}Matcher.${Matcher}),
            (e, c) => ((${ComponentType})c).${MemberName}));";

        private const string ADD_CUSTOM_INDEX_TEMPLATE =
            @"        ${contextName}.AddEntityIndex(new ${IndexType}(${contextName}));";

        private const string GET_INDEX_TEMPLATE =
            @"    public static System.Collections.Generic.HashSet<${ContextName}Entity> GetEntitiesWith${IndexName}(this ${ContextName}Context context, ${KeyType} ${MemberName}) {
        return ((${IndexType}<${ContextName}Entity, ${KeyType}>)context.GetEntityIndex(Contexts.${IndexName})).GetEntities(${MemberName});
    }";

        private const string GET_PRIMARY_INDEX_TEMPLATE =
            @"    public static ${ContextName}Entity GetEntityWith${IndexName}(this ${ContextName}Context context, ${KeyType} ${MemberName}) {
        return ((${IndexType}<${ContextName}Entity, ${KeyType}>)context.GetEntityIndex(Contexts.${IndexName})).GetEntity(${MemberName});
    }";

        private const string CUSTOM_METHOD_TEMPLATE =
            @"    public static ${ReturnType} ${MethodName}(this ${ContextName}Context context, ${methodArgs}) {
        return ((${IndexType})(context.GetEntityIndex(Contexts.${IndexName}))).${MethodName}(${args});
    }
";

        private readonly IgnoreNamespacesConfig _ignoreNamespacesConfig = new IgnoreNamespacesConfig();

        public string name => "Entity Index";
        public int priority => 0;
        public bool runInDryMode => true;

        public CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            var entityIndexData = data
                .OfType<EntityIndexData>()
                .OrderBy(d => d.GetEntityIndexName())
                .ToArray();

            return entityIndexData.Length == 0
                ? new CodeGenFile[0]
                : generateEntityIndices(entityIndexData);
        }

        public Dictionary<string, string> defaultProperties => _ignoreNamespacesConfig.defaultProperties;

        public void Configure(Preferences preferences)
        {
            _ignoreNamespacesConfig.Configure(preferences);
        }

        private CodeGenFile[] generateEntityIndices(EntityIndexData[] data)
        {
            var indexConstants = string.Join("\n", data
                .Select(d => INDEX_CONSTANTS_TEMPLATE
                    .Replace("${IndexName}", d.GetHasMultiple()
                        ? d.GetEntityIndexName() + d.GetMemberName().UppercaseFirst()
                        : d.GetEntityIndexName()))
                .ToArray());

            var addIndices = string.Join("\n\n", data
                .Select(generateAddMethods)
                .ToArray());

            var getIndices = string.Join("\n\n", data
                .Select(generateGetMethods)
                .ToArray());

            var fileContent = CLASS_TEMPLATE
                .Replace("${indexConstants}", indexConstants)
                .Replace("${addIndices}", addIndices)
                .Replace("${getIndices}", getIndices);

            return new[]
            {
                new CodeGenFile(
                    "Contexts.cs",
                    fileContent,
                    GetType().FullName
                )
            };
        }

        private string generateAddMethods(EntityIndexData data)
        {
            return string.Join("\n", data.GetContextNames()
                .Aggregate(new List<string>(), (addMethods, contextName) =>
                {
                    addMethods.Add(generateAddMethod(data, contextName));
                    return addMethods;
                }).ToArray());
        }

        private string generateAddMethod(EntityIndexData data, string contextName)
        {
            return data.IsCustom()
                ? generateCustomMethods(data)
                : generateMethods(data, contextName);
        }

        private string generateCustomMethods(EntityIndexData data)
        {
            return ADD_CUSTOM_INDEX_TEMPLATE
                .Replace("${contextName}", data.GetContextNames()[0].LowercaseFirst())
                .Replace("${IndexType}", data.GetEntityIndexType());
        }

        private string generateMethods(EntityIndexData data, string contextName)
        {
            return ADD_INDEX_TEMPLATE
                .Replace("${contextName}", contextName.LowercaseFirst())
                .Replace("${ContextName}", contextName)
                .Replace("${IndexName}", data.GetHasMultiple()
                    ? data.GetEntityIndexName() + data.GetMemberName().UppercaseFirst()
                    : data.GetEntityIndexName())
                .Replace("${Matcher}", data.GetEntityIndexName())
                .Replace("${IndexType}", data.GetEntityIndexType())
                .Replace("${KeyType}", data.GetKeyType())
                .Replace("${ComponentType}", data.GetComponentType())
                .Replace("${MemberName}", data.GetMemberName())
                .Replace("${componentName}", data.GetComponentType()
                    .ToComponentName(_ignoreNamespacesConfig.ignoreNamespaces)
                    .LowercaseFirst()
                    .AddPrefixIfIsKeyword());
        }

        private string generateGetMethods(EntityIndexData data)
        {
            return string.Join("\n\n", data.GetContextNames()
                .Aggregate(new List<string>(), (getMethods, contextName) =>
                {
                    getMethods.Add(generateGetMethod(data, contextName));
                    return getMethods;
                }).ToArray());
        }

        private string generateGetMethod(EntityIndexData data, string contextName)
        {
            var template = "";
            if (data.GetEntityIndexType() == "Entitas.EntityIndex")
                template = GET_INDEX_TEMPLATE;
            else if (data.GetEntityIndexType() == "Entitas.PrimaryEntityIndex")
                template = GET_PRIMARY_INDEX_TEMPLATE;
            else
                return getCustomMethods(data);

            return template
                .Replace("${ContextName}", contextName)
                .Replace("${IndexName}", data.GetHasMultiple()
                    ? data.GetEntityIndexName() + data.GetMemberName().UppercaseFirst()
                    : data.GetEntityIndexName())
                .Replace("${IndexType}", data.GetEntityIndexType())
                .Replace("${KeyType}", data.GetKeyType())
                .Replace("${MemberName}", data.GetMemberName());
        }

        private string getCustomMethods(EntityIndexData data)
        {
            return string.Join("\n", data.GetCustomMethods()
                .Select(m => CUSTOM_METHOD_TEMPLATE
                    .Replace("${ReturnType}", m.returnType)
                    .Replace("${MethodName}", m.methodName)
                    .Replace("${ContextName}", data.GetContextNames()[0])
                    .Replace("${methodArgs}", string.Join(", ", m.parameters.Select(p => p.type + " " + p.name).ToArray()))
                    .Replace("${IndexType}", data.GetEntityIndexType())
                    .Replace("${IndexName}", data.GetHasMultiple()
                        ? data.GetEntityIndexName() + data.GetMemberName().UppercaseFirst()
                        : data.GetEntityIndexName())
                    .Replace("${args}", string.Join(", ", m.parameters.Select(p => p.name).ToArray()))).ToArray());
        }
    }
}