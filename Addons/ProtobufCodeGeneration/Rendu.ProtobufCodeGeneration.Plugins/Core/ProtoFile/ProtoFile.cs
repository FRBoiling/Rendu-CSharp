///************************************************************************ 
// * 项目名称 :  ProtocolGenerator.ProtoBuf       
// * 类 名 称 :  ProtoBufGenerator 
// * 类 描 述 :  生成.proto文件
// * 版 本 号 :  v1.0.0.0  
// * 说    明 :      
// * 作    者 :  FReedom 
// * 创建时间 :  2018/4/20 星期五 18:49:43 
// * 更新时间 :  2018/4/20 星期五 18:49:43 
//************************************************************************ 
// * Copyright @ BoilingBlood 2018. All rights reserved. 
//************************************************************************/
//

using Rd.Utils;
using System;
using System.Collections.Generic;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class ProtoFile:ProtoBuff
    {
        /// <summary>
        /// key structname value codefilename
        /// </summary>
        private readonly Dictionary<string,string> StructNameDic = new Dictionary<string, string>();
        /// <summary>
        /// key msgId value codefilename
        /// </summary>
        private readonly Dictionary<string,string> MsgIdDic = new Dictionary<string, string>();
        
        public bool LoadCodeFile(CodeFile codeFile)
        {
            if (!LoadStructName(codeFile.StructNameList,codeFile.Name))
            {
                return false;
            }

            if (!LoadMsgId(codeFile.IdNameDic,codeFile.Name))
            {
                return false;
            }

            FullName = codeFile.FullName.Replace("Code","Proto").Replace(".code",".proto");
            SetProtoBuffData(codeFile.ProtoBuffContext);
            return true;
        }

        private bool LoadStructName(List<string> nameList, string codeFileName)
        {
            foreach (var name in nameList)
            {
                if (StructNameDic.TryGetValue(name, out var filename))
                {
                    throw new Exception($" msg name {name} repeated in files {filename} and {codeFileName}");
                }
                StructNameDic.Add(name,codeFileName);
            }
            return true;
        }

        private bool LoadMsgId(Dictionary<string, string> idDic, string codeFileName)
        {
            foreach (var msg in idDic)
            {
                if (MsgIdDic.TryGetValue(msg.Key,out var filename))
                {
                    throw new Exception($" msg id {msg.Key} repeated in files {filename} and {codeFileName}");
                }
                MsgIdDic.Add(msg.Key,codeFileName);
            }
            return true;
        }

        public bool GenerateProtoFile()
        {
            return FileUtil.WriteToFile(ProtoBuffContext, FullName);
        }
        
    }
}
