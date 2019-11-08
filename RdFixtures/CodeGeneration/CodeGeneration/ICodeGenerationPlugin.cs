namespace Rd.CodeGeneration
{
    public interface ICodeGenerationPlugin
    {
        string name { get; }

        int priority { get; }

        bool runInDryMode { get; }
    }
}