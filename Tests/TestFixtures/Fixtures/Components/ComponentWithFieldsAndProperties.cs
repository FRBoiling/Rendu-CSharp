using Entitas;

[Context("Test")]
public class ComponentWithFieldsAndProperties : IComponent
{
    // Has one public field
    public string publicField;

    // Has one public property
    public string publicProperty { get; set; }
#pragma warning disable

    // Should be ignored
    public static bool publicStaticField;
    private bool _privateField;
    private static bool _privateStaticField;

    // Should be ignored
    public static bool publicStaticProperty { get; set; }
    private bool _privateProperty { get; set; }
    private static bool _privateStaticProperty { get; set; }
}