using System;
using System.Collections.Generic;
using System.Linq;
using Rd.Analytics;
using Rd.CodeGeneration;
using Rd.Utils;

namespace Rd.CodeGenerator
{
    public class CodeGenerator
    {
        private readonly IPreProcessor[] _preProcessors;
        private readonly IDataProvider[] _dataProviders;
        private readonly ICodeGenerator[] _codeGenerators;
        private readonly IPostProcessor[] _postProcessors;
        private readonly bool _trackHooks;
        private readonly Dictionary<string, object> _objectCache;
        private bool _cancel;

        public static string defaultPropertiesPath
        {
            get { return "Jenny.properties"; }
        }

        public event GeneratorProgress OnProgress;

        public CodeGenerator(
            IPreProcessor[] preProcessors,
            IDataProvider[] dataProviders,
            ICodeGenerator[] codeGenerators,
            IPostProcessor[] postProcessors,
            bool trackHooks = true)
        {
            this._preProcessors = ((IEnumerable<IPreProcessor>) preProcessors).OrderBy<IPreProcessor, int>((Func<IPreProcessor, int>) (i => i.priority)).ToArray<IPreProcessor>();
            this._dataProviders = ((IEnumerable<IDataProvider>) dataProviders).OrderBy<IDataProvider, int>((Func<IDataProvider, int>) (i => i.priority)).ToArray<IDataProvider>();
            this._codeGenerators = ((IEnumerable<ICodeGenerator>) codeGenerators).OrderBy<ICodeGenerator, int>((Func<ICodeGenerator, int>) (i => i.priority))
                .ToArray<ICodeGenerator>();
            this._postProcessors = ((IEnumerable<IPostProcessor>) postProcessors).OrderBy<IPostProcessor, int>((Func<IPostProcessor, int>) (i => i.priority))
                .ToArray<IPostProcessor>();
            this._trackHooks = trackHooks;
            this._objectCache = new Dictionary<string, object>();
        }

        public CodeGenFile[] DryRun()
        {
            return this.generate("[Dry Run] ",
                ((IEnumerable<IPreProcessor>) this._preProcessors).Where<IPreProcessor>((Func<IPreProcessor, bool>) (i => i.runInDryMode)).ToArray<IPreProcessor>(),
                ((IEnumerable<IDataProvider>) this._dataProviders).Where<IDataProvider>((Func<IDataProvider, bool>) (i => i.runInDryMode)).ToArray<IDataProvider>(),
                ((IEnumerable<ICodeGenerator>) this._codeGenerators).Where<ICodeGenerator>((Func<ICodeGenerator, bool>) (i => i.runInDryMode)).ToArray<ICodeGenerator>(),
                ((IEnumerable<IPostProcessor>) this._postProcessors).Where<IPostProcessor>((Func<IPostProcessor, bool>) (i => i.runInDryMode)).ToArray<IPostProcessor>());
        }

        public CodeGenFile[] Generate()
        {
            CodeGenFile[] files = this.generate(string.Empty, this._preProcessors, this._dataProviders, this._codeGenerators, this._postProcessors);
            if (this._trackHooks)
                this.trackHooks(files);
            return files;
        }

        private void trackHooks(CodeGenFile[] files)
        {
            foreach (CodeGeneratorTrackingHook generatorTrackingHook in AppDomain.CurrentDomain.GetInstancesOf<ITrackingHook>().OfType<CodeGeneratorTrackingHook>())
                generatorTrackingHook.Track(this._preProcessors, this._dataProviders, this._codeGenerators, this._postProcessors, files);
        }

        private CodeGenFile[] generate(
            string messagePrefix,
            IPreProcessor[] preProcessors,
            IDataProvider[] dataProviders,
            ICodeGenerator[] codeGenerators,
            IPostProcessor[] postProcessors)
        {
            this._cancel = false;
            this._objectCache.Clear();
            foreach (ICachable cachable in ((IEnumerable<ICodeGenerationPlugin>) preProcessors).Concat<ICodeGenerationPlugin>((IEnumerable<ICodeGenerationPlugin>) dataProviders)
                .Concat<ICodeGenerationPlugin>((IEnumerable<ICodeGenerationPlugin>) codeGenerators)
                .Concat<ICodeGenerationPlugin>((IEnumerable<ICodeGenerationPlugin>) postProcessors).OfType<ICachable>())
                cachable.objectCache = this._objectCache;
            int num1 = preProcessors.Length + dataProviders.Length + codeGenerators.Length + postProcessors.Length;
            int num2 = 0;
            foreach (IPreProcessor preProcessor in preProcessors)
            {
                if (this._cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (this.OnProgress != null)
                    this.OnProgress(messagePrefix + "Pre Processing", preProcessor.name, (float) num2 / (float) num1);
                preProcessor.PreProcess();
            }

            List<CodeGeneratorData> codeGeneratorDataList = new List<CodeGeneratorData>();
            foreach (IDataProvider dataProvider in dataProviders)
            {
                if (this._cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (this.OnProgress != null)
                    this.OnProgress(messagePrefix + "Creating model", dataProvider.name, (float) num2 / (float) num1);
                codeGeneratorDataList.AddRange((IEnumerable<CodeGeneratorData>) dataProvider.GetData());
            }

            List<CodeGenFile> codeGenFileList = new List<CodeGenFile>();
            CodeGeneratorData[] array = codeGeneratorDataList.ToArray();
            foreach (ICodeGenerator codeGenerator in codeGenerators)
            {
                if (this._cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (this.OnProgress != null)
                    this.OnProgress(messagePrefix + "Creating files", codeGenerator.name, (float) num2 / (float) num1);
                codeGenFileList.AddRange((IEnumerable<CodeGenFile>) codeGenerator.Generate(array));
            }

            CodeGenFile[] files = codeGenFileList.ToArray();
            foreach (IPostProcessor postProcessor in postProcessors)
            {
                if (this._cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (this.OnProgress != null)
                    this.OnProgress(messagePrefix + "Post Processing", postProcessor.name, (float) num2 / (float) num1);
                files = postProcessor.PostProcess(files);
            }

            return files;
        }

        public void Cancel()
        {
            this._cancel = true;
        }
    }
}