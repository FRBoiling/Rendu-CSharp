using System;
using Entitas;

namespace Rendu.VisualDebugging.Unity.Editor.Entity {

    public interface IComponentDrawer {

        bool HandlesType(Type type);

        IComponent DrawComponent(IComponent component);
    }
}
