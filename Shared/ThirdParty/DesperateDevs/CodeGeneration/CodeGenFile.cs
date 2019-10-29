using DesperateDevs.Utils;

namespace DesperateDevs.CodeGeneration
{
    public class CodeGenFile
    {
        private string _fileContent;

        public string fileName { get; set; }

        public string fileContent
        {
            get
            {
                return this._fileContent;
            }
            set
            {
                this._fileContent = value.ToUnixLineEndings();
            }
        }

        public string generatorName { get; set; }

        public CodeGenFile(string fileName, string fileContent, string generatorName)
        {
            this.fileName = fileName;
            this.fileContent = fileContent;
            this.generatorName = generatorName;
        }
    }
}