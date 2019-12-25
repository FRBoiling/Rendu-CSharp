namespace Rd.Plugins
{
    public static class ComponentTypeComponentDataExtension
    {
        public const string COMPONENT_TYPE = "Component.TypeName";

        public static string GetTypeName(this ComponentData data)
        {
            return (string) data[COMPONENT_TYPE];
        }

        public static void SetTypeName(this ComponentData data, string fullTypeName)
        {
            data[COMPONENT_TYPE] = fullTypeName;
        }
    }
}