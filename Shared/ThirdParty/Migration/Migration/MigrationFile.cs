namespace Entitas.Migration {

    public class MigrationFile {

        public string fileFullName;
        public string fileContent;

        public MigrationFile(string fileFullName, string fileContent) {
            this.fileFullName = fileFullName;
            this.fileContent = fileContent;
        }
    }
}
