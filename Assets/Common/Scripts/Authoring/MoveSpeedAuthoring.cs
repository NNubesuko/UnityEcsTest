using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace Common.Scripts.Authoring
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
        public readonly float Value;

        public const float Min = 0f;
        public const float Max = 100f;

        private MoveSpeed(float value)
        {
            ValueObjects.CheckInRangeAndThrow(value, Min, Max, "value");
            Value = value;
        }

        public static MoveSpeed Of(float value)
        {
            return new MoveSpeed(value);
        }

        public static float operator *(MoveSpeed moveSpeed, float deltaTime)
        {
            return moveSpeed.Value * deltaTime;
        }
    }
}