using Entitas;
using Entitas.Attributes;

namespace Components
{
    [Context("Server")]
    public class ServerComponent : IComponent
    {
        private string _serverName;
    }
}