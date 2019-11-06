using System.Linq;

namespace Entitas.Migration
{
    public class M0260 : IMigration
    {
        private const string POOL_PATTERN_1 = @"var poolObserver = new Entitas.Unity.Editor.VisualDebugging.PoolObserver(";
        private const string POOL_PATTERN_2 = @"UnityEngine.Object.DontDestroyOnLoad(poolObserver.entitiesContainer);";

        private const string COMPONENT_PATTERN = @"throw new SingleEntityException(";

        private const string REPLACEMENT = @"//";

        public string version => "0.26.0";

        public string workingDirectory => "where generated files are located";

        public string description => "Deactivates code to prevent compile erros";

        public MigrationFile[] Migrate(string path)
        {
            var files = MigrationUtils.GetFiles(path)
                .Where(file => file.fileContent.Contains(POOL_PATTERN_1) || file.fileContent.Contains(COMPONENT_PATTERN))
                .ToArray();

            for (var i = 0; i < files.Length; i++)
            {
                var file = files[i];
                file.fileContent = file.fileContent.Replace(POOL_PATTERN_1, REPLACEMENT + POOL_PATTERN_1);
                file.fileContent = file.fileContent.Replace(POOL_PATTERN_2, REPLACEMENT + POOL_PATTERN_2);
                file.fileContent = file.fileContent.Replace(COMPONENT_PATTERN, REPLACEMENT + COMPONENT_PATTERN);
            }

            return files;
        }
    }
}