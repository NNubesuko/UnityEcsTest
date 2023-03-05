using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Jobs;

namespace UnityEcsTest.Main.Systems
{
    [BurstCompile]
    public partial struct SimpleMovingPlayerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
        
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            var simpleMovingPlayerJobHandle = new SimpleMovingPlayerJob
            {
                deltaTime = deltaTime
            };
            simpleMovingPlayerJobHandle.ScheduleParallel();
        }
    }
}