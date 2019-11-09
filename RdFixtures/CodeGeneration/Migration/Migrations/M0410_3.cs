using System.Collections.Generic;
using System.Linq;

namespace Rd.Migration.Migrations
{
    public class M0410_3 : IMigration
    {
        public string version => "0.41.0-3";

        public string workingDirectory => "where custom TypeDrawers are located";

        public string description => "Updating namespaces";

        public MigrationFile[] Migrate(string path)
        {
            var files = MigrationUtils.GetFiles(path);

            var migratedFiles = new List<MigrationFile>();

            migratedFiles.AddRange(updateNamespace(files, "Rendu.Rendu.Entitas.Unity.Editor.VisualDebugging", "Rendu.VisualDebugging.Unity.Editor"));

            return migratedFiles.ToArray();
        }

        private MigrationFile[] updateNamespace(MigrationFile[] files, string oldNamespace, string newNamespace)
        {
            var filesToMigrate = files.Where(f => f.fileContent.Contains(oldNamespace)).ToArray();
            foreach (var file in filesToMigrate) file.fileContent = file.fileContent.Replace(oldNamespace, newNamespace);

            return filesToMigrate;
        }
    }
}