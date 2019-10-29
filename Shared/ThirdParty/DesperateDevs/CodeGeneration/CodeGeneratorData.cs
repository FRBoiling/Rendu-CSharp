using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesperateDevs.CodeGeneration
{
    public class CodeGeneratorData : Dictionary<string, object>
    {
        public CodeGeneratorData()
        {
        }

        public CodeGeneratorData(CodeGeneratorData data)
            : base((IDictionary<string, object>) data)
        {
        }

        public string ReplacePlaceholders(string template)
        {
            return this.Aggregate<KeyValuePair<string, object>, string>(template, (Func<string, KeyValuePair<string, object>, string>) ((current, kv) => this.ReplacePlaceholders(current, kv.Key, kv.Value.ToString())));
        }

        public string ReplacePlaceholders(string template, string key, string value)
        {
            string oldValue1 = string.Format("${{{0}}}", (object) key.UppercaseFirst());
            string oldValue2 = string.Format("${{{0}}}", (object) key.LowercaseFirst());
            string newValue1 = value.UppercaseFirst();
            string newValue2 = value.LowercaseFirst();
            template = template.Replace(oldValue1, newValue1);
            template = template.Replace(oldValue2, newValue2);
            return template;
        }
    }
}