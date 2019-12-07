using Consts;
using Entitas;
using Entitas.Attributes;
using System;

namespace Server
{
    [Context("Gate"),Context("Zone")]
    public class InfoComponent : IComponent
    {
        public string _name;
        public AppType _appType;
        public string _key1;
    }
}
