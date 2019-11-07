using DesperateDevs.CodeGeneration.CodeGenerator;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesperateDevs.CodeGeneration.Unity.Plugins
{
    public class DebugLogDoctor : IDoctor, ICodeGenerationPlugin, IConfigurable
    {
        private readonly CodeGeneratorConfig _codeGeneratorConfig = new CodeGeneratorConfig();

        public string name
        {
            get
            {
                return "Debug.Log";
            }
        }

        public int priority
        {
            get
            {
                return 0;
            }
        }

        public bool runInDryMode
        {
            get
            {
                return true;
            }
        }

        public Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>();
            }
        }

        public void Configure(Preferences preferences)
        {
            this._codeGeneratorConfig.Configure(preferences);
        }

        public Diagnosis Diagnose()
        {
            if (((IEnumerable<Type>)AppDomain.CurrentDomain.GetAllTypes()).Any<Type>((Func<Type, bool>)(type => type.FullName == "DesperateDevs.CodeGeneration.CodeGenerator.CLI.Program")))
            {
                string fullName = typeof(DebugLogPostProcessor).FullName;
                if (((IEnumerable<string>)this._codeGeneratorConfig.postProcessors).Contains<string>(fullName))
                    return new Diagnosis(fullName + " uses Unity APIs but is used outside of Unity!", "Remove " + fullName + " from CodeGenerator.PostProcessors", DiagnosisSeverity.Error);
            }
            return Diagnosis.Healthy;
        }

        public bool Fix()
        {
            List<string> list = ((IEnumerable<string>)this._codeGeneratorConfig.postProcessors).ToList<string>();
            if (!list.Remove(typeof(DebugLogPostProcessor).FullName))
                return false;
            this._codeGeneratorConfig.postProcessors = list.ToArray();
            return true;
        }
    }
}