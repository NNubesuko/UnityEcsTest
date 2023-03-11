using System.Xml;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class MovingPositionTableAuthoring : MonoBehaviour
    {
        public Vector3[] values;

        class Baker : Baker<MovingPositionTableAuthoring>
        {
            public override void Bake(MovingPositionTableAuthoring authoring)
            {
                DynamicBuffer<MovingPositionTable> dynamicBuffer = AddBuffer<MovingPositionTable>();

                foreach (var value in authoring.values)
                {
                    dynamicBuffer.Add(new MovingPositionTable
                    {
                        value = value
                    });
                }
            }
        }
    }

    [InternalBufferCapacity(8)]
    public struct MovingPositionTable : IBufferElementData
    {
        public float3 value;
    }
}