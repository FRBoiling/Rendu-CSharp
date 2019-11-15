using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Rd.CodeGeneration;
using Rd.CodeGenerator;
using Task = System.Threading.Tasks.Task;
using Rd.Logging;
using Rd.Serialization;
using Rd.Utils;

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

        public static Preferences GetPreferences()
        {
//            string propertiesPath = EditorPrefs.GetString("Rendu.CodeGeneration.Unity.Editor.PropertiesPath",Rd.CodeGenerator.CodeGenerator.defaultPropertiesPath);
            string propertiesPath = "";
            return new Preferences(propertiesPath, Preferences.defaultUserPropertiesPath);
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
            ThreadHelper.ThrowIfNotOnUIThread();
            _logger.Debug("Generating...");
            Rd.CodeGenerator.CodeGenerator codeGenerator = CodeGeneratorUtil.CodeGeneratorFromPreferences(GetPreferences());
            float progressOffset = 0.0f;
            codeGenerator.OnProgress += (GeneratorProgress)((title, info, progress) =>
            {
//                if (!EditorUtility.DisplayCancelableProgressBar(title, info, progressOffset + progress / 2f))
//                    return;
//                codeGenerator.Cancel();
            });
            CodeGenFile[] codeGenFileArray1;
            CodeGenFile[] codeGenFileArray2;
            try
            {
//                codeGenFileArray1 = EditorPrefs.GetBool("Rendu.CodeGeneration.Unity.Editor.DryRun", true) ? codeGenerator.DryRun() : new CodeGenFile[0];
                codeGenFileArray1 =  new CodeGenFile[0];
                progressOffset = 0.5f;
                codeGenFileArray2 = codeGenerator.Generate();
            }
            catch (Exception ex)
            {
                codeGenFileArray1 = new CodeGenFile[0];
                codeGenFileArray2 = new CodeGenFile[0];
                // Show a message box to prove we were here
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    ex.Message,
                    "Error",
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }

//            EditorUtility.ClearProgressBar();
            _logger.Debug(("Generated " +
                                (object)((IEnumerable<CodeGenFile>)codeGenFileArray2).Select<CodeGenFile, string>((Func<CodeGenFile, string>)(file => file.fileName))
                                .Distinct<string>().Count<string>() + " files (" + (object)((IEnumerable<CodeGenFile>)codeGenFileArray1)
                                .Select<CodeGenFile, string>((Func<CodeGenFile, string>)(file => file.fileContent.ToUnixLineEndings())).Sum<string>((Func<string, int>)(content =>
                                  content.Split(new char[1]
                                  {
                                        '\n'
                                  }, StringSplitOptions.RemoveEmptyEntries).Length)) + " sloc, " + (object)((IEnumerable<CodeGenFile>)codeGenFileArray2)
                                .Select<CodeGenFile, string>((Func<CodeGenFile, string>)(file => file.fileContent.ToUnixLineEndings()))
                                .Sum<string>((Func<string, int>)(content => content.Split('\n').Length)) + " loc)"));
//            AssetDatabase.Refresh();
        }
    }
}
