using Entitas.Context;
using Entitas.Entity;

namespace Rendu.VisualDebugging.Unity.Editor {

    public static class VisualDebuggingEntitasExtension {

        public static IEntity CreateEntity(this IContext context) {
            return (IEntity)context.GetType().GetMethod("CreateEntity").Invoke(context, null);
        }
    }
}
