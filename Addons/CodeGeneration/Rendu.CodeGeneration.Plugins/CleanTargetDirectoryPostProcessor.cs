using System.Collections.Generic;
using System.IO;
using Rd.CodeGeneration;
using Rd.Logging;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class CleanTargetDirectoryPostProcessor : IPostProcessor, IConfigurable
    {
        private readonly Logger _logger = fabl.GetLogger(typeof (CleanTargetDirectoryPostProcessor));
        private readonly TargetDirectoryConfig _targetDirectoryConfig = new TargetDirectoryConfig();

        public string name
        {
            get
            {
                return "Clean target directory";
            }
        }

        public int priority
        {
            get
            {
                return 0;
            }
        }

        public bool runInDryMode
        {
            get
            {
                return false;
            }
        }

        public Dictionary<string, string> defaultProperties
        {
            get
            {
                return this._targetDirectoryConfig.defaultProperties;
            }
        }

        public void Configure(Preferences preferences)
        {
            this._targetDirectoryConfig.Configure(preferences);
        }

        public CodeGenFile[] PostProcess(CodeGenFile[] files)
        {
            this.cleanDir();
            return files;
        }

        private void cleanDir()
        {
            if (Directory.Exists(this._targetDirectoryConfig.targetDirectory))
            {
                foreach (FileInfo file in new DirectoryInfo(this._targetDirectoryConfig.targetDirectory).GetFiles("*.cs", SearchOption.AllDirectories))
                {
                    try
                    {
                        File.Delete(file.FullName);
                    }
                    catch
                    {
                        this._logger.Error("Could not delete file " + (object) file);
                    }
                }
            }
            else
                Directory.CreateDirectory(this._targetDirectoryConfig.targetDirectory);
        }
    }
}