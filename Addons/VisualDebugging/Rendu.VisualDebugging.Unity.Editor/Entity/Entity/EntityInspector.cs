using System.Linq;
using Rendu.VisualDebugging.Unity.Entity;
using UnityEditor;

namespace Rendu.VisualDebugging.Unity.Editor.Entity.Entity {

    [CustomEditor(typeof(EntityBehaviour)), CanEditMultipleObjects]
    public class EntityInspector : UnityEditor.Editor {

        public override void OnInspectorGUI() {
            if (targets.Length == 1) {
                var entityBehaviour = (EntityBehaviour)target;
                EntityDrawer.DrawEntity(entityBehaviour.entity);
            } else {
                var entities = targets
                        .Select(t => ((EntityBehaviour)t).entity)
                        .ToArray();

                EntityDrawer.DrawMultipleEntities(entities);
            }

            if (target != null) {
                EditorUtility.SetDirty(target);
            }
        }
    }
}
