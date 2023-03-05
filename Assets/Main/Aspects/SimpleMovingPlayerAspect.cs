using Unity.Entities;
using Unity.Transforms;
using UnityEcsTest.Main.Authorings;

namespace UnityEcsTest.Main.Aspects
{
    public readonly partial struct SimpleMovingPlayerAspect : IAspect
    {
        private readonly RefRW<LocalTransform> transform;
        private readonly RefRO<PlayerMoveSpeed> playerMoveSpeed;

        public void SimpleMove(float deltaTime)
        {
            transform.ValueRW.Position.x += playerMoveSpeed.ValueRO * deltaTime;
        }
    }
}