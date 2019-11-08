namespace Rd.CodeGeneration
{
    public interface ICodeGenerator : ICodeGenerationPlugin
    {
        CodeGenFile[] Generate(CodeGeneratorData[] data);
    }
}