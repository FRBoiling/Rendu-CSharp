using System.Linq;
using System.Text.RegularExpressions;
using Entitas.Migration.Migration;

namespace Entitas.Migration.Migrations
{
    public class M0220 : IMigration
    {
        private const string TRIGGER_PATTERN = @"public\s*IMatcher\s*trigger\s*\{\s*get\s*\{\s*return\s*(?<matcher>.*?)\s*;\s*\}\s*\}";
        private const string EVENT_TYPE_PATTERN = @"^\s*public\s*GroupEventType\s*eventType\s*\{\s*get\s*\{\s*return\s*GroupEventType\.(?<eventType>\w*)\s*;\s*\}\s*\}";

        private const string TRIGGER_REPLACEMENT_FORMAT = @"public TriggerOnEvent trigger {{ get {{ return {0}.{1}(); }} }}";

        public string version => "0.22.0";

        public string workingDirectory => "where all systems are located";

        public string description => "Migrates IReactiveSystem to combine trigger and eventTypes to TriggerOnEvent";

        public MigrationFile[] Migrate(string path)
        {
            var files = MigrationUtils.GetFiles(path)
                .Where(file => Regex.IsMatch(file.fileContent, TRIGGER_PATTERN))
                .ToArray();

            for (var i = 0; i < files.Length; i++)
            {
                var file = files[i];

                var eventTypeMatch = Regex.Match(file.fileContent, EVENT_TYPE_PATTERN, RegexOptions.Multiline);
                var eventType = eventTypeMatch.Groups["eventType"].Value;
                file.fileContent = Regex.Replace(file.fileContent, EVENT_TYPE_PATTERN, string.Empty, RegexOptions.Multiline);

                file.fileContent = Regex.Replace(file.fileContent, TRIGGER_PATTERN,
                    match => string.Format(TRIGGER_REPLACEMENT_FORMAT, match.Groups["matcher"].Value, eventType),
                    RegexOptions.Multiline);
            }

            return files;
        }
    }
}