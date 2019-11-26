using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Rd.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RDVSIX
{
    public class VISXLogger
    {
        public static VISXLogger Inst = new VISXLogger();
        private AsyncPackage package;
        DTE2 _dte;

        private VISXLogger()
        {
            fabl.AddAppender(OnLog);
        }

        public void Init(AsyncPackage package)
        {
            this.package = package;
            IVsMonitorSelection monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));
            monitorSelection.GetCurrentSelection(out var hierarchyPtr, out var projectItemId, out var mis, out var selectionContainerPtr);
            var hierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
            if (hierarchy == null)
            {
                return;
            }

            var selectedProject = hierarchy.GetSelectedProject(projectItemId);
            _dte = (DTE2)selectedProject.DTE;
        }

        public void OnLog(Logger logger, LogLevel logLevel, string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();



            // vs"输出"窗口标题
            string winCaption = "输出";

            // 输出窗口中的一个自定义项的标题
            string outTitle = "Rendu插件-消息";

            // 激活输出窗口
            if (_dte.ActiveWindow.Caption != winCaption)
            {
                _dte.Windows.Item(winCaption).Activate();
            }


            // 输出窗口添加一个自定义输出项 激活并输出信息
            EnvDTE.OutputWindowPane webPane = null;


            foreach (EnvDTE.OutputWindowPane item in _dte.ToolWindows.OutputWindow.OutputWindowPanes)
            {
                if (item.Name == outTitle)
                {
                    webPane = item;
                    break;
                }
            }


            // 如果该窗口已有,则继续使用之,否则增加
            if (webPane == null)
            {
                webPane = _dte.ToolWindows.OutputWindow.OutputWindowPanes.Add(outTitle);
            }


            // 清空消息 清空以前
            // if (clear)
            // webPane.Clear();

            // 激活
            webPane.Activate();


            // 输出消息 msg
            webPane.OutputString($"{message}\n");

            //// Show a message box to prove we were here
            //var clickResult = VsShellUtilities.ShowMessageBox(
            //     this.package,
            //     message,
            //     logLevel.ToString(),
            //     OLEMSGICON.OLEMSGICON_INFO,
            //     OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //     OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }

}
