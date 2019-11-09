using System.Linq;
using System.Text.RegularExpressions;

namespace Rd.Migration.Migrations
{
    public class M0180 : IMigration
    {
        private const string METHOD_END_PATTERN = @"(\s|.)*?\}";
        private const string TRIGGER_PATTERN = @"public\s*IMatcher\s*GetTriggeringMatcher\s*\(\s*\)\s*\{\s*";
        private const string TRIGGER_END_PATTERN = TRIGGER_PATTERN + METHOD_END_PATTERN;
        private const string TRIGGER_REPLACEMENT = "public IMatcher trigger { get { ";

        private const string EVENT_TYPE_PATTERN = @"public\s*GroupEventType\s*GetEventType\s*\(\s*\)\s*\{\s*";
        private const string EVENT_TYPE_PATTERN_END = EVENT_TYPE_PATTERN + METHOD_END_PATTERN;
        private const string EVENT_TYPE_REPLACEMENT = "public GroupEventType eventType { get { ";

        public string version => "0.18.0";

        public string workingDirectory => "where all systems are located";

        public string description => "Migrates IReactiveSystem GetXyz methods to getters";

        public MigrationFile[] Migrate(string path)
        {
            var files = MigrationUtils.GetFiles(path)
                .Where(file => Regex.IsMatch(file.fileContent, TRIGGER_PATTERN) || Regex.IsMatch(file.fileContent, EVENT_TYPE_PATTERN))
                .ToArray();

            for (var i = 0; i < files.Length; i++)
            {
                var file = files[i];
                file.fileContent = Regex.Replace(file.fileContent, TRIGGER_END_PATTERN, match => match.Value + " }", RegexOptions.Multiline);
                file.fileContent = Regex.Replace(file.fileContent, EVENT_TYPE_PATTERN_END, match => match.Value + " }", RegexOptions.Multiline);
                file.fileContent = Regex.Replace(file.fileContent, TRIGGER_PATTERN, TRIGGER_REPLACEMENT, RegexOptions.Multiline);
                file.fileContent = Regex.Replace(file.fileContent, EVENT_TYPE_PATTERN, EVENT_TYPE_REPLACEMENT, RegexOptions.Multiline);
            }

            return files;
        }
    }
}