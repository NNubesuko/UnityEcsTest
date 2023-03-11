using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEcsTest.Main.Authorings;

namespace UnityEcsTest.Main.Aspects
{
    public readonly partial struct SimpleMovingPlayerAspect : IAspect
    {
        private readonly RefRO<PlayerTag> playerTag;
        private readonly RefRW<LocalTransform> transform;
        private readonly RefRO<PlayerMoveSpeed> playerMoveSpeed;
        private readonly RefRW<PositionTableIndex> tableIndex;
        private readonly DynamicBuffer<MovingPositionTable> movingPositionTables;

        public void SimpleMove(float3 target, float deltaTime)
        {
            float3 current = transform.ValueRO.Position;
                
            var (movedPosition, isTarget) = Move(
                current,
                movingPositionTables[tableIndex.ValueRO.Value].value,
                playerMoveSpeed.ValueRO * deltaTime);

            transform.ValueRW.Position = movedPosition;

            if (isTarget)
            {
                tableIndex.ValueRW = (tableIndex.ValueRW + 1) % movingPositionTables.Length;
            }
        }

        public (float3, bool) Move(float3 current, float3 target, float maxDistanceDelta)
        {
            float num1 = target.x - current.x;
            float num2 = target.y - current.y;
            float num3 = target.z - current.z;
      
            float distance = (float)((double)num1 * (double)num1 +
                                     (double)num2 * (double)num2 +
                                     (double)num3 * (double)num3);

            if ((double)distance == 0.0 ||
                (double)maxDistanceDelta >= 0.0 &&
                (double)distance <= (double)maxDistanceDelta * (double)maxDistanceDelta)
            {
                return (target, true);
            }
            
            float num4 = (float)Math.Sqrt((double)distance);
            
            target = new float3(
                current.x + num1 / num4 * maxDistanceDelta,
                current.y + num2 / num4 * maxDistanceDelta,
                current.z + num3 / num4 * maxDistanceDelta);

            return (target, false);
        }
    }
}