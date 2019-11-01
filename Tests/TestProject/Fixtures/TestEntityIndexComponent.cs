using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace TestProject.Fixtures
{
//    [Game, Input]
    public class TestEntityIndexComponent : IComponent {

        [EntityIndex]
        public string value;
    }
}