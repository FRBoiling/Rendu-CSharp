using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;

namespace TestProject.Fixtures.Generation
{
    public class TestDataGeneration
    {
        public static ComponentData getData<T>(Preferences preferences = null)
        {
            return getMultipleData<T>(preferences)[0];
        }

        public static ComponentData[] getMultipleData<T>(Preferences preferences = null)
        {
            var provider = new ComponentDataProvider(new[] {typeof(T)});
            if (preferences == null)
                preferences = new TestPreferences(
                    @"Entitas.CodeGeneration.Plugins.Contexts = Test1, Test2
Entitas.CodeGeneration.Plugins.IgnoreNamespaces = true");
            provider.Configure(preferences);

            return (ComponentData[]) provider.GetData();
        }
    }
}