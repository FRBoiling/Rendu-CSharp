using System;
using UnityEditor;
using UnityEngine;

namespace Entitas.Unity.Editor
{
    public class EntitasPreferencesWindow : DesperateDevs.Unity.Editor.PreferencesWindow
    {
        [MenuItem("Tools/Entitas/Preferences... #%e", false, 1)]
        public static void OpenPreferences()
        {
            EntitasPreferencesWindow window = EditorWindow.GetWindow<EntitasPreferencesWindow>(true, "Entitas " + CheckForUpdates.GetLocalVersion());
            window.minSize = new Vector2(415f, 348f);
            window.Initialize("Entitas.properties", Environment.UserName + ".userproperties", "Entitas.Unity.Editor.EntitasPreferencesDrawer", "Entitas.VisualDebugging.Unity.Editor.VisualDebuggingPreferencesDrawer");
            window.Show();
        }
    }
}