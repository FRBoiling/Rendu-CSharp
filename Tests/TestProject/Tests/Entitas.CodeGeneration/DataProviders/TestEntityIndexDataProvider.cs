using System;
using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;
using NUnit.Framework;
using TestProject.Fixtures;

namespace TestProject
{
    public partial class Tests
    {
        EntityIndexData[] getData<T1, T2>(Preferences preferences = null)
        {
            var provider = new EntityIndexDataProvider(new Type[] {typeof(T1), typeof(T2)});
            if (preferences == null)
            {
                preferences = new TestPreferences($@"Entitas.CodeGeneration.Plugins.Contexts = Game, GameState {"\n"} Entitas.CodeGeneration.Plugins.IgnoreNamespaces = false");
            }

            provider.Configure(preferences);

            return (EntityIndexData[]) provider.GetData();
        }

        [Test]
        public void TestEntityIndexDataProvider()
        {
            var data = getData<EntityIndexComponent, StandardComponent>();
            Assert.AreEqual(data.Length, 1);

            var d = data[0];

            Assert.AreEqual(d.GetEntityIndexType().GetType(), typeof(string));
            Assert.AreEqual(d.GetEntityIndexType(), "Entitas.EntityIndex");
            Assert.AreEqual(d.IsCustom().GetType(), typeof(bool));
            Assert.AreEqual(d.IsCustom(), false);

            Assert.AreEqual(d.GetEntityIndexName().GetType(), typeof(string));
            Assert.AreEqual(d.GetEntityIndexName(), "MyNamespaceEntityIndex");

            Assert.AreEqual(d.GetContextNames().GetType(), typeof(string));
            Assert.AreEqual(d.GetContextNames().Length, 2);
            Assert.AreEqual(d.GetContextNames()[0], "Test");
            Assert.AreEqual(d.GetContextNames()[1], "Test2");

            Assert.AreEqual(d.GetKeyType().GetType(), typeof(string));
            Assert.AreEqual(d.GetKeyType(), "string");

            Assert.AreEqual(d.GetComponentType().GetType(), typeof(string));
            Assert.AreEqual(d.GetComponentType(), "My.Namespace.EntityIndexComponent");

            Assert.AreEqual(d.GetMemberName().GetType(), typeof(string));
            Assert.AreEqual(d.GetMemberName(), "value");

            Assert.AreEqual(d.GetHasMultiple().GetType(), typeof(bool));
            Assert.AreEqual(d.GetHasMultiple(), false);
        }
    }
}