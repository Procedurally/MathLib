using System;

namespace MathLib
{
    public class Vector2
    {
        public readonly float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            var v = new Vector2(a.X - b.X, a.Y - b.Y);
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }

        public override string ToString()
        {
            return string.Format("({0},{1}})", X, Y);
        }
    }
}
