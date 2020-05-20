using Rd.Utils;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class GeneratorManager:Singleton<GeneratorManager>
    {
        public void Run()
        {
            ProtoFileManager.Inst.Init();
            CodeFileManager.Inst.LoadFiles(FolderManager.Inst.CodeFilesDir);
            foreach (var item in CodeFileManager.Inst.CodeFiles)
            {
                ProtoFileManager.Inst.LoadCodeFile(item.Value);
            }

            foreach (var protofile in ProtoFileManager.Inst.ProtoFiles)
            {
                if (protofile.Value.GenerateProtoFile())
                {
                    CSharpFile.ProtoBuffFile(protofile.Value);
                }  
            }
            
        }
    }
}