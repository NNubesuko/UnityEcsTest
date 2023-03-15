using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Executes.EntityScene_01;
using UnityEngine.Profiling;

namespace Feature.MovingPaths
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
            Profiler.BeginSample("Moving Paths System");
            float deltaTime = SystemAPI.Time.DeltaTime;
    
            var movingPathsJobHandle = new MovingPathsJob
            {
                DeltaTime = deltaTime
            };
            movingPathsJobHandle.Schedule();
            Profiler.EndSample();
        }
    }
}