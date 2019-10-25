using Entitas;

internal class describe_EntitasResources : nspec
{
    private void when_version()
    {
        it["gets version"] = () => { EntitasResources.GetVersion().should_not_be_null(); };
    }
}