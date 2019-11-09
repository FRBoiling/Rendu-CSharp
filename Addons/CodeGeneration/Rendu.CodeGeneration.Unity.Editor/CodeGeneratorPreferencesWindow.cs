using Rd.Serialization;
using UnityEditor;
using UnityEngine;

namespace Rendu.CodeGeneration.Unity.Editor
{
    public class CodeGeneratorPreferencesWindow : Rendu.Unity.Editor.PreferencesWindow
    {
        [MenuItem("Tools/Jenny/Preferences... #%j", false, 1)]
        public static void OpenPreferences()
        {
            CodeGeneratorPreferencesWindow window = EditorWindow.GetWindow<CodeGeneratorPreferencesWindow>(true, "Jenny");
            window.minSize = new Vector2(415f, 366f);
            window.Initialize(EditorPrefs.GetString("Rd.CodeGeneration.CodeGenerator.Unity.Editor.PropertiesPath", Rd.CodeGenerator.CodeGenerator.defaultPropertiesPath), Preferences.defaultUserPropertiesPath, "Rd.CodeGeneration.CodeGenerator.Unity.Editor.CodeGeneratorPreferencesDrawer");
            window.Show();
        }
    }
}