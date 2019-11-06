using Entitas;

public class HelloWorldFeature : Feature
{
    public HelloWorldFeature(Contexts contexts) : base ("Tutorial Systems")
    {
        Add(new HelloWorldSystem(contexts));
        Add(new LogMouseClickSystem(contexts)); // new system
        Add(new DebugMessageSystem(contexts));
        Add(new CleanupDebugMessageSystem(contexts)); // new system (we want this to run last)
    }
}