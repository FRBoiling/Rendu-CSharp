using Rd.Analytics;
using Rd.CodeGeneration;

namespace Rd.CodeGenerator
{
    public abstract class CodeGeneratorTrackingHook : AbstractTrackingHook
    {
        protected ICodeGenerator[] _codeGenerators;
        protected IDataProvider[] _dataProviders;
        protected CodeGenFile[] _files;
        protected IPostProcessor[] _postProcessors;
        protected IPreProcessor[] _preProcessors;

        public void Track(
            IPreProcessor[] preProcessors,
            IDataProvider[] dataProviders,
            ICodeGenerator[] codeGenerators,
            IPostProcessor[] postProcessors,
            CodeGenFile[] files)
        {
            _preProcessors = preProcessors;
            _dataProviders = dataProviders;
            _codeGenerators = codeGenerators;
            _postProcessors = postProcessors;
            _files = files;
            Track();
        }
    }
}