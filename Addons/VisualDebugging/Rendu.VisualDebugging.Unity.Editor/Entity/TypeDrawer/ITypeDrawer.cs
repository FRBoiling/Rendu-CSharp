using System;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.TypeDrawer {

    public interface ITypeDrawer {

        bool HandlesType(Type type);

        object DrawAndGetNewValue(Type memberType, string memberName, object value, object target);
    }
}
