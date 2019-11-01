using System;
using System.IO;
using System.Linq;

namespace Entitas.Migration {

    public static class MigrationUtils {

        public static MigrationFile[] GetFiles(string path, string searchPattern = "*.cs") {
            return Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories)
                .Select(p => new MigrationFile(p, File.ReadAllText(p)))
                .ToArray();
        }

        public static void WriteFiles(MigrationFile[] files) {
            foreach (var file in files) {
                var fileInfo = new FileInfo(file.fileFullName);
                if (!fileInfo.Exists)
                {
                    if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
                    {
                        Directory.CreateDirectory(fileInfo.Directory.FullName);
                    }
                }
                Console.WriteLine("Migrating: " + fileInfo.FullName);
                File.WriteAllText(file.fileFullName, file.fileContent);
            }
        }
    }
}
