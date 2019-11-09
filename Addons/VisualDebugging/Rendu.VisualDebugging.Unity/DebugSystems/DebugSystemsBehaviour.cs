using UnityEngine;

namespace Rendu.VisualDebugging.Unity.DebugSystems {

    public class DebugSystemsBehaviour : MonoBehaviour {

        public DebugSystems systems { get { return _systems; } }

        DebugSystems _systems;

        public void Init(DebugSystems systems) {
            _systems = systems;
        }
    }
}
