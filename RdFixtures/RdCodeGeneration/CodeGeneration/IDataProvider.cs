namespace Rd.CodeGeneration
{
    public interface IDataProvider : ICodeGenerationPlugin
    {
        CodeGeneratorData[] GetData();
    }
}