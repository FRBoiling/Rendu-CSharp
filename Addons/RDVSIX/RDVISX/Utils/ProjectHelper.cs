using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RDVSIX
{
    public static class ProjectHelper
    {
        public static string GetSelectedProjectDir(this IVsHierarchy hierarchy, uint ItemID)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (hierarchy == null)
                throw new ArgumentNullException("hierarchy");
            ErrorHandler.ThrowOnFailure(hierarchy.GetProperty(
                ItemID, (int)__VSHPROPID.VSHPROPID_ProjectDir, out var prjItemObject));
            string selectedProjectDir = prjItemObject as string;
            return selectedProjectDir;
        }


        public static Project GetSelectedProject(this IVsHierarchy hierarchy, uint ItemID)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (hierarchy == null)
                throw new ArgumentNullException("hierarchy");

            ErrorHandler.ThrowOnFailure(hierarchy.GetProperty(
                ItemID, (int)__VSHPROPID.VSHPROPID_ExtObject, out var prjItemObject));

            Project selectedProject = prjItemObject as Project;
            return selectedProject;
        }

        public static string GetFullOutputDir(this Project project)
        {
            if (Path.GetExtension(project.FullName).Equals(".csproj", StringComparison.OrdinalIgnoreCase))//Path.GetExtension获取扩展名，OrdinalIgnoreCase 使用序号排序规则并忽略被比较字符串的大小写，对字符串进行比较。 
            {
                return Path.Combine(Path.GetDirectoryName(project.FullName), (string)project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value);
            }
            else
            {
                var outputUrlStr = ((object[])project.ConfigurationManager.ActiveConfiguration.OutputGroups.Item("Built").FileURLs).OfType<string>().First();
                var outputUrl = new Uri(outputUrlStr, UriKind.Absolute);
                return Path.GetDirectoryName(outputUrl.LocalPath);
            }
        }
    }
}
