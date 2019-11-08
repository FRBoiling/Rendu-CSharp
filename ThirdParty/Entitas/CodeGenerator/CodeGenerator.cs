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
        private readonly ICodeGenerator[] _codeGenerators;
        private readonly IDataProvider[] _dataProviders;
        private readonly Dictionary<string, object> _objectCache;
        private readonly IPostProcessor[] _postProcessors;
        private readonly IPreProcessor[] _preProcessors;
        private readonly bool _trackHooks;
        private bool _cancel;

        public CodeGenerator(
            IPreProcessor[] preProcessors,
            IDataProvider[] dataProviders,
            ICodeGenerator[] codeGenerators,
            IPostProcessor[] postProcessors,
            bool trackHooks = true)
        {
            _preProcessors = preProcessors.OrderBy(i => i.priority).ToArray();
            _dataProviders = dataProviders.OrderBy(i => i.priority).ToArray();
            _codeGenerators = codeGenerators.OrderBy(i => i.priority)
                .ToArray();
            _postProcessors = postProcessors.OrderBy(i => i.priority)
                .ToArray();
            _trackHooks = trackHooks;
            _objectCache = new Dictionary<string, object>();
        }

        public static string defaultPropertiesPath => "Jenny.properties";

        public event GeneratorProgress OnProgress;

        public CodeGenFile[] DryRun()
        {
            return generate("[Dry Run] ",
                _preProcessors.Where(i => i.runInDryMode).ToArray(),
                _dataProviders.Where(i => i.runInDryMode).ToArray(),
                _codeGenerators.Where(i => i.runInDryMode).ToArray(),
                _postProcessors.Where(i => i.runInDryMode).ToArray());
        }

        public CodeGenFile[] Generate()
        {
            var files = generate(string.Empty, _preProcessors, _dataProviders, _codeGenerators, _postProcessors);
            if (_trackHooks)
                trackHooks(files);
            return files;
        }

        private void trackHooks(CodeGenFile[] files)
        {
            foreach (var generatorTrackingHook in AppDomain.CurrentDomain.GetInstancesOf<ITrackingHook>().OfType<CodeGeneratorTrackingHook>())
                generatorTrackingHook.Track(_preProcessors, _dataProviders, _codeGenerators, _postProcessors, files);
        }

        private CodeGenFile[] generate(
            string messagePrefix,
            IPreProcessor[] preProcessors,
            IDataProvider[] dataProviders,
            ICodeGenerator[] codeGenerators,
            IPostProcessor[] postProcessors)
        {
            _cancel = false;
            _objectCache.Clear();
            foreach (var cachable in preProcessors.Concat((IEnumerable<ICodeGenerationPlugin>) dataProviders)
                .Concat(codeGenerators)
                .Concat(postProcessors).OfType<ICachable>())
                cachable.objectCache = _objectCache;
            var num1 = preProcessors.Length + dataProviders.Length + codeGenerators.Length + postProcessors.Length;
            var num2 = 0;
            foreach (var preProcessor in preProcessors)
            {
                if (_cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (OnProgress != null)
                    OnProgress(messagePrefix + "Pre Processing", preProcessor.name, num2 / (float) num1);
                preProcessor.PreProcess();
            }

            var codeGeneratorDataList = new List<CodeGeneratorData>();
            foreach (var dataProvider in dataProviders)
            {
                if (_cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (OnProgress != null)
                    OnProgress(messagePrefix + "Creating model", dataProvider.name, num2 / (float) num1);
                codeGeneratorDataList.AddRange(dataProvider.GetData());
            }

            var codeGenFileList = new List<CodeGenFile>();
            var array = codeGeneratorDataList.ToArray();
            foreach (var codeGenerator in codeGenerators)
            {
                if (_cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (OnProgress != null)
                    OnProgress(messagePrefix + "Creating files", codeGenerator.name, num2 / (float) num1);
                codeGenFileList.AddRange(codeGenerator.Generate(array));
            }

            var files = codeGenFileList.ToArray();
            foreach (var postProcessor in postProcessors)
            {
                if (_cancel)
                    return new CodeGenFile[0];
                ++num2;
                if (OnProgress != null)
                    OnProgress(messagePrefix + "Post Processing", postProcessor.name, num2 / (float) num1);
                files = postProcessor.PostProcess(files);
            }

            return files;
        }

        public void Cancel()
        {
            _cancel = true;
        }
    }
}