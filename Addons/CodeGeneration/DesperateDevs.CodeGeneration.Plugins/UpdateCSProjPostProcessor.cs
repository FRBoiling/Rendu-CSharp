using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesperateDevs.CodeGeneration.Plugins
{
  public class UpdateCSProjPostProcessor : IPostProcessor, ICodeGenerationPlugin, IConfigurable
  {
    private readonly ProjectPathConfig _projectPathConfig = new ProjectPathConfig();
    private readonly TargetDirectoryConfig _targetDirectoryConfig = new TargetDirectoryConfig();

    public string name
    {
      get
      {
        return "Update .csproj";
      }
    }

    public int priority
    {
      get
      {
        return 96;
      }
    }

    public bool runInDryMode
    {
      get
      {
        return false;
      }
    }

    public Dictionary<string, string> defaultProperties
    {
      get
      {
        return this._projectPathConfig.defaultProperties.Merge<string, string>(new Dictionary<string, string>[1]
        {
          this._targetDirectoryConfig.defaultProperties
        });
      }
    }

    public void Configure(Preferences preferences)
    {
      this._projectPathConfig.Configure(preferences);
      this._targetDirectoryConfig.Configure(preferences);
    }

    public CodeGenFile[] PostProcess(CodeGenFile[] files)
    {
      File.WriteAllText(this._projectPathConfig.projectPath, this.addGeneratedEntries(this.removeExistingGeneratedEntries(File.ReadAllText(this._projectPathConfig.projectPath)), files));
      return files;
    }

    private string removeExistingGeneratedEntries(string project)
    {
      string pattern = "\\s*<Compile Include=\"" + this._targetDirectoryConfig.targetDirectory.Replace("/", "\\").Replace("\\", "\\\\") + ".* \\/>";
      project = Regex.Replace(project, pattern, string.Empty);
      project = Regex.Replace(project, "\\s*<ItemGroup>\\s*<\\/ItemGroup>", string.Empty);
      return project;
    }

    private string addGeneratedEntries(string project, CodeGenFile[] files)
    {
      string entryTemplate = "    <Compile Include=\"" + this._targetDirectoryConfig.targetDirectory.Replace("/", "\\") + "\\{0}\" />";
      string replacement = string.Format("</ItemGroup>\n  <ItemGroup>\n{0}\n  </ItemGroup>", (object) string.Join("\r\n", ((IEnumerable<CodeGenFile>) files).Select<CodeGenFile, string>((Func<CodeGenFile, string>) (file => string.Format(entryTemplate, (object) file.fileName.Replace("/", "\\")))).ToArray<string>()));
      return new Regex("<\\/ItemGroup>").Replace(project, replacement, 1);
    }
  }
}