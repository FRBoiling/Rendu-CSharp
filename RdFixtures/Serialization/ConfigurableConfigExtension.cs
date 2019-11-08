namespace Rd.Serialization
{
    public static class ConfigurableConfigExtension
    {
        public static T CreateAndConfigure<T>(this Preferences preferences) where T : IConfigurable, new()
        {
            T obj = new T();
            obj.Configure(preferences);
            return obj;
        }
    }
}