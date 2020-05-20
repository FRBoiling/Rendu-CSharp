using Rd.Utils;
using System;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class ProtoFileGenerator
    {
        private ProtoFile _protoFile;
        public ProtoFileGenerator(ProtoFile protoFile)
        {
            _protoFile = protoFile;
        }
        
        public void Generate()
        {
            if (FileUtil.WriteToFile(_protoFile.ProtoBuffContext,_protoFile.FullName))
            {
                //Log.Info($"{_protoFile.FullName} generate success");
                return;
            }
            throw new Exception($"{_protoFile.FullName} generate fail");
        }
    }


}