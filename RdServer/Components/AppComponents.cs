using Entitas;
using Entitas.Attributes;

namespace Server
{
    public enum AppType
    {
        Default,
        Client,
        Server,
        Gate,
        Zone,
    }

    [Context("App")]
    public class InfoComponent : IComponent
    {
        public AppType AppType;
        public int MainKey;
        public int SubKey;
    }

}
