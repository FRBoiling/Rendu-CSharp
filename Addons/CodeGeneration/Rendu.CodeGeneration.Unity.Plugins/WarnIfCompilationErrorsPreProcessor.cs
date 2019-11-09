using System;
using System.Reflection;
using Rd.CodeGeneration;
using UnityEditor;

namespace Rendu.CodeGeneration.Unity.Plugins
{
    public class WarnIfCompilationErrorsPreProcessor : IPreProcessor
    {
        public string name
        {
            get
            {
                return "Warn If Compilation Errors";
            }
        }

        public int priority
        {
            get
            {
                return -5;
            }
        }

        public bool runInDryMode
        {
            get
            {
                return true;
            }
        }

        public void PreProcess()
        {
            string str = (string)null;
            if (EditorApplication.isCompiling)
                str = "Cannot generate because Unity is still compiling. Please wait...";
            Assembly assembly = typeof(Editor).Assembly;
            System.Type type = assembly.GetType("UnityEditorInternal.LogEntries") ?? assembly.GetType("UnityEditor.LogEntries");
            type.GetMethod("Clear").Invoke(new object(), (object[])null);
            if ((int)type.GetMethod("GetCount").Invoke(new object(), (object[])null) != 0)
                str = "There are compilation errors! Please fix all errors first.";
            if (str != null)
                throw new Exception(str + "\n\nYou can disable this warning by removing '" + this.name + "' from the Pre Processors.");
        }
    }
}