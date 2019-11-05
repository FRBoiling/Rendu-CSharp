public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public Server /n Entitas.CodeGeneration.Plugins.IgnoreNamespaces = trueContext server /n Entitas.CodeGeneration.Plugins.IgnoreNamespaces = true { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { server /n Entitas.CodeGeneration.Plugins.IgnoreNamespaces = true }; } }

    public Contexts() {
        server /n Entitas.CodeGeneration.Plugins.IgnoreNamespaces = true = new Server /n Entitas.CodeGeneration.Plugins.IgnoreNamespaces = trueContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}
