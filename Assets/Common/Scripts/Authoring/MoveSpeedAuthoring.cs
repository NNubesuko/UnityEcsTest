using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace UnityEcsTest.Common.Scripts.Authoring
{
    public class MoveSpeedAuthoring : MonoBehaviour
    {
        public float value;

        class Baker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                AddComponent(MoveSpeed.Of(authoring.value));
            }
        }
    }

    public struct MoveSpeed : IComponentData
    {
        public float Value { get; }

        public const float Min = 0f;
        public const float Max = 100f;
        public const float ErrorValue = 0f;

        private MoveSpeed(float value)
        {
            Value = ValueObjects.TestValue(
                value,
                Min,
                Max,
                ErrorValue,
                ValueObjects.ArgumentException(nameof(value)));
        }

        public static MoveSpeed Of(float value)
        {
            return new MoveSpeed();
        }
        
        public static float operator *(MoveSpeed moveSpeed, float deltaTime)
        {
            return moveSpeed.Value * deltaTime;
        }
    }
}