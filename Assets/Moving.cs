using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Moving : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3[] pathTable;

    int tableIndex = 0;

    private void Update()
    {
        Profiler.BeginSample("Moving Path Mono");
        if (pathTable.Length == 0) return;

        var targetPosition = pathTable[tableIndex];
        targetPosition.y = transform.position.y;

        var (movedPosition, isTarget) = MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = movedPosition;

        if (isTarget)
        {
            tableIndex = (tableIndex + 1) % pathTable.Length;
        }
        Profiler.EndSample();
    }

    private (Vector3, bool) MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
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
        target = new Vector3(
            current.x + x / magnitude * maxDistanceDelta,
            current.y + y / magnitude * maxDistanceDelta,
            current.z + z / magnitude * maxDistanceDelta);

        return (target, false);
    }
}
