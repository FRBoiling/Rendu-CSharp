using NUnit.Framework;
using Rd.Plugins.Context;
using Rd.Plugins.Context.DataProviders;
using UnitTestProject.Fixtures.Preferences;

namespace UnitTestProject
{
    public partial class Tests
    {
        [Test]
        public void TestContextDataProvider()
        {
            //creates data for each context name
            var names = "Entitas.Rd.CodeGeneration.Rd.Plugins.Contexts = Input, GameState";
            var provider = new ContextDataProvider();
            provider.Configure(new TestPreferences(names));

            var data = (ContextData[]) provider.GetData();
            Assert.AreEqual(data.Length, 2);
            Assert.AreEqual(data[0].GetContextName(), "Input");
            Assert.AreEqual(data[1].GetContextName(), "GameState");
        }
    }
}