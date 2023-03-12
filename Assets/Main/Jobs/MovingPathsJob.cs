using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
{
    public partial struct MovingPathsJob : IJobEntity
    {
        [ReadOnly]
        public float DeltaTime;
 
        [BurstCompile]
        public void Execute(MovingPathsAspect movingPathsAspect)
        {
            movingPathsAspect.Move(DeltaTime);
        }
    }
}