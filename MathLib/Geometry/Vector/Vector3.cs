using System;

namespace MathLib
{
    public class Vector3
    {
        public float X, Y, Z;

        public static Vector3 Up
        {
            get { return new Vector3(0, 1, 0); }
        }

        public Vector3()
        {
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 Normalized()
        {
            var m = Magnitude();

            return new Vector3(X / m, Y / m, Z / m);
        }

        public float Magnitude()
        {
            return MathF.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.Y * rhs.Z - lhs.Z * rhs.Y,
                               lhs.Z * rhs.X - lhs.X * rhs.Z,
                               lhs.X * rhs.Y - lhs.Y * rhs.X);
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            var v = new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            return MathF.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a.X / b, a.Y / b, a.Z / b);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
}
