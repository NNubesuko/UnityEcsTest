using System;
using UnityEngine;

namespace UnityEcsTest.Utility
{
    public struct ValueObjects
    {
        public const string ArgumentExceptionMessage = "不正な値が渡されました";
        
        public static int TestValue(int value, int min, int max, int errorValue, Exception exception)
        {
            if (value < min | value > max)
            {
                Debug.LogError(exception);
                return errorValue;
            }

            return value;
        }
        
        public static float TestValue(float value, float min, float max, float errorValue, Exception exception)
        {
            if (value < min | value > max)
            {
                Debug.LogError(exception);
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