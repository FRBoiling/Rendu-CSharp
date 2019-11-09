using System;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.DefaultInstanceCreator {

    public class DefaultArrayCreator : IDefaultInstanceCreator {

        public bool HandlesType(Type type) {
            return type.IsArray;
        }

        public object CreateDefault(Type type) {
            var rank = type.GetArrayRank();
            return Array.CreateInstance(type.GetElementType(), new int[rank]);
        }
    }
}
