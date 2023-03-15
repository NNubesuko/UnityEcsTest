using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;
using Utility.Authoring;

namespace Feature.MovingPaths.Authoring
{
    [RequireComponent(typeof(MoveSpeedAuthoring))]
    public class MovingPathsTableIndexAuthoring : MonoBehaviour
    {
        public int value;

        class Baker : Baker<MovingPathsTableIndexAuthoring>
        {
            public override void Bake(MovingPathsTableIndexAuthoring authoring)
            {
                AddComponent(MovingPathsTableIndex.Of(authoring.value));
            }
        }
    }
    
    public struct MovingPathsTableIndex : IComponentData
    {
        public readonly int Value;

        public const int Min = 0;
        public const int Max = 20;

        private MovingPathsTableIndex(int value)
        {
            ValueObjects.CheckInRangeAndThrow(value, Min, Max, "value");
            Value = value;
        }

        public static MovingPathsTableIndex Of(int value)
        {
            return new MovingPathsTableIndex(value);
        }

        public static MovingPathsTableIndex operator +(MovingPathsTableIndex tableIndex, int addIndex)
        {
            var value = ValueObjects.KeepWithinRange(tableIndex.Value + addIndex, Min, Max);
            return new MovingPathsTableIndex(value);
        }

        public static MovingPathsTableIndex operator %(MovingPathsTableIndex tableIndex, int tableLength)
        {
            var value = ValueObjects.KeepWithinRange(tableIndex.Value % tableLength, Min, Max);
            return new MovingPathsTableIndex(value);
        }
    }
}