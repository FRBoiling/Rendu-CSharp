using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Rd.Logging;
using Rd.Utils;
using Rendu.ProtobufCodeGeneration.Plugins;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Task = System.Threading.Tasks.Task;

namespace RDVSIX
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ProtocolCodeGenerationCommand
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(ProtocolCodeGenerationCommand).FullName);
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0102;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d4e7fc26-fd82-4f25-a6c7-7bb1261ce1e3");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolCodeGenerationCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ProtocolCodeGenerationCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ProtocolCodeGenerationCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ProtocolCodeGenerationCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new ProtocolCodeGenerationCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            var startTime = DateTime.Now;
            Dispatcher.CurrentDispatcher.VerifyAccess();
            ThreadHelper.ThrowIfNotOnUIThread();

            VISXLogger.Inst.Init(package);
            VISXLogger.Inst.Clear();

            IVsMonitorSelection monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));
            monitorSelection.GetCurrentSelection(out var hierarchyPtr, out var projectItemId, out var mis, out var selectionContainerPtr);

            var hierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
            if (hierarchy == null)
            {
                _logger.Error($"hierarchy is null");
                return;
            }
            _logger.Info(@"begin to execute protocol code generator");

            var selectedProject = hierarchy.GetSelectedProject(projectItemId);

            var assemblyName = (string)selectedProject.Properties.Item("AssemblyName").Value;
            var config = selectedProject.ConfigurationManager.ActiveConfiguration;

            var outPutPath = string.Empty;
            var selectedProjectDir = string.Empty;
            if (Path.GetExtension(selectedProject.FullName).Equals(".csproj", StringComparison.OrdinalIgnoreCase))//Path.GetExtension获取扩展名，OrdinalIgnoreCase 使用序号排序规则并忽略被比较字符串的大小写，对字符串进行比较。 
            {
                var output = (string)selectedProject.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value;
                selectedProjectDir = Path.GetDirectoryName(selectedProject.FullName);
                outPutPath = Path.Combine(selectedProjectDir, output);
            }
            if (string.IsNullOrEmpty(selectedProjectDir))
            {
                _logger.Error($"selectedProjectDir is null or empty");
                return;
            }

            if (string.IsNullOrEmpty(outPutPath))
            {
                _logger.Error($"outputpath is null or empty");
                return;
            }

            _logger.Info($"begin to build project: {selectedProject.FullName}");
            _logger.Info($"please wait ...");

            try
            {
                ////调用外部程序protoc.exe
                //CmdProcessUtil.RunCmdProcess($@"dotnet.exe", $@"{FolderManager.Inst.CurrentDirectory}\{ConstData.PROTOCOLGENERATOR} {FolderManager.Inst.CodeFilesDir}", FolderManager.Inst.CurrentDirectory);

                FolderManager.Inst.Init(Environment.CurrentDirectory);

                var inputDir = selectedProjectDir;
                //            var inputDir = @"D:\GitHub\EcsProject\Protocol\Code";
                if (!FolderManager.Inst.InitWorkFileDir(inputDir))
                {
                    throw new Exception($@"generator fail ,check directory {inputDir}");
                }
                GeneratorManager.Inst.Run();
                _logger.Info("generator success!");
                _logger.Info($"已用时间:{(DateTime.Now - startTime).ToString()}");
                _logger.Info("========== 已完成 ==========");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                //_logger.Error(ex.StackTrace);
            }
        }
    }
}
