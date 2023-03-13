using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Feature.MovingPaths
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