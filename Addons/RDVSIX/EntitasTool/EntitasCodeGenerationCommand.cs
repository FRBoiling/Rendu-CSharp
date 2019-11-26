using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;
using Rd.Logging;
using System.Runtime.InteropServices;

namespace RDVSIX
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class EntitasCodeGenerationCommand
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(EntitasCodeGenerationCommand).FullName);
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0101;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d4e7fc26-fd82-4f25-a6c7-7bb1261ce1e3");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitasCodeGenerationCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private EntitasCodeGenerationCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            VISXLogger.Inst.Init(package);

            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);

        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static EntitasCodeGenerationCommand Instance
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
            // Switch to the main thread - the call to AddCommand in EntitasCodeGenerationCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new EntitasCodeGenerationCommand(package, commandService);
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
            //var task =this.ServiceProvider.GetServiceAsync(typeof(DTE));
            //Assumes.Present(task);
            //DTE dte = (DTE)(task.Result);
            //if (dte.Solution != null)
            //{
            //}
            //else
            //{
            //    _logger.Info($"11111111111111111----{dte.FileName}");
            //    return;
            //}

            //IVsMonitorSelection monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));

            //monitorSelection.GetCurrentSelection(out var hierarchyPtr, out var prjItemId, out var mis, out var selectionContainerPtr);

            //IVsHierarchy selectedHierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;

            //if (selectedHierarchy != null)
            //{
            //    ErrorHandler.ThrowOnFailure(selectedHierarchy.GetProperty(prjItemId, (int)__VSHPROPID.VSHPROPID_ExtObject, out var prjItemObject));
            //    ProjectItem selectedPrjItem = (ProjectItem)prjItemObject;
            //    _logger.Info($"11111111111111111----{selectedPrjItem.Name}");
            //}


            //Get an instance of the currently running Visual Studio IDE.
            //DTE2 dte2;
            //dte2 = (DTE2)Marshal.GetActiveObject("VisualStudio.DTE.16.0");
            //Solution4 solution = (Solution4)dte2.Solution;

            //var dte = ServiceProvider.GetType();
            //var dte1 = dte as DTE2;
            //var file = dte1.FileName;
            //var doc = dte1.ActiveDocument;
            //var item = doc.ProjectItem;
            //var filename = item.FileNames[0];

            //string componentsDllPath = "../Bin";
            //string message = $"Generator success!";
            //var result = RdDllLoad.CheckFileExist(componentsDllPath,out var fileInfo);
            //switch (result)
            //{
            //    case RdDllLoad.ErrorCode.Success:
            //        var contextsMigration = new RdComponentsMigration();
            //        var migrationFiles = contextsMigration.Migrate(componentsDllPath);
            //        MigrationUtils.WriteFiles(migrationFiles);
            //        break;
            //    case RdDllLoad.ErrorCode.DLLError:
            //        if (fileInfo != null)
            //        {
            //            message = $"can not find the file: {fileInfo.FullName}";
            //        }
            //        break;
            //    case RdDllLoad.ErrorCode.PDBError:
            //        if (fileInfo != null)
            //        {
            //            message = $"can not find the file: {fileInfo.FullName}";
            //        }
            //        break;
            //    default:
            //        break;
            //}

            //switch (result)
            //{
            //    case RdDllLoad.ErrorCode.Success:
            //        _logger.Info(message);
            //        break;
            //    case RdDllLoad.ErrorCode.DLLError:
            //        _logger.Error(message);
            //        break;
            //    case RdDllLoad.ErrorCode.PDBError:
            //        _logger.Error(message);
            //        break;
            //    default:
            //        break;
            //}
            IVsHierarchy hierarchy = GetCurrentHierarchy(out var projectItemId);
            if (hierarchy == null) return;
            var selectedItem = hierarchy.GetSelectedItem(projectItemId);

        }


        public IVsHierarchy GetCurrentHierarchy(out uint projectItemId)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            IntPtr hierarchyPtr, selectionContainerPtr;

            IVsMultiItemSelect mis;

            IVsMonitorSelection monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));

            monitorSelection.GetCurrentSelection(out hierarchyPtr, out projectItemId, out mis, out selectionContainerPtr);

            return Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
        }

    }
}
