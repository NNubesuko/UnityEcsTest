using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using UnityEngine;

namespace Feature.FreezeRotation.Authoring
{
    [RequireComponent(typeof(PhysicsBodyAuthoring))]
    public class FreezeRotationAuthoring : MonoBehaviour
    {
        public bool3 value;

        class Baker : Baker<FreezeRotationAuthoring>
        {
            public override void Bake(FreezeRotationAuthoring authoring)
            {
                AddComponent(new FreezeRotation
                {
                    Value = authoring.value
                });
            }
        }
    }

    public struct FreezeRotation : IComponentData
    {
        public bool3 Value;
    }
}