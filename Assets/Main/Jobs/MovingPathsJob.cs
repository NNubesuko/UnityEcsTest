using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
{
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