using Entitas;

[Context("Test")]
public class ComponentWithFields : IComponent
{
    // Has one public field
    [TestMember("myField")] public string publicField;

    // Should be ignored
#pragma warning disable
    public static bool publicStaticField;
    private bool _privateField;
    private static bool _privateStaticField;
}