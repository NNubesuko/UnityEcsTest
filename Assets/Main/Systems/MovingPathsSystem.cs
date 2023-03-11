using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Executes.EntityScene_01;
using UnityEcsTest.Main.Jobs;

namespace UnityEcsTest.Main.Systems
{
    [BurstCompile]
    public partial struct MovingPathsSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Execute>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            var movingPathsJobHandle = new MovingPathsJob
            {
                deltaTime = deltaTime
            };
            movingPathsJobHandle.ScheduleParallel();
        }
    }
}