using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater.CSharp
{
    public partial class CSharpMsgIdModel
    {
        public StringBuilder GenerateCode_ID()
        {
            StringBuilder IdCs;
            StringBuilder sbClassCommentsFrame = ClassCommentsFrame();
            StringBuilder sbIncludeHeadFrame = IncludeHeadFrame();
            StringBuilder sbClassAttrFrame = ClassAttrFrame("public static uint", "Value");
            List<StringBuilder> attrs = new List<StringBuilder>();
            attrs.Add(sbClassAttrFrame);
            List<StringBuilder> methods = new List<StringBuilder>();
            StringBuilder sbClassBodyFrame = ClassBodyFrame("static class Id<T>", attrs,methods);
            StringBuilder sbNameSpaceFrame = NameSpaceFrame("Protocol.MsgId", sbClassBodyFrame);

            IdCs = sbIncludeHeadFrame;
            IdCs.Append(sbNameSpaceFrame.ToString());

            return IdCs;
        }

        public StringBuilder GenerateCode_GenerateId(string packageName, Dictionary<string,string> dicMessage)
        {
            StringBuilder IdCs;
            StringBuilder sbClassCommentsFrame = ClassCommentsFrame();
            StringBuilder sbIncludeHeadFrame = IncludeHeadFrame();
   
            List<StringBuilder> attrs = new List<StringBuilder>();
            foreach (var item in dicMessage)
            {
                StringBuilder sbClassAttrFrame = ClassAttrFrame(GenerateIdKey(item.Key).ToString(), GenerateIdValue(item.Value).ToString());
                attrs.Add(sbClassAttrFrame);
            }

            StringBuilder sbClassMethodFrame = ClassMethodFrame("static void", "GenerateId()", attrs);
            List<StringBuilder> methods = new List<StringBuilder>();
            methods.Add(sbClassMethodFrame);

            StringBuilder sbClassBodyFrame = ClassBodyFrame("class Generater", null, methods);
            StringBuilder sbNameSpaceFrame = NameSpaceFrame(packageName, sbClassBodyFrame);

            IdCs = sbIncludeHeadFrame;
            IdCs.Append(sbNameSpaceFrame.ToString());
            return IdCs;
        }

        public StringBuilder GenerateIdKey(string key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Protocol.MsgId.Id");
            sb.Append("<");
            sb.Append(key);
            sb.Append(">.Value=");
            return sb;
        }

        public StringBuilder GenerateIdValue(string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(value);
            return sb;
        }



    }
}
