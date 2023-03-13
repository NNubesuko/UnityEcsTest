using Unity.Entities;
using Unity.Physics;

namespace Feature.FreezeRotation
{
    public readonly partial struct FreezeRotationAspect : IAspect
    {
        readonly RefRW<PhysicsMass> _physicsMass;
        readonly RefRO<FreezeRotation> _freezeRotation;

        public void Freeze()
        {
            var freezeRotationFlag = _freezeRotation.ValueRO.Value;
            if (freezeRotationFlag.x)
                _physicsMass.ValueRW.InverseInertia.x = 0f;
            if (freezeRotationFlag.y)
                _physicsMass.ValueRW.InverseInertia.y = 0f;
            if (freezeRotationFlag.z)
                _physicsMass.ValueRW.InverseInertia.z = 0f;
        }
    }
}