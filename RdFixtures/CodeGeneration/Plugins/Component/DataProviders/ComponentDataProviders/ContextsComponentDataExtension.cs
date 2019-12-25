namespace Rd.Plugins
{
    public static class ContextsComponentDataExtension
    {
        public const string COMPONENT_CONTEXTS = "Component.ContextNames";

        public static string[] GetContextNames(this ComponentData data)
        {
            return (string[]) data[COMPONENT_CONTEXTS];
        }

        public static void SetContextNames(this ComponentData data, string[] contextNames)
        {
            data[COMPONENT_CONTEXTS] = contextNames;
        }
    }
}