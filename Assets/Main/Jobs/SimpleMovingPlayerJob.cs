using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
{
    [BurstCompile]
    public partial struct SimpleMovingPlayerJob : IJobEntity
    {
        public float3 target;
        public float deltaTime;

        [BurstCompile]
        public void Execute(SimpleMovingPlayerAspect simpleMovingPlayerAspect)
        {
            simpleMovingPlayerAspect.SimpleMove(target, deltaTime);
        }
    }
}