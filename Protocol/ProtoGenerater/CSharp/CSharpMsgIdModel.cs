using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater.CSharp
{
    public partial class CSharpMsgIdModel: ICodeModel
    { 
        string spaceStr = "     ";
        private string SetSpace(int spaceCount)
        {
            StringBuilder space = new StringBuilder();
            for (int i = 0; i < spaceCount; i++)
            {
                space.Append(spaceStr);
            }
            return space.ToString();
        }


        public StringBuilder ClassCommentsFrame()
        {
            /******************************************************************************
         * 命名空间: $rootnamespace$                                                  *
         * 类 名： $safeitemrootname$                                                 *
         *                                                                            *
         * Ver      负责人        变更内容            变更日期                        *
         * ───────────────────────────────────── *
         * V1.0     Boiling       初版                $time$                          *
         *                                                                            *
         * Copyright (c) 2018 Lir Corporation. All rights reserved.                   *
         *┌────────────────────────────────────┐*
         *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．      │*
         *│　版权所有：********有限公司　　　　　　　　　　　　　　                │*
         *└────────────────────────────────────┘*
         ******************************************************************************/

            StringBuilder sb = new StringBuilder();
            sb.Append("/******************************************************************************");
            sb.Append(Environment.NewLine);
            sb.Append(" * 命名空间: $rootnamespace$                                                           *");
            sb.Append(Environment.NewLine);
            sb.Append(" * 类 名： $safeitemrootname$                                                   *");
            sb.Append(Environment.NewLine);
            sb.Append(" *                                                                            *");
            sb.Append(Environment.NewLine);
            sb.Append(" * Ver      负责人        变更内容            变更日期                        *");
            sb.Append(Environment.NewLine);
            sb.Append(" * ───────────────────────────────────── *");
            sb.Append(Environment.NewLine);
            sb.Append(" * V1.0     Boiling     初版                $time$                            *");
            sb.Append(Environment.NewLine);
            sb.Append(" *                                                                            *");
            sb.Append(Environment.NewLine);
            sb.Append(" * Copyright (c) 2018 Lir Corporation. All rights reserved.                   *");
            sb.Append(Environment.NewLine);
            sb.Append(" *┌────────────────────────────────────┐*");
            sb.Append(Environment.NewLine);
            sb.Append(" *│　此技术信息为本人机密信息，未经本人书面同意禁止向第三方披露．          │*");
            sb.Append(Environment.NewLine);
            sb.Append(" *│　版权所有：BoilingBlood　　　　　　　　　　　　                        │*");
            sb.Append(Environment.NewLine);
            sb.Append(" *└────────────────────────────────────┘*");
            sb.Append(Environment.NewLine);
            sb.Append(" ******************************************************************************/");
            sb.Append(Environment.NewLine);
            return sb;
        }

        public StringBuilder IncludeHeadFrame()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("using System.IO;");
            //sb.Append(Environment.NewLine);
            //sb.Append("using Protocol.Client.C2G;");
            //sb.Append(Environment.NewLine);
            //sb.Append("using Protocol.Gate.G2C;");
            //sb.Append(Environment.NewLine);
            //sb.Append("using Engine.Foundation;");
            //sb.Append(Environment.NewLine);
            //sb.Append("using GenerateCodeLib;");
            //sb.Append(Environment.NewLine);
            //sb.Append("using CryptoLib;");
            //sb.Append(Environment.NewLine);
            return sb;
        }

        public StringBuilder NameSpaceFrame(string nameSpace, StringBuilder classBody)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("namespace ");
            sb.Append(nameSpace);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(classBody.ToString());
            sb.Append(Environment.NewLine);
            sb.Append("}");
            return sb;
        }

        public StringBuilder ClassBodyFrame(string className, List<StringBuilder> attrs=null, List<StringBuilder> methods=null, int spaceCount = 1)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SetSpace(spaceCount));
            sb.Append("public ");
            sb.Append(className);
            sb.Append(Environment.NewLine);
            sb.Append(SetSpace(spaceCount));
            sb.Append("{");
            sb.Append(Environment.NewLine);
            if (attrs!=null)
            {
                foreach (var item in attrs)
                {
                    sb.Append(item.ToString());
                }
            }
            if (methods != null)
            {
                foreach (var item in methods)
                {
                    sb.Append(item.ToString());
                }
            }
            sb.Append(SetSpace(spaceCount));
            sb.Append("}");
            return sb;
        }

        public StringBuilder ClassAttrFrame(string attrType, string attrName, int spaceCount = 2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SetSpace(spaceCount));
            sb.Append(attrType);
            sb.Append(" ");
            sb.Append(attrName);
            sb.Append(";");
            sb.Append(Environment.NewLine);
            return sb;
        }

        public StringBuilder ClassMethodFrame(string methodType, string methodName, List<StringBuilder> methodValue, int spaceCount = 2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SetSpace(spaceCount));
            sb.Append("public ");
            sb.Append(methodType);
            sb.Append(" ");
            sb.Append(methodName);
            sb.Append(Environment.NewLine);
            sb.Append(SetSpace(spaceCount));
            sb.Append("{");
            sb.Append(Environment.NewLine);
            foreach (var item in methodValue)
            {
                sb.Append(SetSpace(1));
                sb.Append(item.ToString());
            }
            sb.Append(SetSpace(spaceCount));
            sb.Append("}");
            sb.Append(Environment.NewLine);
            return sb;
        }
    }
}
