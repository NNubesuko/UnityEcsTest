using System;
using UnityEcsTest.Common.Authoring;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEcsTest.Main.Authorings;

namespace UnityEcsTest.Main.Aspects
{
    public readonly partial struct MovingPathsAspect : IAspect
    {
        readonly RefRO<MoveSpeed> _moveSpeed;
        readonly RefRW<LocalTransform> _transform;
        readonly RefRW<MovingPathsTableIndex> _tableIndex;
        readonly DynamicBuffer<MovingPathsTable> _movingPathsTable;

        public void Move(float deltaTime)
        {
            if (_movingPathsTable.Length == 0) return;
            
            var (movedPosition, isTarget) = MoveTowards(
                _transform.ValueRO.Position,
                _movingPathsTable[_tableIndex.ValueRO.Value].value,
                _moveSpeed.ValueRO * deltaTime);

            _transform.ValueRW.Position = movedPosition;

            if (isTarget)
            {
                _tableIndex.ValueRW = (_tableIndex.ValueRW + 1) % _movingPathsTable.Length;
            }
        }

        public (float3, bool) MoveTowards(float3 current, float3 target, float maxDistanceDelta)
        {
            float x = target.x - current.x;
            float y = target.y - current.y;
            float z = target.z - current.z;

            float distance = (float)((double)x * (double)x +
                                     (double)y * (double)y +
                                     (double)z * (double)z);

            if ((double)distance == 0.0 ||
                (double)maxDistanceDelta >= 0.0 &&
                (double)distance <= (double)maxDistanceDelta * (double)maxDistanceDelta)
            {
                return (target, true);
            }

            float magnitude = (float)Math.Sqrt((double)distance);
            target = new float3(
                current.x + x / magnitude * maxDistanceDelta,
                current.y + y / magnitude * maxDistanceDelta,
                current.z + z / magnitude * maxDistanceDelta);

            return (target, false);
        }
    }
}