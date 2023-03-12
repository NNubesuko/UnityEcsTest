using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using UnityEngine;

namespace UnityEcsTest.Common.Scripts.Authoring
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
                    value = authoring.value
                });
            }
        }
    }

    public struct FreezeRotation : IComponentData
    {
        public bool3 value;
    }
}