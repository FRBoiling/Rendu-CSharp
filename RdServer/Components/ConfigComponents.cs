using Entitas;
using Entitas.Attributes;

namespace Server
{
    [Context("Config")]
    public class XmlDataComponent:IComponent
    {
        public int Key;
    }
}
