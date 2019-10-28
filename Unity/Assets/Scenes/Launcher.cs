using Unity.Entities;
using UnityEngine;

public class Launcher:MonoBehaviour
{
//    public static EntityArchetype archetype1 { get; private set; }
//    public static EntityArchetype archetype2 { get; private set; }
//
//    // This attribute allows us to not use MonoBehaviours to instantiate entities
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//    public static void InitializeBeforeScene()
//    {
//        var em = World.Active.GetOrCreateManager<EntityManager>(); // EntityManager manages all entities in world
//        CreateArchetypes(em); // we need to set archetype first
//    }
//
//    // This attribute allows us to not use MonoBehaviours to instantiate entities
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
//    public static void InitializeAfterScene()
//    {
//        var em = World.Active.GetOrCreateManager<EntityManager>(); // EntityManager manages all entities in world
//    }
//    
//    private static void CreateArchetypes(EntityManager em)
//    {
////        var heading = ComponentType.Create<Heading>();
////        var health = ComponentType.Create<Health>();
////        var moveSpeed = ComponentType.Create<MoveSpeed>();
////
////        archetype1 = em.CreateArchetype(pos, heading, health, moveSpeed);
////        archetype2 = em.CreateArchetype(pos, heading, moveSpeed);
//        // that's exactly how you set your entities archetype, it's like LEGO
//    }
    public GameObject Prefab;
    void Start()
    {
        // Create entity prefab from the game object hierarchy once
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, World.Active);
        var entityManager = World.Active.EntityManager;
        
        var instance = entityManager.Instantiate(prefab);
        entityManager.SetComponentData(instance, new DebugMessageComponent());
        entityManager.AddComponentData(instance, new MouseClickComponent());
    }

}
