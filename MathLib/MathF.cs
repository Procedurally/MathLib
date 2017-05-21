using System;

namespace MathLib
{
    /// <summary>
    /// Floating point math functions
    /// </summary>
    public class MathF
    {
        public const float Pi = (float) Math.PI;

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        private const float Deg2Rad = (float) (Math.PI / 180f);

        /// <summary>
        /// Convert radians to degrees 
        /// </summary>
        private const float Rad2Deg = (float) (180f / Math.PI);

        public static float Radians(float degrees)
        {
            return degrees * Deg2Rad;
        }

        public static float Degrees(float radians)
        {
            return radians * Rad2Deg;
        }

        public static float Cos(float f)
        {
            return (float) Math.Cos(f);
        }

        public static float Sin(float f)
        {
            return (float) Math.Sin(f);
        }

        public static float Asin(float f)
        {
            return (float) Math.Asin(f);
        }

        public static float Atan2(float y, float x)
        {
            return (float) Math.Atan2(y, x);
        }

        public static float Cot(float f)
        {
            return (float) (1 / Math.Tan(f));
        }

        public static float Sqrt(float f)
        {
            return (float) Math.Sqrt(f);
        }

        public static float Round(float f)
        {
            return (float) Math.Round(f);
        }

        public static float Floor(float f)
        {
            return (float) Math.Floor(f);
        }

        public static float Mod(float a, float b)
        {
            return a - b * (float) Math.Floor(a / b);
        }

        public static float Clamp(float v, float min, float max)
        {
            if (v < min)
                return min;

            if (v > max)
                return max;

            return v;
        }
    }

}