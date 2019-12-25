namespace Rd.Plugins
{
    public static class FlagPrefixComponentDataExtension
    {
        public const string COMPONENT_FLAG_PREFIX = "Component.FlagPrefix";

        public static string GetFlagPrefix(this ComponentData data)
        {
            return (string) data[COMPONENT_FLAG_PREFIX];
        }

        public static void SetFlagPrefix(this ComponentData data, string prefix)
        {
            data[COMPONENT_FLAG_PREFIX] = prefix;
        }
    }
}