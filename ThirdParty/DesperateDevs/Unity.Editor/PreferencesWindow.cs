using DesperateDevs.Serialization;
using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DesperateDevs.Unity.Editor
{
    public class PreferencesWindow : EditorWindow
    {
        private string _propertiesPath;
        private string _userPropertiesPath;
        private string[] _preferencesDrawerNames;
        private Preferences _preferences;
        private IPreferencesDrawer[] _preferencesDrawers;
        private Vector2 _scrollViewPosition;
        private Exception _configException;

        public Preferences preferences
        {
            get { return this._preferences; }
        }

        public void Initialize(
            string propertiesPath,
            string userPropertiesPath,
            params string[] preferencesDrawerNames)
        {
            this._propertiesPath = propertiesPath;
            this._userPropertiesPath = userPropertiesPath;
            this._preferencesDrawerNames = preferencesDrawerNames;
        }

        private void initialize()
        {
            try
            {
                this._preferences = new Preferences(this._propertiesPath, this._userPropertiesPath);
                System.Type[] availableDrawers = AppDomain.CurrentDomain.GetNonAbstractTypes<IPreferencesDrawer>();
                this._preferencesDrawers = ((IEnumerable<string>) this._preferencesDrawerNames)
                    .Select<string, System.Type>((Func<string, System.Type>) (drawerName =>
                        ((IEnumerable<System.Type>) availableDrawers).SingleOrDefault<System.Type>((Func<System.Type, bool>) (type => type.FullName == drawerName))))
                    .Where<System.Type>((Func<System.Type, bool>) (type => type != null))
                    .Select<System.Type, IPreferencesDrawer>((Func<System.Type, IPreferencesDrawer>) (type => (IPreferencesDrawer) Activator.CreateInstance(type)))
                    .ToArray<IPreferencesDrawer>();
                foreach (IPreferencesDrawer preferencesDrawer in this._preferencesDrawers)
                    preferencesDrawer.Initialize(this._preferences);
                this._preferences.Save();
            }
            catch (Exception ex)
            {
                this._preferencesDrawers = new IPreferencesDrawer[0];
                this._configException = ex;
            }
        }

        private void OnGUI()
        {
            if (this._preferencesDrawers == null)
                this.initialize();
            this.drawHeader();
            this._scrollViewPosition = EditorGUILayout.BeginScrollView(this._scrollViewPosition);
            this.drawContent();
            EditorGUILayout.EndScrollView();
            if (!GUI.changed)
                return;
            this._preferences.Save();
        }

        private void drawHeader()
        {
            foreach (IPreferencesDrawer preferencesDrawer in this._preferencesDrawers)
            {
                try
                {
                    preferencesDrawer.DrawHeader(this._preferences);
                }
                catch (Exception ex)
                {
                    PreferencesWindow.drawException(ex);
                }
            }
        }

        private void drawContent()
        {
            if (this._configException == null)
            {
                for (int index = 0; index < this._preferencesDrawers.Length; ++index)
                {
                    try
                    {
                        this._preferencesDrawers[index].DrawContent(this._preferences);
                    }
                    catch (Exception ex)
                    {
                        PreferencesWindow.drawException(ex);
                    }

                    if (index < this._preferencesDrawers.Length - 1)
                        EditorGUILayout.Space();
                }
            }
            else
                PreferencesWindow.drawException(this._configException);
        }

        private static void drawException(Exception exception)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.wordWrap = true;
            style.normal.textColor = Color.red;
            if (Event.current.alt)
                EditorGUILayout.LabelField(exception.ToString(), style);
            else
                EditorGUILayout.LabelField(exception.Message, style);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Please make sure the properties files are set up correctly.");
        }
    }
}