using Rd.Plugins.Component;
using Rd.Plugins.Component.DataProviders;
using UnitTestProject.Fixtures.Preferences;

namespace UnitTestProject.Fixtures.Generation
{
    public class TestDataGeneration
    {
        public static ComponentData getData<T>(Rd.Serialization.Preferences preferences = null)
        {
            return getMultipleData<T>(preferences)[0];
        }

        public static ComponentData[] getMultipleData<T>(Rd.Serialization.Preferences preferences = null)
        {
            var provider = new ComponentDataProvider(new[] {typeof(T)});
            if (preferences == null)
                preferences = new TestPreferences(
                    @"Entitas.Rendu.CodeGeneration.Plugins.Contexts = Test1, Test2
Entitas.Rendu.CodeGeneration.Plugins.IgnoreNamespaces = true");
            provider.Configure(preferences);

            return (ComponentData[]) provider.GetData();
        }
    }
}