using System.IO;

internal class describe_MigrationUtils : nspec
{
    private void when_migrating()
    {
        var dir = TestExtensions.GetProjectRoot() + "/Tests/Tests/Tests/Entitas.Migration/Fixtures/M0180";

        it["gets only *.cs source files"] = () =>
        {
            var files = MigrationUtils.GetFiles(dir);
            files.Length.should_be(6);
            files.Any(file => file.fileName == Path.Combine(dir, "SourceFile.cs")).should_be_true();
            files.Any(file => file.fileName == Path.Combine(dir, Path.Combine("SubFolder", "SourceFile2.cs"))).should_be_true();
            files.Any(file => file.fileName == Path.Combine(dir, "RenderPositionSystem.cs")).should_be_true();
            files.Any(file => file.fileName == Path.Combine(dir, "RenderRotationSystem.cs")).should_be_true();
            files.Any(file => file.fileName == Path.Combine(dir, Path.Combine("SubFolder", "RenderSelectedSystem.cs"))).should_be_true();
            files.Any(file => file.fileName == Path.Combine(dir, Path.Combine("SubFolder", "MoveSystem.cs"))).should_be_true();
        };
    }
}