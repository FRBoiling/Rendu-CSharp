using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Rd.Logging;

namespace RDVSIX
{
    public class VISXLogger
    {
        public static VISXLogger Inst = new VISXLogger();
        private AsyncPackage package;

        private VISXLogger()
        {
            fabl.AddAppender(OnLog);
        }

        public void Init(AsyncPackage package)
        {
            this.package = package;
        }

        public void OnLog(Logger logger, LogLevel logLevel, string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            // Show a message box to prove we were here
            var clickResult = VsShellUtilities.ShowMessageBox(
                 this.package,
                 message,
                 logLevel.ToString(),
                 OLEMSGICON.OLEMSGICON_INFO,
                 OLEMSGBUTTON.OLEMSGBUTTON_OK,
                 OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }

}
