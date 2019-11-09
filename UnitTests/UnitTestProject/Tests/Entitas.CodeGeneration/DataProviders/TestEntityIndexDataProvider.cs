using NUnit.Framework;
using Rd.Plugins.EntityIndex;
using Rd.Plugins.EntityIndex.DataProviders;
using Rd.Serialization;
using UnitTestProject.Fixtures;
using UnitTestProject.Fixtures.Components;
using UnitTestProject.Fixtures.Preferences;

namespace UnitTestProject
{
    public partial class Tests
    {
        private EntityIndexData[] getData<T1, T2>(Preferences preferences = null)
        {
            var provider = new EntityIndexDataProvider(new[] {typeof(T1), typeof(T2)});
            if (preferences == null)
                preferences = new TestPreferences($@"Entitas.Rd.CodeGeneration.Rd.Plugins.Contexts = Game, GameState {"\n"} Entitas.Rd.CodeGeneration.Rd.Plugins.IgnoreNamespaces = false");

            provider.Configure(preferences);

            return (EntityIndexData[]) provider.GetData();
        }

        [Test]
        public void TestEntityIndexDataProvider()
        {
//            creates data for single entity index"
            var data = getData<TestEntityIndexComponent, TestStandardComponent>();
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
            Assert.AreEqual(d.GetContextNames()[0], "Test1");
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

        [Test]
        public void TestMultipleEntityIndexDataProvider()
        {
            //creates data for multiple entity index
            var data = getData<TestMultipleEntityIndicesComponent, TestStandardComponent>();
            Assert.AreEqual(data.Length, 2);

            Assert.AreEqual(data[0].GetEntityIndexName(), "MyNamespaceMultipleEntityIndices");
            Assert.AreEqual(data[0].GetHasMultiple(), true);

            Assert.AreEqual(data[1].GetEntityIndexName(), "MyNamespaceMultipleEntityIndices");
            Assert.AreEqual(data[1].GetHasMultiple(), true);
        }

        [Test]
        public void TestSinglePrimaryEntityIndexDataProvider()
        {
            //creates data for single primary entity index
            var data = getData<TestPrimaryEntityIndexComponent, TestStandardComponent>();

            Assert.AreEqual(data.Length, 1);
            var d = data[0];

            Assert.AreEqual(d.GetEntityIndexType(), "Entitas.PrimaryEntityIndex");
            Assert.AreEqual(d.IsCustom(), true);
            Assert.AreEqual(d.GetEntityIndexName(), "PrimaryEntityIndex");
            Assert.AreEqual(d.GetContextNames().Length, 1);
            Assert.AreEqual(d.GetContextNames()[0], "Game");
            Assert.AreEqual(d.GetKeyType(), "string");
            Assert.AreEqual(d.GetComponentType(), "PrimaryEntityIndexComponent");
            Assert.AreEqual(d.GetMemberName(), "value");
            Assert.AreEqual(d.GetHasMultiple(), false);
        }

        [Test]
        public void TestMultiplePrimaryEntityIndexDataProvider()
        {
            //creates data for multiple primary entity index
            {
                var data = getData<TestMultiplePrimaryEntityIndicesComponent, TestStandardComponent>();

                Assert.AreEqual(data.Length, 2);

                Assert.AreEqual(data[0].GetEntityIndexName(), "MultiplePrimaryEntityIndices");
                Assert.AreEqual(data[0].GetHasMultiple(), true);

                Assert.AreEqual(data[1].GetEntityIndexName(), "MultiplePrimaryEntityIndices");
                Assert.AreEqual(data[1].GetHasMultiple(), true);
            }
        }

        [Test]
        public void TestIgnoresAbstractComponentsDataProvider()
        {
            //ignores abstract components
            {
                var data = getData<TestAbstractEntityIndexComponent, TestStandardComponent>();
                Assert.AreEqual(data.Length, 0);
            }
        }

//        [Test]
//        public void TestCustomEntityIndexDataProvider()
//        {
//            //creates data for custom entity index class
//            {
//                var data = getData<CustomEntityIndex, TestStandardComponent>();
//
//                data.Length.should_be(1);
//                var d = data[0];
//
//                d.GetEntityIndexType().should_be("MyNamespace.CustomEntityIndex");
//                d.IsCustom().should_be_true();
//                d.GetEntityIndexName().should_be("MyNamespaceCustomEntityIndex");
//                d.GetContextNames().Length.should_be(1);
//                d.GetContextNames()[0].should_be("Test");
//
//                var methods = d.GetCustomMethods();
//                methods.GetType().should_be(typeof(MethodData[]));
//                methods.Length.should_be(2);
//            }
//        }
    }
}