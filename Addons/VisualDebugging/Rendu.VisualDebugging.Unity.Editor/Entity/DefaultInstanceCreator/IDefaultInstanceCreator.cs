using System;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.DefaultInstanceCreator {

    public interface IDefaultInstanceCreator {

        bool HandlesType(Type type);

        object CreateDefault(Type type);
    }
}
