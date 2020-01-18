namespace Server
{
    public class AppFeatureSystems : Feature
    {
        public AppFeatureSystems(Contexts contexts, AppType appType, int mainKey, int subKey) : base("AppFeatureSystems")
        {
            Add(new AppContextInitSystem(contexts));
            Add(new AppInfoInitSystem(contexts,appType,mainKey,subKey));
            Add(new NetworkReactiveSystem(contexts));
            Add(new NetworkSystems(contexts));
            Add(new SessionChannelReactiveSystem(contexts));
            Add(new SessionSystems(contexts));

            switch (appType)
            {
                case AppType.Default:
                    break;
                case AppType.Client:
                    break;
                case AppType.Server:
                    break;
                case AppType.Gate:
                    break;
                case AppType.Zone:
                    break;
                default:
                    break;
            }
        }

    }
}
