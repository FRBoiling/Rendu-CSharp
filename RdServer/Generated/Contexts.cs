using Entitas.Context;
public partial class Contexts : IContexts 
{
    public static Contexts sharedInstance 
    {
        get 
        {
            if (_sharedInstance == null)
            {
                _sharedInstance = new Contexts();
            }
            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public AppContext app { get; set; }
    public ConfigContext config { get; set; }
    public MessageContext message { get; set; }
    public NetworkContext network { get; set; }
    public SessionContext session { get; set; }

    public IContext[] allContexts { get { return new IContext [] { app, config, message, network, session }; } }

    public Contexts() 
    {
        app = new AppContext();
        config = new ConfigContext();
        message = new MessageContext();
        network = new NetworkContext();
        session = new SessionContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors)
        {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() 
    {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) 
        {
            contexts[i].Reset();
        }
    }
}

public partial class Contexts 
{

    public const string Network = "Network";

    [Entitas.Attributes.PostConstructor]
    public void InitializeEntityIndices() 
    {
        network.AddEntityIndex(new Entitas.EntityIndex<NetworkEntity, Rd.Networking.NetworkType>(
            Network,
            network.GetGroup(NetworkMatcher.Network),
            (e, c) => ((Server.NetworkComponent)c).NetworkType));
    }
}

public static class ContextsExtensions 
{
    public static System.Collections.Generic.HashSet<NetworkEntity> GetEntitiesWithNetwork(this NetworkContext context, Rd.Networking.NetworkType NetworkType) {
        return ((Entitas.EntityIndex<NetworkEntity, Rd.Networking.NetworkType>)context.GetEntityIndex(Contexts.Network)).GetEntities(NetworkType);
    }
}