using System;
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

        static ComponentData[] getMultipleData<T>(Preferences preferences = null)
        {
            var provider = new ComponentDataProvider(new Type[] {typeof(T)});
            if (preferences == null)
            {
                preferences = new TestPreferences(
                    @"Entitas.CodeGeneration.Plugins.Contexts = Game, GameState
Entitas.CodeGeneration.Plugins.IgnoreNamespaces = false");
            }
            provider.Configure(preferences);

            return (ComponentData[]) provider.GetData();
        }
    }
}