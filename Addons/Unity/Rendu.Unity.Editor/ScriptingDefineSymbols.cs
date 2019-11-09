using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace Rendu.Unity.Editor
{
    public class ScriptingDefineSymbols
    {
        private readonly Dictionary<BuildTargetGroup, string> _buildTargetToDefSymbol;

        public Dictionary<BuildTargetGroup, string> buildTargetToDefSymbol
        {
            get
            {
                return this._buildTargetToDefSymbol;
            }
        }

        public ScriptingDefineSymbols()
        {
            this._buildTargetToDefSymbol = Enum.GetValues(typeof (BuildTargetGroup)).Cast<BuildTargetGroup>().Where<BuildTargetGroup>((Func<BuildTargetGroup, bool>) (buildTargetGroup => (uint) buildTargetGroup > 0U)).Where<BuildTargetGroup>((Func<BuildTargetGroup, bool>) (buildTargetGroup => !this.isBuildTargetObsolete(buildTargetGroup))).Distinct<BuildTargetGroup>().ToDictionary<BuildTargetGroup, BuildTargetGroup, string>((Func<BuildTargetGroup, BuildTargetGroup>) (buildTargetGroup => buildTargetGroup), new Func<BuildTargetGroup, string>(PlayerSettings.GetScriptingDefineSymbolsForGroup));
        }

        public void AddDefineSymbol(string defineSymbol)
        {
            foreach (KeyValuePair<BuildTargetGroup, string> keyValuePair in this._buildTargetToDefSymbol)
                PlayerSettings.SetScriptingDefineSymbolsForGroup(keyValuePair.Key, keyValuePair.Value.Replace(defineSymbol, string.Empty) + "," + defineSymbol);
        }

        public void RemoveDefineSymbol(string defineSymbol)
        {
            foreach (KeyValuePair<BuildTargetGroup, string> keyValuePair in this._buildTargetToDefSymbol)
                PlayerSettings.SetScriptingDefineSymbolsForGroup(keyValuePair.Key, keyValuePair.Value.Replace(defineSymbol, string.Empty));
        }

        private bool isBuildTargetObsolete(BuildTargetGroup buildTargetGroup)
        {
            return Attribute.IsDefined((MemberInfo) buildTargetGroup.GetType().GetField(buildTargetGroup.ToString()), typeof (ObsoleteAttribute));
        }
    }
}