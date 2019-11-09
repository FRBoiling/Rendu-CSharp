using System;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.DefaultInstanceCreator {

    public class DefaultStringCreator : IDefaultInstanceCreator {

        public bool HandlesType(Type type) {
            return type == typeof(string);
        }

        public object CreateDefault(Type type) {
            return string.Empty;
        }
    }
}
