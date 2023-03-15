using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Mathematics;

namespace UnityEcsTest.Utility
{
    public static class ValueObjects
    {
        const string ConditionString = "ENABLE_PROFILER";

        [Conditional(ConditionString)]
        public static void CheckInRangeAndThrow(int value, int min, int max, in FixedString32Bytes paramName)
        {
            if (value < min | value > max)
                throw new ArgumentException($"{paramName}", $"{value} is out of range {min}, {max}.");
        }
        
        [Conditional(ConditionString)]
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