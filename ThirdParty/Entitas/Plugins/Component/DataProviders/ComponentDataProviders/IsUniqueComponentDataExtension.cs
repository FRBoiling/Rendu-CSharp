namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public static class IsUniqueComponentDataExtension
    {
        public const string COMPONENT_IS_UNIQUE = "Component.Unique";

        public static bool IsUnique(this ComponentData data)
        {
            return (bool) data[COMPONENT_IS_UNIQUE];
        }

        public static void IsUnique(this ComponentData data, bool isUnique)
        {
            data[COMPONENT_IS_UNIQUE] = isUnique;
        }
    }
}