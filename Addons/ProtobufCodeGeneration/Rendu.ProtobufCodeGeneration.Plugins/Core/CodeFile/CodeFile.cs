using System;
using System.Collections.Generic;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class CodeFile:ProtoBuff
    {
        public readonly Dictionary<string, string> IdNameDic = new Dictionary<string, string>();
        
        public bool AddDataStructure(string structName, string msgId = null)
        {
            if (StructNameList.Contains(structName))
            {
                throw  new Exception( $"file {Name} got an wrong struct name : {structName} ");
            }

            if (!string.IsNullOrEmpty(msgId))
            {
                if (IdNameDic.TryGetValue(msgId, out var name))
                {
                    throw new Exception($"file {Name} got an wrong msg id : {msgId}");
                }

                IdNameDic.Add(msgId, structName);
            }

            StructNameList.Add(structName);
            return true;
        }
        

    }
}