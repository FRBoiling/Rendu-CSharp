using DesperateDevs.Serialization;
using UnityEditor;
using UnityEngine;

namespace DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor
{
    public class CodeGeneratorPreferencesWindow : DesperateDevs.Unity.Editor.PreferencesWindow
    {
        [MenuItem("Tools/Jenny/Preferences... #%j", false, 1)]
        public static void OpenPreferences()
        {
            CodeGeneratorPreferencesWindow window = EditorWindow.GetWindow<CodeGeneratorPreferencesWindow>(true, "Jenny");
            window.minSize = new Vector2(415f, 366f);
            window.Initialize(EditorPrefs.GetString("DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor.PropertiesPath", DesperateDevs.CodeGeneration.CodeGenerator.CodeGenerator.defaultPropertiesPath), Preferences.defaultUserPropertiesPath, "DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor.CodeGeneratorPreferencesDrawer");
            window.Show();
        }
    }
}