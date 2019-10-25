using Entitas;

public static class Pools
{
    private static Pool[] _allPools;

    private static Pool _meta;

    private static Pool _core;

    public static Pool[] allPools
    {
        get
        {
            if (_allPools == null) _allPools = new[] {meta, core};

            return _allPools;
        }
    }

    public static Pool meta
    {
        get
        {
            if (_meta == null)
            {
                _meta = new Pool(MetaComponentIds.TotalComponents);
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
                var poolObserver = new Entitas.Unity.VisualDebugging.PoolObserver(_meta, MetaComponentIds.componentNames, MetaComponentIds.componentTypes, "Meta Pool");
                UnityEngine.Object.DontDestroyOnLoad(poolObserver.entitiesContainer);
#endif
            }

            return _meta;
        }
    }

    public static Pool core
    {
        get
        {
            if (_core == null)
            {
                _core = new Pool(CoreComponentIds.TotalComponents);
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
                var poolObserver = new Entitas.Unity.VisualDebugging.PoolObserver(_core, CoreComponentIds.componentNames, CoreComponentIds.componentTypes, "Core Pool");
                UnityEngine.Object.DontDestroyOnLoad(poolObserver.entitiesContainer);
#endif
            }

            return _core;
        }
    }
}