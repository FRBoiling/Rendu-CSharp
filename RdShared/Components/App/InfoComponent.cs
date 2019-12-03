using Consts;
using Entitas;
using Entitas.Attributes;

namespace Components
{
    [Context("App")]
    public class InfoComponent : IComponent
    {
        private string _name;
        private AppType _appType;
        private string _key1;
    }
}