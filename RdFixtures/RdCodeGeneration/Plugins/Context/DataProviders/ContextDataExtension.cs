namespace Rd.Plugins.Context.DataProviders
{
    public static class ContextDataExtension
    {
        public const string CONTEXT_NAME = "Context.Name";

        public static string GetContextName(this ContextData data)
        {
            return (string) data[CONTEXT_NAME];
        }

        public static void SetContextName(this ContextData data, string contextName)
        {
            data[CONTEXT_NAME] = contextName;
        }
    }
}