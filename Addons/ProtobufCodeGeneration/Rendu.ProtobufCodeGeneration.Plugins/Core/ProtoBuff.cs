using System.Collections.Generic;
using System.Text;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class ProtoBuff
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Syntax { get; private set; }
        public string Package { get; private set; }
        public string Option { get; private set; }
        
        public readonly List<string> ImportList = new List<string>();
        
        public readonly List<string> StructNameList = new List<string>();
        
        public readonly StringBuilder ProtoBuffContext = new StringBuilder();
        
        public void SetFileName(string fileName)
        {
            Name = fileName.Replace(".code",".proto");
        }
                            
        public bool SetPackage(string package)
        {
            Package = package;
            return true;
        }

        public bool SetSyntax(string syntax)
        {
            Syntax = syntax;
            return true;
        }

        public bool SetOption(string option)
        {
            Option = option;
            return true;
        }
        
        public bool AddImport(string importName)
        {
            if (ImportList.Contains(importName))
            {
                return false;
            }

            ImportList.Add(importName);
            return true;
        }
        
        public void SetProtoBuffData(StringBuilder protoBuffContext)
        {
            ProtoBuffContext.Append(protoBuffContext);
        }
    }
}