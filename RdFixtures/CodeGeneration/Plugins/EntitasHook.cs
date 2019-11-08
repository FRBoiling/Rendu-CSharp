using System;
using System.Linq;
using Entitas;
using Rd.Analytics;
using Rd.CodeGenerator;
using Rd.Utils;

namespace Rd.Plugins
{
    public class EntitasHook : CodeGeneratorTrackingHook
    {
        protected override string name => "entitas";

        protected override TrackingData GetData()
        {
            var types = AppDomain.CurrentDomain.GetAllTypes();
            return new UserTrackingData
            {
                {
                    "x", "v:" + EntitasResources.GetVersion() +
                         ",e:" + (types.Any(type => type.FullName == "Rd.CodeGeneration.CodeGenerator.CLI.Program") ? "s" : "u") +
                         ",p:" + (types.Any(type => type.FullName == "DesperateDevs.Roslyn.Rd.CodeGeneration.Rd.Plugins.PluginUtil") ? "1" : "0") +
                         ",f:" + _files.Length +
                         ",cp:" + _files.Count(f => f.fileName.EndsWith("Component.cs", StringComparison.OrdinalIgnoreCase)) +
                         ",cx:" + _files.Count(f => f.fileName.EndsWith("Context.cs", StringComparison.OrdinalIgnoreCase)) +
                         ",l:" + _files.Select(file => file.fileContent.ToUnixLineEndings()).Sum(content => content.Split('\n').Length)
                }
            };
        }
    }
}