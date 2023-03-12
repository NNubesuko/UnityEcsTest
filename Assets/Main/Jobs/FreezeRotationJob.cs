using Unity.Burst;
using Unity.Entities;
using UnityEcsTest.Main.Aspects;

namespace UnityEcsTest.Main.Jobs
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