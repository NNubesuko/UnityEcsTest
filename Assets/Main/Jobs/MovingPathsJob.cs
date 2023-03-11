using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Common.Authoring;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
{
    [BurstCompile]
    public partial struct MovingPathsJob : IJobEntity
    {
        public float deltaTime;

        [BurstCompile]
        public void Execute(MovingPathsAspect movingPathsAspect)
        {
            movingPathsAspect.Move(deltaTime);
        }
    }
}