using System;

namespace TCosReborn.Framework.Utility
{
    public static class Mathf
    {

        public static volatile float FloatMinNormal = 1.17549435E-38f;
        public static volatile float FloatMinDenormal = 1.401298E-45f;
        public static bool IsFlushToZeroEnabled = FloatMinDenormal == 0f;

        public static readonly float Epsilon = (!IsFlushToZeroEnabled) ? FloatMinDenormal : FloatMinNormal;

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else
            {
                if (value > max)
                {
                    value = max;
                }
            }
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else
            {
                if (value > max)
                {
                    value = max;
                }
            }
            return value;
        }

        public static float Abs(float f)
        {
            return Math.Abs(f);
        }

        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        public static float Max(float a, float b)
        {
            return (a <= b) ? b : a;
        }

        public static float Max(params float[] values)
        {
            int num = values.Length;
            float result;
            if (num == 0)
            {
                result = 0f;
            }
            else
            {
                float num2 = values[0];
                for (int i = 1; i < num; i++)
                {
                    if (values[i] > num2)
                    {
                        num2 = values[i];
                    }
                }
                result = num2;
            }
            return result;
        }

        public static int Max(int a, int b)
        {
            return (a <= b) ? b : a;
        }

        public static float Min(float a, float b)
        {
            return (a >= b) ? b : a;
        }

        public static float Min(params float[] values)
        {
            int num = values.Length;
            float result;
            if (num == 0)
            {
                result = 0f;
            }
            else
            {
                float num2 = values[0];
                for (int i = 1; i < num; i++)
                {
                    if (values[i] < num2)
                    {
                        num2 = values[i];
                    }
                }
                result = num2;
            }
            return result;
        }

        public static int Min(int a, int b)
        {
            return (a >= b) ? b : a;
        }

        public static bool Approximately(float a, float b)
        {
            return Mathf.Abs(b - a) < Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), Mathf.Epsilon * 8f);
        }
    }
}
