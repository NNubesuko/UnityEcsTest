using System;
using UnityEngine;

namespace UnityEcsTest.Utility
{
    public class ValueObjects
    {
        public const string ArgumentExceptionMessage = "不正な値が渡されました";
        
        public static float TestValue(float value, float min, float max, float errorValue, Exception exception)
        {
            if (value < min | value > max)
            {
                Debug.LogException(exception);
                return errorValue;
            }

            return value;
        }

        public static Exception ArgumentException(string paramName)
        {
            return new ArgumentException(ArgumentExceptionMessage, paramName);
        }
    }
}