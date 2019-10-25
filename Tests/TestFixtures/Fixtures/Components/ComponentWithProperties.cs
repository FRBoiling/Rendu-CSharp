using Entitas;

[Context("Test")]
public class ComponentWithProperties : IComponent
{
    // Has one public property
    [TestMember("myProperty")] public string publicProperty { get; set; }

    // Should be ignored
    public static bool publicStaticProperty { get; set; }
    private bool _privateProperty { get; set; }
    private static bool _privateStaticProperty { get; set; }

    public string publicPropertyGet => null;

    public string publicPropertySet
    {
        set { }
    }
}