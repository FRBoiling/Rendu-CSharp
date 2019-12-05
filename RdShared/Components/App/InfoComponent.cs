using Consts;
using Entitas;
using Entitas.Attributes;

namespace Components
{
    [Context("App")]
    public class InfoComponent : IComponent
    {
        public string _name;
        public AppType _appType;
        public string _key1;
    }
}