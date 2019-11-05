using System.Collections.Generic;
using System.Linq;
using DesperateDevs.Utils;

namespace DesperateDevs.CodeGeneration
{
    public class CodeGeneratorData : Dictionary<string, object>
    {
        public CodeGeneratorData()
        {
        }

        public CodeGeneratorData(CodeGeneratorData data)
            : base(data)
        {
        }

        public string ReplacePlaceholders(string template)
        {
            return this.Aggregate(template, (current, kv) => ReplacePlaceholders(current, kv.Key, kv.Value.ToString()));
        }

        public string ReplacePlaceholders(string template, string key, string value)
        {
            var oldValue1 = string.Format("${{{0}}}", key.UppercaseFirst());
            var oldValue2 = string.Format("${{{0}}}", key.LowercaseFirst());
            var newValue1 = value.UppercaseFirst();
            var newValue2 = value.LowercaseFirst();
            template = template.Replace(oldValue1, newValue1);
            template = template.Replace(oldValue2, newValue2);
            return template;
        }
    }
}