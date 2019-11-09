using System;
using UnityEditor;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.TypeDrawer {

    public class BoolTypeDrawer : ITypeDrawer {

        public bool HandlesType(Type type) {
            return type == typeof(bool);
        }

        public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
            return EditorGUILayout.Toggle(memberName, (bool)value);
        }
    }
}
