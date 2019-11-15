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
            var names = "Rendu.CodeGeneration.Plugins.Contexts = Test1, Test2";
            var provider = new ContextDataProvider();
            provider.Configure(new TestPreferences(names));

            var data = (ContextData[]) provider.GetData();
            Assert.AreEqual(data.Length, 2);
            Assert.AreEqual(data[0].GetContextName(), "Test1");
            Assert.AreEqual(data[1].GetContextName(), "Test2");
        }
    }
}