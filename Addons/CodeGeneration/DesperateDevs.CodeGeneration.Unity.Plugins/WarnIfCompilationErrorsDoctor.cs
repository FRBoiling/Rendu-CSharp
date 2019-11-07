using DesperateDevs.CodeGeneration.CodeGenerator;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesperateDevs.CodeGeneration.Unity.Plugins
{
    public class WarnIfCompilationErrorsDoctor : IDoctor, ICodeGenerationPlugin, IConfigurable
    {
        private readonly CodeGeneratorConfig _codeGeneratorConfig = new CodeGeneratorConfig();

        public string name
        {
            get
            {
                return "Warn If Compilation Errors";
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
                string fullName = typeof(WarnIfCompilationErrorsPreProcessor).FullName;
                if (((IEnumerable<string>)this._codeGeneratorConfig.preProcessors).Contains<string>(fullName))
                    return new Diagnosis(fullName + " uses Unity APIs but is used outside of Unity!", "Remove " + fullName + " from CodeGenerator.PreProcessors", DiagnosisSeverity.Error);
            }
            return Diagnosis.Healthy;
        }

        public bool Fix()
        {
            List<string> list = ((IEnumerable<string>)this._codeGeneratorConfig.preProcessors).ToList<string>();
            if (!list.Remove(typeof(WarnIfCompilationErrorsPreProcessor).FullName))
                return false;
            this._codeGeneratorConfig.preProcessors = list.ToArray();
            return true;
        }
    }
}