using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Aspects;

namespace Main.Jobs
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