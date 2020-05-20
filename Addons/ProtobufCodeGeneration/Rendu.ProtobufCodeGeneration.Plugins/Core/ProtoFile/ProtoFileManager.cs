using Rd.Utils;
using System.Collections.Generic;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class ProtoFileManager : Singleton<ProtoFileManager>
    {
        public Dictionary<string, ProtoFile> ProtoFiles = new Dictionary<string, ProtoFile>();

        public void Init() 
        {
            ProtoFiles.Clear();
        }

        public void LoadCodeFile(CodeFile codeFile)
        {
            if (!ProtoFiles.TryGetValue(codeFile.Name, out var protoFile))
            {
                protoFile = new ProtoFile();
                protoFile.SetFileName(codeFile.Name);
                protoFile.SetSyntax(codeFile.Syntax);
                protoFile.SetPackage(codeFile.Package);
                protoFile.SetOption(codeFile.Option);
                ProtoFiles.Add(codeFile.Name, protoFile);
            }

            protoFile.LoadCodeFile(codeFile);
        }
        
    }
}