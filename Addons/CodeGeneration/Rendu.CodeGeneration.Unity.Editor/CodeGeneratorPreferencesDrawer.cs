using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Rd.CodeGeneration;
using Rd.CodeGenerator;
using Rd.Serialization;
using Rd.Utils;
using Rendu.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace Rendu.CodeGeneration.Unity.Editor
{
  public class CodeGeneratorPreferencesDrawer : AbstractPreferencesDrawer
  {
    private string[] _availablePreProcessorTypes;
    private string[] _availableDataProviderTypes;
    private string[] _availableGeneratorTypes;
    private string[] _availablePostProcessorTypes;
    private string[] _availablePreProcessorNames;
    private string[] _availableDataProviderNames;
    private string[] _availableGeneratorNames;
    private string[] _availablePostProcessorNames;
    private Texture2D _headerTexture;
    private ICodeGenerationPlugin[] _instances;
    private CodeGeneratorConfig _codeGeneratorConfig;
    public const string PROPERTIES_PATH_KEY = "Rd.CodeGeneration.CodeGenerator.Unity.Editor.PropertiesPath";
    private const string USE_EXTERNAL_CODE_GENERATOR = "Rd.CodeGeneration.CodeGenerator.Unity.Editor.UseExternalCodeGenerator";
    private bool _useExternalCodeGenerator;
    private bool _doDryRun;

    public override string title
    {
      get
      {
        return "Jenny";
      }
    }

    public override void Initialize(Preferences preferences)
    {
      this._headerTexture = EditorLayout.LoadTexture("l:Jenny-Header");
      this._codeGeneratorConfig = preferences.CreateAndConfigure<CodeGeneratorConfig>();
      preferences.properties.AddProperties(this._codeGeneratorConfig.defaultProperties, false);
      this._instances = CodeGeneratorUtil.LoadFromPlugins(preferences);
      CodeGeneratorPreferencesDrawer.setTypesAndNames<IPreProcessor>(this._instances, out this._availablePreProcessorTypes, out this._availablePreProcessorNames);
      CodeGeneratorPreferencesDrawer.setTypesAndNames<IDataProvider>(this._instances, out this._availableDataProviderTypes, out this._availableDataProviderNames);
      CodeGeneratorPreferencesDrawer.setTypesAndNames<ICodeGenerator>(this._instances, out this._availableGeneratorTypes, out this._availableGeneratorNames);
      CodeGeneratorPreferencesDrawer.setTypesAndNames<IPostProcessor>(this._instances, out this._availablePostProcessorTypes, out this._availablePostProcessorNames);
      preferences.properties.AddProperties(CodeGeneratorUtil.GetDefaultProperties(this._instances, this._codeGeneratorConfig), false);
      this._useExternalCodeGenerator = EditorPrefs.GetBool("Rd.CodeGeneration.CodeGenerator.Unity.Editor.UseExternalCodeGenerator");
      this._doDryRun = EditorPrefs.GetBool("Rd.CodeGeneration.CodeGenerator.Unity.Editor.DryRun", true);
    }

    public override void DrawHeader(Preferences preferences)
    {
      Rect rect = EditorLayout.DrawTexture(this._headerTexture);
      string fileName = Path.GetFileName(preferences.propertiesPath);
      int num = 60 + fileName.Length * 5;
      if (!GUI.Button(new Rect((float) ((double) rect.width - (double) num - 4.0), (float) ((double) rect.y + (double) rect.height - 15.0 - 4.0), (float) num, 15f), "Edit " + fileName, EditorStyles.miniButton))
        return;
      EditorWindow.focusedWindow.Close();
      Process.Start(preferences.propertiesPath);
    }

    protected override void drawContent(Preferences preferences)
    {
      string str = EditorLayout.ObjectFieldOpenFilePanel("Properties", preferences.propertiesPath, preferences.propertiesPath, "properties");
      if (!string.IsNullOrEmpty(str))
      {
        EditorPrefs.SetString("Rd.CodeGeneration.CodeGenerator.Unity.Editor.PropertiesPath", str);
        EditorWindow.focusedWindow.Close();
        CodeGeneratorPreferencesWindow.OpenPreferences();
      }
      EditorGUILayout.BeginHorizontal();
      EditorGUILayout.LabelField("Auto Import Rd.Plugins");
      if (EditorLayout.MiniButton("Auto Import"))
        this.autoImport(preferences);
      EditorGUILayout.EndHorizontal();
      this._codeGeneratorConfig.preProcessors = CodeGeneratorPreferencesDrawer.drawMaskField("Pre Processors", this._availablePreProcessorTypes, this._availablePreProcessorNames, this._codeGeneratorConfig.preProcessors);
      this._codeGeneratorConfig.dataProviders = CodeGeneratorPreferencesDrawer.drawMaskField("Data Providers", this._availableDataProviderTypes, this._availableDataProviderNames, this._codeGeneratorConfig.dataProviders);
      this._codeGeneratorConfig.codeGenerators = CodeGeneratorPreferencesDrawer.drawMaskField("Code Generators", this._availableGeneratorTypes, this._availableGeneratorNames, this._codeGeneratorConfig.codeGenerators);
      this._codeGeneratorConfig.postProcessors = CodeGeneratorPreferencesDrawer.drawMaskField("Post Processors", this._availablePostProcessorTypes, this._availablePostProcessorNames, this._codeGeneratorConfig.postProcessors);
      this.drawConfigurables(preferences);
      EditorGUILayout.Space();
      this.drawGenerateButtons();
    }

    private void autoImport(Preferences preferences)
    {
      if (!EditorUtility.DisplayDialog("Jenny - Auto Import", "Auto Import will automatically find and set all plugins for you. It will search in folders and sub folders specified in " + Path.GetFileName(preferences.propertiesPath) + " under the key 'Jenny.SearchPaths'.\n\nThis will overwrite your current plugin settings.\n\nDo you want to continue?", "Continue and Overwrite", "Cancel"))
        return;
      CodeGeneratorUtil.AutoImport(this._codeGeneratorConfig, CodeGeneratorUtil.BuildSearchPaths(this._codeGeneratorConfig.searchPaths, new string[2]
      {
        "./Assets",
        "./Library/ScriptAssemblies"
      }));
      preferences.Save();
      this.Initialize(preferences);
      this._codeGeneratorConfig.preProcessors = this._availablePreProcessorTypes;
      this._codeGeneratorConfig.dataProviders = this._availableDataProviderTypes;
      this._codeGeneratorConfig.codeGenerators = this._availableGeneratorTypes;
      this._codeGeneratorConfig.postProcessors = this._availablePostProcessorTypes;
    }

    private void drawConfigurables(Preferences preferences)
    {
      Dictionary<string, string> defaultProperties = CodeGeneratorUtil.GetDefaultProperties(this._instances, this._codeGeneratorConfig);
      preferences.properties.AddProperties(defaultProperties, false);
      if (defaultProperties.Count != 0)
      {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Rd.Plugins Configuration", EditorStyles.boldLabel);
      }
      foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>) defaultProperties.OrderBy<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (kv => kv.Key)))
        preferences[keyValuePair.Key] = EditorGUILayout.TextField(keyValuePair.Key.ShortTypeName().ToSpacedCamelCase(), preferences[keyValuePair.Key]);
    }

    private static void setTypesAndNames<T>(
      ICodeGenerationPlugin[] instances,
      out string[] availableTypes,
      out string[] availableNames)
      where T : ICodeGenerationPlugin
    {
      T[] orderedInstancesOf = CodeGeneratorUtil.GetOrderedInstancesOf<T>(instances);
      availableTypes = ((IEnumerable<T>) orderedInstancesOf).Select<T, string>((Func<T, string>) (instance => instance.GetType().ToCompilableString())).ToArray<string>();
      availableNames = ((IEnumerable<T>) orderedInstancesOf).Select<T, string>((Func<T, string>) (instance => instance.name)).ToArray<string>();
    }

    private static string[] drawMaskField(
      string title,
      string[] types,
      string[] names,
      string[] input)
    {
      int mask = 0;
      for (int index = 0; index < types.Length; ++index)
      {
        if (((IEnumerable<string>) input).Contains<string>(types[index]))
          mask += 1 << index;
      }
      if (names.Length != 0)
      {
        int num = (int) Math.Pow(2.0, (double) types.Length) - 1;
        if (mask == num)
          mask = -1;
        mask = EditorGUILayout.MaskField(title, mask, names);
      }
      else
        EditorGUILayout.LabelField(title, "No " + title + " available");
      List<string> stringList = new List<string>();
      for (int index = 0; index < types.Length; ++index)
      {
        int num = 1 << index;
        if ((num & mask) == num)
          stringList.Add(types[index]);
      }
      stringList.AddRange(((IEnumerable<string>) input).Where<string>((Func<string, bool>) (type => !((IEnumerable<string>) types).Contains<string>(type))));
      return stringList.ToArray();
    }

    private void drawGenerateButtons()
    {
      EditorGUILayout.BeginVertical();
      EditorGUI.BeginChangeCheck();
//      this._useExternalCodeGenerator = EditorGUILayout.Toggle("Use Jenny Server", this._useExternalCodeGenerator);
      if (EditorGUI.EndChangeCheck())
        EditorPrefs.SetBool("Rd.CodeGeneration.CodeGenerator.Unity.Editor.UseExternalCodeGenerator", this._useExternalCodeGenerator);
      if (this._useExternalCodeGenerator)
      {
        this._codeGeneratorConfig.port = EditorGUILayout.IntField("Port", this._codeGeneratorConfig.port);
        this._codeGeneratorConfig.host = EditorGUILayout.TextField("Host", this._codeGeneratorConfig.host);
      }
      else
      {
        EditorGUI.BeginChangeCheck();
        this._doDryRun = EditorGUILayout.Toggle("Safe Mode (Dry Run first)", this._doDryRun);
        if (EditorGUI.EndChangeCheck())
          EditorPrefs.SetBool("Rd.CodeGeneration.CodeGenerator.Unity.Editor.DryRun", this._doDryRun);
      }
      Color backgroundColor = GUI.backgroundColor;
      GUI.backgroundColor = Color.green;
      if (GUILayout.Button("Generate", GUILayout.Height(32f)))
      {
//        if (this._useExternalCodeGenerator)
//          UnityCodeGenerator.GenerateExternal();
//        else
          UnityCodeGenerator.Generate();
      }
      GUI.backgroundColor = backgroundColor;
      EditorGUILayout.EndVertical();
    }
  }
}