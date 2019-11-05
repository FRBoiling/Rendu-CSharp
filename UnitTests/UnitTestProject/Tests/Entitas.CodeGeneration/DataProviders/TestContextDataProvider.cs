using Entitas.CodeGeneration.Plugins;
using NUnit.Framework;

namespace TestProject
{
    public partial class Tests
    {
        [Test]
        public void TestContextDataProvider()
        {
            //creates data for each context name
            var names = "Entitas.CodeGeneration.Plugins.Contexts = Input, GameState";
            var provider = new ContextDataProvider();
            provider.Configure(new TestPreferences(names));

            var data = (ContextData[]) provider.GetData();
            Assert.AreEqual(data.Length, 2);
            Assert.AreEqual(data[0].GetContextName(), "Input");
            Assert.AreEqual(data[1].GetContextName(), "GameState");
        }
    }
}