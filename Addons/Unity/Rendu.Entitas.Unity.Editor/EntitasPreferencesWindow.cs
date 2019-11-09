using System;
using Rendu.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace Rendu.Entitas.Unity.Editor
{
    public class EntitasPreferencesWindow : PreferencesWindow
    {
        [MenuItem("Tools/Entitas/Preferences... #%e", false, 1)]
        public static void OpenPreferences()
        {
            EntitasPreferencesWindow window = EditorWindow.GetWindow<EntitasPreferencesWindow>(true, "Entitas " + CheckForUpdates.GetLocalVersion());
            window.minSize = new Vector2(415f, 348f);
            window.Initialize("Entitas.properties", Environment.UserName + ".userproperties", "Rendu.Rendu.Entitas.Unity.Editor.EntitasPreferencesDrawer", "Rendu.VisualDebugging.Unity.Editor.VisualDebuggingPreferencesDrawer");
            window.Show();
        }
    }
}