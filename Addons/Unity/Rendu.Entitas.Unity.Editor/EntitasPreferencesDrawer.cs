using System;
using System.Linq;
using Rd.Serialization;
using Rendu.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace Rendu.Entitas.Unity.Editor
{
  public class EntitasPreferencesDrawer : AbstractPreferencesDrawer
  {
    private const string ENTITAS_FAST_AND_UNSAFE = "ENTITAS_FAST_AND_UNSAFE";
    private Texture2D _headerTexture;
    private ScriptingDefineSymbols _scriptingDefineSymbols;
    private EntitasPreferencesDrawer.AERCMode _aercMode;

    public override string title
    {
      get
      {
        return "Entitas";
      }
    }

    public override void Initialize(Preferences preferences)
    {
      this._headerTexture = EditorLayout.LoadTexture("l:EntitasHeader");
      this._scriptingDefineSymbols = new ScriptingDefineSymbols();
      this._aercMode = this._scriptingDefineSymbols.buildTargetToDefSymbol.Values.All<string>((Func<string, bool>) (defs => defs.Contains("ENTITAS_FAST_AND_UNSAFE"))) ? EntitasPreferencesDrawer.AERCMode.FastAndUnsafe : EntitasPreferencesDrawer.AERCMode.Safe;
    }

    public override void DrawHeader(Preferences preferences)
    {
      this.drawToolbar();
      this.drawHeader(preferences);
    }

    private void drawToolbar()
    {
      EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
      if (GUILayout.Button("Check for Updates", EditorStyles.toolbarButton))
        CheckForUpdates.DisplayUpdates();
      if (GUILayout.Button("Chat", EditorStyles.toolbarButton))
        EntitasFeedback.EntitasChat();
      if (GUILayout.Button("Docs", EditorStyles.toolbarButton))
        EntitasFeedback.EntitasDocs();
      if (GUILayout.Button("Wiki", EditorStyles.toolbarButton))
        EntitasFeedback.EntitasWiki();
      if (GUILayout.Button("Donate", EditorStyles.toolbarButton))
        EntitasFeedback.Donate();
      EditorGUILayout.EndHorizontal();
    }

    private void drawHeader(Preferences preferences)
    {
      EditorLayout.DrawTexture(this._headerTexture);
    }

    protected override void drawContent(Preferences preferences)
    {
      EditorGUILayout.BeginHorizontal();
      EditorGUILayout.LabelField("Automatic Entity Reference Counting");
      GUIStyle style1 = new GUIStyle(EditorStyles.miniButtonLeft);
      if (this._aercMode == EntitasPreferencesDrawer.AERCMode.Safe)
        style1.normal = style1.active;
      if (GUILayout.Button("Safe", style1))
      {
        this._aercMode = EntitasPreferencesDrawer.AERCMode.Safe;
        this._scriptingDefineSymbols.RemoveDefineSymbol("ENTITAS_FAST_AND_UNSAFE");
      }
      GUIStyle style2 = new GUIStyle(EditorStyles.miniButtonRight);
      if (this._aercMode == EntitasPreferencesDrawer.AERCMode.FastAndUnsafe)
        style2.normal = style2.active;
      if (GUILayout.Button("Fast And Unsafe", style2))
      {
        this._aercMode = EntitasPreferencesDrawer.AERCMode.FastAndUnsafe;
        this._scriptingDefineSymbols.AddDefineSymbol("ENTITAS_FAST_AND_UNSAFE");
      }
      EditorGUILayout.EndHorizontal();
    }

    private enum AERCMode
    {
      Safe,
      FastAndUnsafe,
    }
  }
}