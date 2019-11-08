using Rd.Utils;

namespace Rd.CodeGeneration
{
    public class CodeGenFile
    {
        private string _fileContent;

        public CodeGenFile(string fileName, string fileContent, string generatorName)
        {
            this.fileName = fileName;
            this.fileContent = fileContent;
            this.generatorName = generatorName;
        }

        public string fileName { get; set; }

        public string fileContent
        {
            get => _fileContent;
            set => _fileContent = value.ToUnixLineEndings();
        }

        public string generatorName { get; set; }
    }
}