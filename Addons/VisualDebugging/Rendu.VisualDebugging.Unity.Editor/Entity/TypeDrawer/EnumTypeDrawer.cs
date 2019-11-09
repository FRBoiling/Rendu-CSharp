using System;
using UnityEditor;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.TypeDrawer {

    public class EnumTypeDrawer : ITypeDrawer {

        public bool HandlesType(Type type) {
            return type.IsEnum;
        }

        public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
            if (memberType.IsDefined(typeof(FlagsAttribute), false)) {
                return EditorGUILayout.EnumMaskField(memberName, (Enum)value);
            }
            return EditorGUILayout.EnumPopup(memberName, (Enum)value);
        }
    }
}
