namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public static class ShouldGenerateComponentComponentDataExtension
    {
        public const string COMPONENT_GENERATE_COMPONENT = "Component.Generate.Object";
        public const string COMPONENT_OBJECT_TYPE = "Component.ObjectTypeName";

        public static bool ShouldGenerateComponent(this ComponentData data)
        {
            return (bool) data[COMPONENT_GENERATE_COMPONENT];
        }

        public static void ShouldGenerateComponent(this ComponentData data, bool generate)
        {
            data[COMPONENT_GENERATE_COMPONENT] = generate;
        }

        public static string GetObjectTypeName(this ComponentData data)
        {
            return (string) data[COMPONENT_OBJECT_TYPE];
        }

        public static void SetObjectTypeName(this ComponentData data, string type)
        {
            data[COMPONENT_OBJECT_TYPE] = type;
        }
    }
}