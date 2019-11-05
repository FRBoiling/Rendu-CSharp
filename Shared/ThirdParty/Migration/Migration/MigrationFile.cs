namespace Entitas.Migration
{
    public class MigrationFile
    {
        public string fileContent;

        public string fileFullName;

        public MigrationFile(string fileFullName, string fileContent)
        {
            this.fileFullName = fileFullName;
            this.fileContent = fileContent;
        }
    }
}