using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Executes.EntityScene_01;
using UnityEcsTest.Main.Jobs;

namespace UnityEcsTest.Main.Systems
{
    [BurstCompile]
    public partial struct FreezeRotationSystem : ISystem
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
            var freezeRotationJobHandle = new FreezeRotationJob();
            freezeRotationJobHandle.ScheduleParallel();
        }
    }
}