using Unity.Entities;
using UnityEcsTest.Utility;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class PlayerMoveSpeedAuthoring : MonoBehaviour
    {
        public float value;

        class Baker : Baker<PlayerMoveSpeedAuthoring>
        {
            public override void Bake(PlayerMoveSpeedAuthoring authoring)
            {
                AddComponent(PlayerMoveSpeed.Of(authoring.value));
            }
        }
    }

    public struct PlayerMoveSpeed : IComponentData
    {
        public float Value { get; }

        public const float Min = 0f;
        public const float Max = 10f;
        public const float ErrorValue = 0f;

        private PlayerMoveSpeed(float value)
        {
            Value = ValueObjects.TestValue(
                value,
                Min,
                Max,
                ErrorValue,
                ValueObjects.ArgumentException(nameof(value)));
        }

        public static PlayerMoveSpeed Of(float value)
        {
            return new PlayerMoveSpeed(value);
        }
    }
}