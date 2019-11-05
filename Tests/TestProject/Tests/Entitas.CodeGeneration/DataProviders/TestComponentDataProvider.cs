using System;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Attributes;
using Entitas.CodeGeneration.Plugins;
using NUnit.Framework;
using TestProject.Fixtures;

namespace TestProject
{
    public partial class Tests
    {
        ComponentData getData<T>(Preferences preferences = null)
        {
            return getMultipleData<T>(preferences)[0];
        }

        ComponentData[] getMultipleData<T>(Preferences preferences = null)
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

        [Test]
        public void TestComponentDataProvider()
        {
            Type type = null;
            ComponentData standardData = null;

            //component
            {
                type = typeof(TestStandardComponent);
                standardData = getData<TestStandardComponent>();
            }

            //get data
            {
                Assert.IsNotNull(standardData);
            }
            //gets full type name
            {
                Assert.AreEqual(standardData.GetTypeName().GetType(), typeof(string));
                Assert.AreEqual(standardData.GetTypeName(), type.ToCompilableString());
            }

            //gets contexts
            {
                var contextNames = standardData.GetContextNames();
                Assert.AreEqual(contextNames.GetType(), typeof(string[]));

                Assert.AreEqual(contextNames.Length, 2);
                Assert.AreEqual(contextNames[0], "Test1");
                Assert.AreEqual(contextNames[1], "Test2");
            }

            //sets first context as default when component has no context
            {
                var contextNames = getData<TestNoContextComponent>().GetContextNames();
                Assert.AreEqual(contextNames.Length, 1);
                Assert.AreEqual(contextNames[0], "Game");
            }

            //gets unique
            {
                Assert.AreEqual(standardData.IsUnique().GetType(), typeof(bool));

                Assert.AreEqual(standardData.IsUnique(), false);
                var uniqueData = getData<TestUniqueContextComponent>();
                Assert.AreEqual(uniqueData.IsUnique(), true);
            }

            //gets member data
            {
                Assert.AreEqual(standardData.GetMemberData().GetType(), typeof(MemberData[]));
                Assert.AreEqual(standardData.GetMemberData().Length, 1);
                Assert.AreEqual(standardData.GetMemberData()[0].type, "string");
            }

            //gets generate component
            {
                Assert.AreEqual(standardData.ShouldGenerateComponent().GetType(), typeof(bool));
                Assert.AreEqual(standardData.ShouldGenerateComponent(), false);

                Assert.AreEqual(standardData.ContainsKey(ShouldGenerateComponentComponentDataExtension.COMPONENT_OBJECT_TYPE), false);
            }

            //gets generate index
            {
                Assert.AreEqual(standardData.ShouldGenerateIndex().GetType(), typeof(bool));
                Assert.AreEqual(standardData.ShouldGenerateIndex(), true);

                Assert.AreEqual(getData<TestUniqueContextComponent>().ShouldGenerateIndex(), false);
            }

            //gets generate methods
            {
                Assert.AreEqual(standardData.ShouldGenerateMethods().GetType(), typeof(bool));
                Assert.AreEqual(standardData.ShouldGenerateMethods(), true);

                Assert.AreEqual(getData<TestUniqueContextComponent>().ShouldGenerateMethods(), false);
            }

            //gets flag prefix
            {
                Assert.AreEqual(standardData.GetFlagPrefix().GetType(), typeof(string));
                Assert.AreEqual(standardData.GetFlagPrefix(), "is");

                Assert.AreEqual(getData<TestCustomPrefixFlagComponent>().GetFlagPrefix(), "My");
            }

            //gets is no event
            {
                Assert.AreEqual(standardData.IsEvent().GetType(), typeof(bool));
                Assert.AreEqual(standardData.IsEvent(), false);
            }

            //gets event
            {
                Assert.AreEqual(getData<TestEventStandardComponent>().IsEvent(), true);
            }

            //gets multiple events
            {
                var d = getData<TestMultipleEventsStandardComponent>();
                Assert.AreEqual(d.IsEvent(), true);
                var eventData = d.GetEventData();
                Assert.AreEqual(eventData.Length, 2);

                Assert.AreEqual(eventData[0].eventTarget, EventTarget.Any);
                Assert.AreEqual(eventData[0].eventType, EventType.Added);
                Assert.AreEqual(eventData[0].priority, 1);

                Assert.AreEqual(eventData[1].eventTarget, EventTarget.Self);
                Assert.AreEqual(eventData[1].eventType, EventType.Removed);
                Assert.AreEqual(eventData[1].priority, 2);
            }
            ;

            //gets event target
            {
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].eventTarget.GetType(), typeof(EventType));
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].eventTarget, EventTarget.Any);

                Assert.AreEqual(getData<TestEntityEventStandardComponent>().GetEventData()[0].eventTarget, EventTarget.Self);
            }
            ;

            //gets event type
            {
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].eventType.GetType(), typeof(EventType));
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].eventType, EventType.Added);

                Assert.AreEqual(getData<TestEntityEventStandardComponent>().GetEventData()[0].eventType, EventType.Removed);
            }
            ;

            //gets event priority
            {
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].priority.GetType(), typeof(int));
                Assert.AreEqual(getData<TestEventStandardComponent>().GetEventData()[0].priority, 1);

                Assert.AreEqual(getData<TestEntityEventStandardComponent>().GetEventData()[0].priority, 1);
            }
            ;

            //creates data for event listeners
            {
                var d = getMultipleData<TestEventStandardComponent>();
                Assert.AreEqual(d.Length, 2);
                Assert.AreEqual(d[1].IsEvent(), false);
                Assert.AreEqual(d[1].GetTypeName(), "AnyStandardEventListenerComponent");
                Assert.AreEqual(d[1].GetMemberData().Length, 1);
                Assert.AreEqual(d[1].GetMemberData()[0].name, "value");
                Assert.AreEqual(d[1].GetMemberData()[0].type, "System.Collections.Generic.List<IAnyStandardEventListener>");
            }
            ;

            //creates data for unique event listeners
            {
                var d = getMultipleData<TestUniqueEventComponent>();
                Assert.AreEqual(d.Length, 2);
                Assert.AreEqual(d[1].IsEvent(), false);
                Assert.AreEqual(d[1].IsUnique(), false);
            }
            ;

            //creates data for event listeners with multiple contexts
            {
                var d = getMultipleData<TestMultipleContextStandardEventComponent>();

                Assert.AreEqual(d.Length, 3);
                Assert.AreEqual(d[1].IsEvent(), false);
                Assert.AreEqual(d[1].GetTypeName(), "TestAnyMultipleContextStandardEventListenerComponent");

                Assert.AreEqual(d[1].GetMemberData().Length, 1);
                Assert.AreEqual(d[1].GetMemberData()[0].name, "value");
                Assert.AreEqual(d[1].GetMemberData()[0].type, "System.Collections.Generic.List<ITestAnyMultipleContextStandardEventListener>");

                Assert.AreEqual(d[2].IsEvent(), false);
                Assert.AreEqual(d[2].GetTypeName(), "Test2AnyMultipleContextStandardEventListenerComponent");

                Assert.AreEqual(d[2].GetMemberData().Length, 1);
                Assert.AreEqual(d[2].GetMemberData()[0].name, "value");
                Assert.AreEqual(d[2].GetMemberData()[0].type, "System.Collections.Generic.List<ITest2AnyMultipleContextStandardEventListener>");
            }
        }

        [Test]
        public void TestNonComponentDataProvider()
        {
            //non component
            {
                Type type = null;
                ComponentData data = null;
                type = typeof(TestClassToGenerate);

                //get data
                {
                    data = getData<TestClassToGenerate>();
                    Assert.IsNotNull(data);
                }

                //gets full type name
                {
                    // Not the type, but the component that should be generated
                    // See: no namespace
                    Assert.AreEqual(data.GetTypeName(), "ClassToGenerateComponent");
                }

                //gets contexts
                {
                    var contextNames = data.GetContextNames();
                    Assert.AreEqual(contextNames.Length, 2);
                    Assert.AreEqual(contextNames[0], "Test1");
                    Assert.AreEqual(contextNames[1], "Test2");
                }

                //gets unique
                {
                    Assert.AreEqual(data.IsUnique(), false);
                }

                //gets member data 
                {
                    Assert.AreEqual(data.GetMemberData().Length, 1);
                    Assert.AreEqual(data.GetMemberData()[0].type, type.ToCompilableString());
                }

                //gets generate component
                {
                    Assert.AreEqual(data.ShouldGenerateComponent().GetType(), typeof(bool));
                    Assert.AreEqual(data.ShouldGenerateComponent(), true);
                    Assert.AreEqual(data.GetObjectTypeName(), typeof(TestClassToGenerate).ToCompilableString());
                }

                //gets generate index
                {
                    Assert.AreEqual(data.ShouldGenerateIndex(), true);
                }

                //gets generate methods
                {
                    Assert.AreEqual(data.ShouldGenerateMethods(), true);
                }

                //gets flag prefix"] = () =>
                {
                    Assert.AreEqual(data.GetFlagPrefix(), "is");
                }

                //gets is no event
                {
                    Assert.AreEqual(data.IsEvent(), false);
                }

                //gets event
                {
                    Assert.AreEqual(getData<TestEventClassToGenerate>().GetEventData().Length, 1);
                    var eventData = getData<TestEventClassToGenerate>().GetEventData()[0];
                    Assert.AreEqual(eventData.eventTarget, EventTarget.Any);
                    Assert.AreEqual(eventData.eventType, EventType.Added);
                    Assert.AreEqual(eventData.priority, 0);
                }

                //creates data for event listeners
                {
                    var d = getMultipleData<TestEventClassToGenerate>();
                    Assert.AreEqual(d.Length, 3);
                    Assert.AreEqual(d[1].IsEvent(), false);
                    Assert.AreEqual(d[1].ShouldGenerateComponent(), false);
                    Assert.AreEqual(d[1].GetTypeName(), "TestAnyEventToGenerateListenerComponent");
                    Assert.AreEqual(d[1].GetMemberData().Length, 1);
                    Assert.AreEqual(d[1].GetMemberData()[0].name, "value");
                    Assert.AreEqual(d[1].GetMemberData()[0].type, "System.Collections.Generic.List<ITestAnyEventToGenerateListener>");

                    Assert.AreEqual(d[2].IsEvent(), false);
                    Assert.AreEqual(d[2].ShouldGenerateComponent(), false);
                    Assert.AreEqual(d[2].GetTypeName(), "Test2AnyEventToGenerateListenerComponent");
                    Assert.AreEqual(d[2].GetMemberData().Length, 1);
                    Assert.AreEqual(d[2].GetMemberData()[0].name, "value");
                    Assert.AreEqual(d[2].GetMemberData()[0].type, "System.Collections.Generic.List<ITest2AnyEventToGenerateListener>");
                }
            }
        }

        [Test]
        public void TestMultipleTypesProvider()
        {
            //multiple types
            {
                //creates data for each type"] = () =>
                {
                    var types = new[] {typeof(NameAgeComponent), typeof(Test2ContextComponent)};
                    var provider = new ComponentDataProvider(types);
                    provider.Configure(new TestPreferences(
                        "Entitas.CodeGeneration.Plugins.Contexts = Game, GameState"
                    ));
                    var data = provider.GetData();
                    Assert.AreEqual(data.Length, types.Length);
                }
                ;

                //ignores duplicates from non components"] = () =>
                {
                    var types = new[] {typeof(TestClassToGenerate), typeof(ClassToGenerateComponent)};
                    var provider = new ComponentDataProvider(types);
                    provider.Configure(new TestPreferences(
                        "Entitas.CodeGeneration.Plugins.Contexts = Game, GameState"
                    ));
                    var data = provider.GetData();
                    Assert.AreEqual(data.Length, 1);
                }
            }
        }


        [Test]
        public void TestMultipleCustomComponentNamesProvider()
        {
            //multiple custom component names
            {
                Type type = null;
                ComponentData data1 = null;
                ComponentData data2 = null;

                type = typeof(TestCustomName);
                var data = getMultipleData<TestCustomName>();
                data1 = data[0];
                data2 = data[1];

                //creates data for each custom component name"] = () =>
                {
                    Assert.AreEqual(data1.GetObjectTypeName(), type.ToCompilableString());
                    Assert.AreEqual(data2.GetObjectTypeName(), type.ToCompilableString());

                    Assert.AreEqual(data1.GetTypeName(), "NewCustomNameComponent1Component");
                    Assert.AreEqual(data2.GetTypeName(), "NewCustomNameComponent2Component");
                }
            }
        }

        [Test]
        public void TestConfigureProvider()
        {
            //configure    
            {
                Type type = null;
                ComponentData data = null;

                var preferences = new TestPreferences(
                    "Entitas.CodeGeneration.Plugins.Contexts = ConfiguredContext" + "\n"
                );

                type = typeof(TestNoContextComponent);
                data = getData<TestNoContextComponent>(preferences);

                //gets default context"] = () =>
                {
                    var contextNames = data.GetContextNames();
                    Assert.AreEqual(contextNames.Length, 1);
                    Assert.AreEqual(contextNames[0], "ConfiguredContext");
                }
            }
        }
    }
}