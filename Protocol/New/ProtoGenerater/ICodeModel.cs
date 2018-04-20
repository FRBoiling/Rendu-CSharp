using System.Collections.Generic;
using System.Text;

namespace ProtoGenerater
{
    interface ICodeModel
    {
        StringBuilder ClassCommentsFrame();
        StringBuilder IncludeHeadFrame();
        StringBuilder NameSpaceFrame(string nameSpace,StringBuilder classBody);
        StringBuilder ClassBodyFrame(string className, List<StringBuilder> attrs=null, List<StringBuilder> methods=null,int spaceCount = 1);
        StringBuilder ClassAttrFrame(string attrType, string attrName,int spaceCount = 2);
        StringBuilder ClassMethodFrame(string methodType, string methodName, List<StringBuilder> methodValue, int spaceCount = 2);

    }
}