using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Utility.Authoring;

namespace Feature.MovingPaths.Authoring
{
    [RequireComponent(typeof(MoveSpeedAuthoring), typeof(MovingPathsTableIndexAuthoring))]
    public class MovingPathsTableAuthoring : MonoBehaviour
    {
        public float3[] values;

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
                        Value = value
                    });
                }
            }
        }
    }

    public struct MovingPathsTable : IBufferElementData
    {
        public float3 Value;
    }
}