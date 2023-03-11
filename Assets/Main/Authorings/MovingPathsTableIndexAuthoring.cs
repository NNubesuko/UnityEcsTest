using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class MovingPathsTableIndexAuthoring : MonoBehaviour
    {
        public int value;

        class Baker : Baker<MovingPathsTableIndexAuthoring>
        {
            public override void Bake(MovingPathsTableIndexAuthoring authoring)
            {
                AddComponent(new MovingPathsTableIndex(authoring.value));
            }
        }
    }
    
    public struct MovingPathsTableIndex : IComponentData
    {
        public int Value { get; }

        public const int Min = 0;
        public const int Max = 20;
        public const int ErrorValue = 0;

        public MovingPathsTableIndex(int value)
        {
            Value = ValueObjects.TestValue(
                value,
                Min,
                Max,
                ErrorValue,
                ValueObjects.ArgumentException(nameof(value))
            );
        }

        public static MovingPathsTableIndex operator +(MovingPathsTableIndex tableIndex, int addIndex)
        {
            return new MovingPathsTableIndex(tableIndex.Value + addIndex);
        }

        public static MovingPathsTableIndex operator %(MovingPathsTableIndex tableIndex, int tableLength)
        {
            return new MovingPathsTableIndex(tableIndex.Value % tableLength);
        }
    }
}