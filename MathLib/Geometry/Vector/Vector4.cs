using System;

namespace MathLib
{
    public class Vector4
    {
        public float X, Y, Z, W;

        public Vector4()
        {
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vector4 operator +(Vector4 a, float b)
        {
            return new Vector4(a.X + b, a.Y + b, a.Z + b, a.W + b);
        }

        public static Vector4 operator -(Vector4 a, float b)
        {
            return new Vector4(a.X - b, a.Y - b, a.Z - b, a.W - b);
        }

        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.X * b, a.Y * b, a.Z * b, a.W * b);
        }

        public static Vector4 operator /(Vector4 a, float b)
        {
            return new Vector4(a.X / b, a.Y / b, a.Z / b, a.W / b);
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public Vector3 DivideByW()
        {
            return ToVector3() / Math.Abs(W); ;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
}
