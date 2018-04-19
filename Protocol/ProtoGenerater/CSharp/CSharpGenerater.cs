using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater.CSharp
{
    public class CSharpGenerater : IGenerater
    {
        public void Run(CodeFileParser parser)
        {
            CSharpMsgIdModel maker = new CSharpMsgIdModel();
            maker.CreateIdClassCode();

            foreach (var item in parser.GetKeyIdPairs())
            {
                maker.CreateMsgIdClass(parser.GetCodeFileName(),item.Key, item.Value);
                maker.GenerateProto(item.Key,parser.GetProtoOutPath());
            }

        }
    }
}
