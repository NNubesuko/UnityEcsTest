using Unity.Burst;
using Unity.Entities;

namespace Feature.FreezeRotation
{
    [BurstCompile]
    public partial struct FreezeRotationJob : IJobEntity
    {
        [BurstCompile]
        public void Execute(FreezeRotationAspect freezeRotationAspect)
        {
            freezeRotationAspect.Freeze();
        }
    }
}