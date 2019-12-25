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
    public NetworkContext network { get; set; }

    public IContext[] allContexts { get { return new IContext [] { app, config, network }; } }

    public Contexts() 
    {
        app = new AppContext();
        config = new ConfigContext();
        network = new NetworkContext();

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
