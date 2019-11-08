namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public static class ShouldGenerateMethodsComponentDataExtension
    {
        public const string COMPONENT_GENERATE_METHODS = "Component.Generate.Methods";

        public static bool ShouldGenerateMethods(this ComponentData data)
        {
            return (bool) data[COMPONENT_GENERATE_METHODS];
        }

        public static void ShouldGenerateMethods(this ComponentData data, bool generate)
        {
            data[COMPONENT_GENERATE_METHODS] = generate;
        }
    }
}