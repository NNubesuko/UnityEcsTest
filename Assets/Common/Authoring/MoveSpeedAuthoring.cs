using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace UnityEcsTest.Common.Authoring
{
    public class MoveSpeedAuthoring : MonoBehaviour
    {
        public float value;

        class Baker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                AddComponent(new MoveSpeed(authoring.value));
            }
        }
    }

    public struct MoveSpeed : IComponentData
    {
        public float Value { get; }

        public const float Min = 0f;
        public const float Max = 100f;
        public const float ErrorValue = 0f;

        public MoveSpeed(float value)
        {
            Value = ValueObjects.TestValue(
                value,
                Min,
                Max,
                ErrorValue,
                ValueObjects.ArgumentException(nameof(value)));
        }
        
        public static float operator *(MoveSpeed moveSpeed, float deltaTime)
        {
            return moveSpeed.Value * deltaTime;
        }
    }
}