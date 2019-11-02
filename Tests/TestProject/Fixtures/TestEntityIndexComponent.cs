using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace TestProject.Fixtures
{
//    [Game, Input]
    public class TestEntityIndexComponent : IComponent {

        [EntityIndex]
        public string value;
    }
    
    [Test1, Test2]
    public class TestMultipleEntityIndicesComponent : IComponent {

        [EntityIndex]
        public string value;

        [EntityIndex]
        public string value2;
    }
    
    public class TestPrimaryEntityIndexComponent : IComponent {

        [PrimaryEntityIndex]
        public string value;
    }
    
    public class TestMultiplePrimaryEntityIndicesComponent : IComponent {

        [PrimaryEntityIndex]
        public string value;

        [PrimaryEntityIndex]
        public string value2;
    }
    
    public abstract class TestAbstractEntityIndexComponent {

        [EntityIndex]
        public string value;
    }
    
//    [CustomEntityIndex(typeof(TestContext))]
//    public class TestCustomEntityIndex : EntityIndex<TestEntity, IntVector2> {
//
//        static readonly List<IntVector2> _cachedList = new List<IntVector2>();
//
//        public CustomEntityIndex(TestContext context)
//            : base(
//                "MyCustomEntityIndex",
//                context.GetGroup(Matcher<TestEntity>.AllOf(TestMatcher.Position, TestMatcher.Size)),
//                (e, c) => {
//                    var position = c is PositionComponent ? (PositionComponent)c : e.position;
//                    var size = c is SizeComponent ? (SizeComponent)c : e.size;
//
//                    _cachedList.Clear();
//                    for (int x = position.x; x < position.x + size.width; x++) {
//                        for (int y = position.y; y < position.y + size.height; y++) {
//                            _cachedList.Add(new IntVector2(x, y));
//                        }
//                    }
//
//                    return _cachedList.ToArray();
//                }
//            ) {
//        }
//
//        [EntityIndexGetMethod]
//        public HashSet<TestEntity> GetEntitiesWithPosition(IntVector2 position) {
//            return GetEntities(position);
//        }
//
//        [EntityIndexGetMethod]
//        public HashSet<TestEntity> GetEntitiesWithPosition2(IntVector2 position, IntVector2 size) {
//            return GetEntities(position);
//        }
//    }
    
}