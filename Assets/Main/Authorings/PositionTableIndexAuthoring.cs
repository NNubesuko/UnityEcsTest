using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class PositionTableIndexAuthoring : MonoBehaviour
    {
        public int value;

        class Baker : Baker<PositionTableIndexAuthoring>
        {
            public override void Bake(PositionTableIndexAuthoring authoring)
            {
                AddComponent(new PositionTableIndex(authoring.value));
            }
        }
    }

    public struct PositionTableIndex : IComponentData
    {
        public int Value { get; }

        public const int Min = 0;
        public const int Max = 20;
        public const int ErrorValue = 0;

        public PositionTableIndex(int value)
        {
            Value = ValueObjects.TestValue(
                value,
                Min,
                Max,
                ErrorValue,
                ValueObjects.ArgumentException(nameof(value)));
        }
        
        public static PositionTableIndex operator +(PositionTableIndex tableIndex, int addIndex)
        {
            return new PositionTableIndex(tableIndex.Value + addIndex);
        }

        public static PositionTableIndex operator %(PositionTableIndex tableIndex, int tableLength)
        {
            return new PositionTableIndex(tableIndex.Value % tableLength);
        }
    }
}