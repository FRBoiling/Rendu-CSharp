using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace TestProject.Fixtures
{
//    [Game, Input]
    public class EntityIndexComponent : IComponent {

        [EntityIndex]
        public string value;
    }
}