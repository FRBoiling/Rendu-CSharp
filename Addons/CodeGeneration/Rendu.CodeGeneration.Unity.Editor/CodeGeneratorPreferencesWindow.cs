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
            window.Initialize(EditorPrefs.GetString("Rendu.CodeGeneration.Unity.Editor.PropertiesPath", Rd.CodeGenerator.CodeGenerator.defaultPropertiesPath), Preferences.defaultUserPropertiesPath, "Rendu.CodeGeneration.Unity.Editor.CodeGeneratorPreferencesDrawer");
            window.Show();
        }
    }
}