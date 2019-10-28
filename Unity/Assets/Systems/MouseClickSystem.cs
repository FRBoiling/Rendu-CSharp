using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class LogMouseClickSystem : ComponentSystem
    {
        struct LogMouseMessage
        {
            string clickLeftMessage;
            string clickRightMessage;
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            string message = "";
            if (Input.GetMouseButtonDown(0))
            {
                message = "Left Mouse Button Clicked";
            }
            if (Input.GetMouseButtonDown(1))
            {
                message = "Right Mouse Button Clicked";
            }
            var job = new LogMouseMessage(){Msg = message};
            return job.Schedule(this, inputDeps);
        }

        protected override void OnUpdate()
        {
            Entities.WithAllReadOnly<DebugMessageComponent>().ForEach(
                (Entity id, ref Translation translation) =>
                {
                    var deltaTime = Time.deltaTime;
                    translation = new Translation()
                    {
                        Value = new float3(translation.Value.x, translation.Value.y + deltaTime, translation.Value.z)
                    };

                    if (translation.Value.y > 10.0f)
                        EntityManager.RemoveComponent<MoveUp_ForEachWithEntityChanges>(id);
                }
            );
        }
    }
}