namespace Rd.CodeGeneration
{
    public interface IPostProcessor : ICodeGenerationPlugin
    {
        CodeGenFile[] PostProcess(CodeGenFile[] files);
    }
}