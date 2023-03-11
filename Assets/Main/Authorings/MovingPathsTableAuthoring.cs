using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class MovingPathsTableAuthoring : MonoBehaviour
    {
        public Vector3[] values;

        class Baker : Baker<MovingPathsTableAuthoring>
        {
            public override void Bake(MovingPathsTableAuthoring authoring)
            {
                if (authoring.values == null) return;
                
                DynamicBuffer<MovingPathsTable> movingPathsTable = AddBuffer<MovingPathsTable>();
                foreach (var value in authoring.values)
                {
                    movingPathsTable.Add(new MovingPathsTable
                    {
                        value = value
                    });
                }
            }
        }
    }

    public struct MovingPathsTable : IBufferElementData
    {
        public float3 value;
    }
}