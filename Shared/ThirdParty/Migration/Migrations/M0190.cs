using System.Linq;
using System.Text.RegularExpressions;

namespace Entitas.Migration
{
    public class M0190 : IMigration
    {
        private const string EXECUTE_PATTERN = @"public\s*void\s*Execute\s*\(\s*Entity\s*\[\s*\]\s*entities\s*\)";
        private const string EXECUTE_REPLACEMENT = "public void Execute(System.Collections.Generic.List<Entity> entities)";

        public string version => "0.19.0";

        public string workingDirectory => "where all systems are located";

        public string description => "Migrates IReactiveSystem.Execute to accept List<Entity>";

        public MigrationFile[] Migrate(string path)
        {
            var files = MigrationUtils.GetFiles(path)
                .Where(file => Regex.IsMatch(file.fileContent, EXECUTE_PATTERN))
                .ToArray();

            for (var i = 0; i < files.Length; i++) files[i].fileContent = Regex.Replace(files[i].fileContent, EXECUTE_PATTERN, EXECUTE_REPLACEMENT, RegexOptions.Multiline);

            return files;
        }
    }
}