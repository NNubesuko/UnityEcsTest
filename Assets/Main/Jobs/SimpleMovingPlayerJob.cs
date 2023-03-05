using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
{
    [BurstCompile]
    public partial struct SimpleMovingPlayerJob : IJobEntity
    {
        public float deltaTime;

        [BurstCompile]
        public void Execute(SimpleMovingPlayerAspect simpleMovingPlayerAspect)
        {
            simpleMovingPlayerAspect.SimpleMove(deltaTime);
        }
    }
}