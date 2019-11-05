using System;
using System.Linq;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public class Contexts : IContexts
{
    private static Contexts _sharedInstance;

    public Contexts()
    {
        server = new ServerContext();

        var postConstructors = Enumerable.Where(
            GetType().GetMethods(),
            method => Attribute.IsDefined(method, typeof(PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) postConstructor.Invoke(this, null);
    }

    public static Contexts sharedInstance
    {
        get
        {
            if (_sharedInstance == null) _sharedInstance = new Contexts();

            return _sharedInstance;
        }
        set => _sharedInstance = value;
    }

    public ServerContext server { get; set; }

    public IContext[] allContexts
    {
        get { return new IContext[] {server}; }
    }

    public void Reset()
    {
        var contexts = allContexts;
        for (var i = 0; i < contexts.Length; i++) contexts[i].Reset();
    }
}