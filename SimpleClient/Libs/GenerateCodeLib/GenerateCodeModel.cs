using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateCodeLib
{
    public class GenerateCodeModel
    {
        /// <summary>
        /// msg过滤
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool CheckLoginMsg(string strName)
        {
            switch (strName)
            {
                case "Api":
                    return false;
                //    //request
                //    //case "MSG_CG_HEARTBEAT":
                //    //    return false;
                //    //case "MSG_CG_MAP_LOADING_DONE":
                //    //    return false;
                case "MSG_G2C_ENCRYPTKEY":
                    return false;
                //    //case "MSG_CG_USER_LOGIN":
                //    //    return false;
                //    //case "MSG_CG_TO_ZONE":
                //    //    return false;


                //    //response
                //    case "MSG_GC_HEARTBEAT":
                //        return false;
                //    case "MSG_GC_TIME_SYNC":
                //        return false;
                //    case "MSG_GC_BLOWFISHKEY":
                //        return false;
                //    case "MSG_GC_USER_LOGIN":
                //        return false;
                //    case "MSG_GC_ENTER_WORLD":
                //        return false;
                //    case "MSG_GC_ENTER_ZONE":
                //        return false;
                //    case "MSG_GC_MAP_LOADING_DONE":
                //        return false;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GenerateCode(Dictionary<string, Type> keys)
        {
            StringBuilder sb = CodeComments();
            sb.Append(IncludeHeadStr());

            string strClassCode = ClassBodyStr(keys);
            string classFrameStr = ClassFrameStr(strClassCode);
            string nameSpaceStr = NameSpaceFrameStr(classFrameStr);

            sb.Append(nameSpaceStr);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// 类文件头部说明注释
        /// </summary>
        /// <returns></returns>
        public static StringBuilder CodeComments()
        {
         /******************************************************************************
          * 命名空间: $rootnamespace$                                                  *
          * 类 名： $safeitemrootname$                                                 *
          *                                                                            *
          * Ver      负责人        变更内容            变更日期                        *
          * ───────────────────────────────────── *
          * V1.0     shaojinbo     初版                $time$                          *
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
            sb.Append(" * 命名空间: ClientLib                                                        *");
            sb.Append(Environment.NewLine);
            sb.Append(" * 类 名：GateServer                                                          *");
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

        /// <summary>
        /// using头文件代码
        /// </summary>
        /// <returns></returns>
        static StringBuilder IncludeHeadStr()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System.IO;");
            sb.Append(Environment.NewLine);
            sb.Append("using Message.Client.Gate.Protocol.CG;");
            sb.Append(Environment.NewLine);
            sb.Append("using Message.Gate.Client.Protocol.GC;");
            sb.Append(Environment.NewLine);
            sb.Append("using Engine.Foundation;");
            sb.Append(Environment.NewLine);
            sb.Append("using GenerateCodeLib;");
            sb.Append(Environment.NewLine);
            sb.Append("using CryptoLib;");
            sb.Append(Environment.NewLine);
            return sb;
        }

        /// <summary>
        /// namespace框架
        /// </summary>
        /// <param name="classFrame"></param>
        /// <returns></returns>
        static string NameSpaceFrameStr(string classFrame)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("namespace ClientLib");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(classFrame);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// classname框架
        /// </summary>
        /// <param name="classMembers">类成员代码</param>
        /// <returns></returns>
        static string ClassFrameStr(string classMembers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public partial class GateServer");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(classMembers);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// 类内部代码
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private static string ClassBodyStr(Dictionary<string, Type> keys)
        {
            StringBuilder sbClassCode = new StringBuilder();
            StringBuilder sbBindStr = new StringBuilder();
            StringBuilder sbRouteInitStr = new StringBuilder();
            StringBuilder sbRouteNewStr = new StringBuilder();
            StringBuilder sbRouteGetStr = new StringBuilder();
            StringBuilder sbRouteTypeStr = new StringBuilder();
            StringBuilder sbRouteSendStr = new StringBuilder();

            foreach (var item in keys)
            {
                if (item.Key.Contains("Message") && !item.Key.Contains("+"))
                {
                    if (CheckLoginMsg(item.Value.Name))
                    {
                        string classMemberStr1 = ClassMemberCodeStr(item.Value.Name);
                        sbClassCode.Append(classMemberStr1);
                        sbClassCode.Append(Environment.NewLine);

                        if (item.Key.Contains("MSG_C2G"))
                        {
                            string routeInitCaseStr = RouteInitCaseStr(item.Value.Name);
                            sbRouteInitStr.Append(routeInitCaseStr);
                            sbRouteInitStr.Append(Environment.NewLine);

                            string routeNewCaseStr = RouteNewCaseStr(item.Value.Name);
                            sbRouteNewStr.Append(routeNewCaseStr);
                            sbRouteNewStr.Append(Environment.NewLine);

                            string routeGetCaseStr = RouteGetCaseStr(item.Value.Name);
                            sbRouteGetStr.Append(routeGetCaseStr);
                            sbRouteGetStr.Append(Environment.NewLine);

                            string routeTypeCaseStr = RouteTypeCaseStr(item.Value.Name);
                            sbRouteTypeStr.Append(routeTypeCaseStr);
                            sbRouteTypeStr.Append(Environment.NewLine);

                            string routeSendCaseStr = RouteSendCaseStr(item.Value.Name);
                            sbRouteSendStr.Append(routeSendCaseStr);
                            sbRouteSendStr.Append(Environment.NewLine);


                        }
                        else
                        {
                            string bindString = BindStr(item.Value.Name);
                            sbBindStr.Append(bindString);
                            sbBindStr.Append(Environment.NewLine);
                        }
                    }
                }
            }


            string tempStr = sbRouteInitStr.ToString();
            tempStr = RouteFunc(RountType.Init, tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            tempStr = sbRouteNewStr.ToString();
            tempStr = RouteFunc(RountType.New, tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            tempStr = sbRouteGetStr.ToString();
            tempStr = RouteFunc(RountType.Get, tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            tempStr = sbRouteTypeStr.ToString();
            tempStr = RouteFunc(RountType.Type, tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            tempStr = sbBindStr.ToString();
            tempStr = BindResponseFunc(tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            tempStr = sbRouteSendStr.ToString();
            tempStr = RouteSendFunc(tempStr);
            sbClassCode.Append(tempStr);
            sbClassCode.Append(Environment.NewLine);

            string strClassCode = sbClassCode.ToString();
            return strClassCode;
        }

        /// <summary>
        /// 类成员代码1
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static string ClassMemberCodeStr(string key)
        {

            StringBuilder sb = new StringBuilder();
            if (key.Contains("MSG_C2G"))
            {
                sb.Append(DefineMsg(key));
                sb.Append(Environment.NewLine);
                sb.Append(InitMsgFunc(key));
                sb.Append(Environment.NewLine);
                sb.Append(GetMsgFunc(key));
                sb.Append(Environment.NewLine);
                sb.Append(NewMsgFunc(key));
                sb.Append(Environment.NewLine);
            }
            sb.Append(ResponseRecvFunc(key));
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// define 代码
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string DefineMsg(string key)
        {
            StringBuilder sb = new StringBuilder();
            string initClass = string.Format("{0} msg_{0};", key);
            sb.Append(initClass);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// init 函数框架
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string InitMsgFunc(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public object Init_{0}()", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            tempString = string.Format("msg_{0} = new {0}();", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return msg_{0};", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// get函数框架
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetMsgFunc(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public object Get_{0}()", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            tempString = string.Format("return msg_{0};", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// new 函数框架
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string NewMsgFunc(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public object New_{0}()", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            tempString = string.Format("return msg_{0};", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// OnResponse 流解析函数框架
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string ResponseRecvFunc(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public void OnResponse_{0}(MemoryStream stream,int uid =0)", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            tempString = string.Format("{0} {0} = ProtoBuf.Serializer.Deserialize<{0}>(stream);", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("Parser.Parse({0});", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// 路由类型
        /// </summary>
        struct RountType
        {
            public const string Init = "Init";
            public const string Get = "Get";
            public const string New = "New";
            public const string Type = "Type";
        }

        /// <summary>
        /// Route函数框架
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteFunc(string rountType, string caseString)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public object Route{0}(string className)", rountType);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append("switch (className)");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(caseString);
            sb.Append(Environment.NewLine);
            sb.Append("default:");
            sb.Append(Environment.NewLine);
            sb.Append("return null;");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteSend函数主体
        /// </summary>
        /// <param name="caseString"></param>
        /// <returns></returns>
        private static string RouteSendFunc(string caseString)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("public bool RouteSend(string className,object msg)");
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append("switch (className)");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(caseString);
            sb.Append(Environment.NewLine);
            sb.Append("default:");
            sb.Append(Environment.NewLine);
            sb.Append("return false;");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// BindResponse函数主体
        /// </summary>
        /// <param name="bindString"></param>
        /// <returns></returns>
        private static string BindResponseFunc(string bindString)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = "public void BindResponse()";
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append(bindString);
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        ///  BindResponse函数内部执行代码
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string BindStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("AddProcesser(Id<{0}>.Value, OnResponse_{0});", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteInit内部Case分解
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteInitCaseStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("case \"{0}\":", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return Init_{0}();", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteGet内部Case分解
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteGetCaseStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("case \"{0}\":", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return Get_{0}();", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteNew内部Case分解
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteNewCaseStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("case \"{0}\":", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return New_{0}();", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteType内部Case分解
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteTypeCaseStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("case \"{0}\":", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return typeof({0});", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }

        /// <summary>
        /// RouteSend内部Case分解
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string RouteSendCaseStr(string key)
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Format("case \"{0}\":", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            tempString = string.Format("return Send(({0})msg);", key);
            sb.Append(tempString);
            sb.Append(Environment.NewLine);
            string code = sb.ToString();
            return code;
        }



    }
}
