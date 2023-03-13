using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Physics;
using Debug = UnityEngine.Debug;

namespace UnityEcsTest.Utility
{
    public static class ValueObjects
    {
        public static void CheckInRangeAndThrow(int value, int min, int max, in FixedString32Bytes paramName)
        {
            if (value < min | value > max)
                throw new ArgumentException($"{paramName}", $"{value} is out of range {min}, {max}.");
        }
        
        public static void CheckInRangeAndThrow(float value, float min, float max, in FixedString32Bytes paramName)
        {
            if (value < min | value > max)
                throw new ArgumentException($"{value} is out of range {min}, {max}.", $"{paramName}");
        }

        public static int KeepWithinRange(int value, int min, int max)
        {
            value = math.min(value, max);
            value = math.max(value, min);

            return value;
        }
        
        public static float KeepWithinRange(float value, float min, float max)
        {
            value = math.min(value, max);
            value = math.max(value, min);

            return value;
        }
    }
}