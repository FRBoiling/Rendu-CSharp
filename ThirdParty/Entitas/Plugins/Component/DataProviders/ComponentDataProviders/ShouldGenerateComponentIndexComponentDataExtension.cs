namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public static class ShouldGenerateComponentIndexComponentDataExtension
    {
        public const string COMPONENT_GENERATE_INDEX = "Component.Generate.Index";

        public static bool ShouldGenerateIndex(this ComponentData data)
        {
            return (bool) data[COMPONENT_GENERATE_INDEX];
        }

        public static void ShouldGenerateIndex(this ComponentData data, bool generate)
        {
            data[COMPONENT_GENERATE_INDEX] = generate;
        }
    }
}