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



    public IContext[] allContexts { get { return new IContext [] {  }; } }

    public Contexts() 
    {


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
