using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEcsTest.Main.Authorings;
using UnityEcsTest.Main.Executes.EntityScene_01;
using UnityEcsTest.Main.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEcsTest.Main.Systems
{
    [BurstCompile]
    public partial struct SimpleMovingPlayerSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Execute>();
        }
        
        public void OnDestroy(ref SystemState state)
        {
        }
        
        public void OnUpdate(ref SystemState state)
        {
            float3 target = new float3(5f, 0f, 5f);
            float deltaTime = SystemAPI.Time.DeltaTime;

            var simpleMovingPlayerJobHandle = new SimpleMovingPlayerJob
            {
                target = target,
                deltaTime = deltaTime
            };
            simpleMovingPlayerJobHandle.ScheduleParallel();
        }
    }
}