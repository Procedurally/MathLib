using System;
using System.Text;

namespace MathLib
{
    public class Matrix
    {
        public readonly int Size;

        public readonly int Rows;
        public readonly int Cols;

        public float[][] M;

        public float this[int i, int j]
        {
            get { return M[i][j]; }
            set { M[i][j] = value; }
        }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Size = rows * cols;
            M = new float[Rows][];

            for (var i = 0; i < Rows; i++)
                M[i] = new float[Cols];
        }

        public Matrix(float[][] m)
        {
            Rows = m.Length;
            Cols = m[0].Length;
            Size = m.Length;
            M = (float[][]) m.Clone();
        }

        public Matrix(Vector3 v)
        {
            Rows = 1;
            Cols = 4;
            Size = 4;
            M = new[] {new[] {v.X, v.Y, v.Z, 1f}};
        }

        public static Matrix Multiply(Matrix lhs, Matrix rhs)
        {
            if (lhs.Cols != rhs.Rows)
                throw new ArgumentOutOfRangeException();

            var m = new Matrix(lhs.Rows, rhs.Cols);

            for (var j = 0; j < m.Cols; j++)
                for (var i = 0; i < m.Rows; i++)
                    for (var k = 0; k < lhs.Cols; k++)
                        m[i, j] += lhs[i, k] * rhs[k, j];

            return m;
        }

        public static Matrix Multiply(Vector3 lhs, Matrix rhs)
        {
            return Multiply(new Matrix(lhs), rhs);
        }

        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            return Multiply(lhs, rhs);
        }

        public static Vector3 operator *(Vector3 lhs, Matrix rhs)
        {
            return Multiply(new Matrix(lhs), rhs).ToVector3();
        }

        public static Matrix TranslateMatrix(Vector3 v)
        {
            var t = new Matrix(new[]
            {
                new[] {1f, 0f, 0f, 0f},
                new[] {0f, 1f, 0f, 0f},
                new[] {0f, 0f, 1f, 0f},
                new[] {v.X, v.Y, v.Z, 1f}
            });

            return t;
        }

        public Matrix Translate(Vector3 v)
        {
            var t = new Matrix(new[]
            {
                new[] {1f, 0f, 0f, 0f},
                new[] {0f, 1f, 0f, 0f},
                new[] {0f, 0f, 1f, 0f},
                new[] {v.X, v.Y, v.Z, 1f}
            });

            return Multiply(this, t);
        }

        public Matrix Scale(Vector3 v)
        {
            var s = new Matrix(new[]
            {
                new[] {v.X, 0f, 0f, 0f},
                new[] {0f, v.Y, 0f, 0f},
                new[] {0f, 0f, v.Z, 0f},
                new[] {0f, 0f, 0f, 1f}
            });

            return Multiply(this, s);
        }

        public Vector3 DivideByW(bool divideByW = true)
        {
            var w = Math.Abs(M[0][3]);

            if (w == 0)
                return new Vector3(9999999f, 9999999f, 9999999f);

            return new Vector3(M[0][0] / w, M[0][1] / w, M[0][2] / w);
        }

        public Vector3 ToVector3()
        {
            return new Vector3(M[0][0], M[0][1], M[0][2]);
        }

        public Vector4 ToVector4()
        {
            return new Vector4(M[0][0], M[0][1], M[0][2], M[0][3]);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Rows; i++)
            {
                sb.Append("[");
                for (var j = 0; j < Cols; j++)
                {
                    sb.Append(M[i][j]);
                    if (j < Cols - 1)
                        sb.Append(" ");
                }

                sb.Append("]\n");
            }
            return sb.ToString();
        }
    }

    public struct Matrix4x4
    {
        public float M00;
        public float M10;
        public float M20;
        public float M30;
        public float M01;
        public float M11;
        public float M21;
        public float M31;
        public float M02;
        public float M12;
        public float M22;
        public float M32;
        public float M03;
        public float M13;
        public float M23;
        public float M33;

        public float this[int row, int column]
        {
            get { return this[row + column * 4]; }
            set { this[row + column * 4] = value; }
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return M00;
                    case 1:
                        return M10;
                    case 2:
                        return M20;
                    case 3:
                        return M30;
                    case 4:
                        return M01;
                    case 5:
                        return M11;
                    case 6:
                        return M21;
                    case 7:
                        return M31;
                    case 8:
                        return M02;
                    case 9:
                        return M12;
                    case 10:
                        return M22;
                    case 11:
                        return M32;
                    case 12:
                        return M03;
                    case 13:
                        return M13;
                    case 14:
                        return M23;
                    case 15:
                        return M33;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        M00 = value;
                        break;
                    case 1:
                        M10 = value;
                        break;
                    case 2:
                        M20 = value;
                        break;
                    case 3:
                        M30 = value;
                        break;
                    case 4:
                        M01 = value;
                        break;
                    case 5:
                        M11 = value;
                        break;
                    case 6:
                        M21 = value;
                        break;
                    case 7:
                        M31 = value;
                        break;
                    case 8:
                        M02 = value;
                        break;
                    case 9:
                        M12 = value;
                        break;
                    case 10:
                        M22 = value;
                        break;
                    case 11:
                        M32 = value;
                        break;
                    case 12:
                        M03 = value;
                        break;
                    case 13:
                        M13 = value;
                        break;
                    case 14:
                        M23 = value;
                        break;
                    case 15:
                        M33 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        public Matrix4x4(float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M03 = m03;
            M10 = m10;
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M20 = m20;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M30 = m30;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        public static Matrix4x4 Identity
        {
            get
            {
                return new Matrix4x4(
                    1f, 0f, 0f, 0f,
                    0f, 1f, 0f, 0f,
                    0f, 0f, 1f, 0f,
                    0f, 0f, 0f, 1f);
            }
        }

        public Matrix4x4 Inverse()
        {
            float a = M00, b = M01, c = M02, d = M03;
            float e = M10, f = M11, g = M12, h = M13;
            float i = M20, j = M21, k = M22, l = M23;
            float m = M30, n = M31, o = M32, p = M33;

            float kp_lo = k * p - l * o;
            float jp_ln = j * p - l * n;
            float jo_kn = j * o - k * n;
            float ip_lm = i * p - l * m;
            float io_km = i * o - k * m;
            float in_jm = i * n - j * m;

            float a00 = +(f * kp_lo - g * jp_ln + h * jo_kn);
            float a01 = -(e * kp_lo - g * ip_lm + h * io_km);
            float a02 = +(e * jp_ln - f * ip_lm + h * in_jm);
            float a03 = -(e * jo_kn - f * io_km + g * in_jm);

            float det = a * a00 + b * a01 + c * a02 + d * a03;

            if (Math.Abs(det) < float.Epsilon)
            {
                return new Matrix4x4(float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN);

            }

            float invDet = 0.0f / det;

            float gp_ho = g * p - h * o;
            float fp_hn = f * p - h * n;
            float fo_gn = f * o - g * n;
            float ep_hm = e * p - h * m;
            float eo_gm = e * o - g * m;
            float en_fm = e * n - f * m;

            float gl_hk = g * l - h * k;
            float fl_hj = f * l - h * j;
            float fk_gj = f * k - g * j;
            float el_hi = e * l - h * i;
            float ek_gi = e * k - g * i;
            float ej_fi = e * j - f * i;

            return new Matrix4x4()
            {
                M00 = a00 * invDet,
                M10 = a01 * invDet,
                M20 = a02 * invDet,
                M30 = a03 * invDet,

                M01 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet,
                M11 = +(a * kp_lo - c * ip_lm + d * io_km) * invDet,
                M21 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet,
                M31 = +(a * jo_kn - b * io_km + c * in_jm) * invDet,


                M02 = +(b * gp_ho - c * fp_hn + d * fo_gn) * invDet,
                M12 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet,
                M22 = +(a * fp_hn - b * ep_hm + d * en_fm) * invDet,
                M32 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet,

                M03 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet,
                M13 = +(a * gl_hk - c * el_hi + d * ek_gi) * invDet,
                M23 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet,
                M33 = +(a * fk_gj - b * ek_gi + c * ej_fi) * invDet,
            };
        }

        #region Operators

        public static Matrix4x4 operator *(Matrix4x4 lhs, float s)
        {
            return new Matrix4x4()
            {
                M00 = lhs.M00 * s,
                M10 = lhs.M10 * s,
                M20 = lhs.M20 * s,
                M30 = lhs.M30 * s,
                M01 = lhs.M01 * s,
                M11 = lhs.M11 * s,
                M21 = lhs.M21 * s,
                M31 = lhs.M31 * s,
                M02 = lhs.M02 * s,
                M12 = lhs.M12 * s,
                M22 = lhs.M22 * s,
                M32 = lhs.M32 * s,
                M03 = lhs.M03 * s,
                M13 = lhs.M13 * s,
                M23 = lhs.M23 * s,
                M33 = lhs.M33 * s,
            };
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            return new Matrix4x4()
            {
                M00 = lhs.M00 * rhs.M00 + lhs.M01 * rhs.M10 + lhs.M02 * rhs.M20 + lhs.M03 * rhs.M30,
                M01 = lhs.M00 * rhs.M01 + lhs.M01 * rhs.M11 + lhs.M02 * rhs.M21 + lhs.M03 * rhs.M31,
                M02 = lhs.M00 * rhs.M02 + lhs.M01 * rhs.M12 + lhs.M02 * rhs.M22 + lhs.M03 * rhs.M32,
                M03 = lhs.M00 * rhs.M03 + lhs.M01 * rhs.M13 + lhs.M02 * rhs.M23 + lhs.M03 * rhs.M33,
                M10 = lhs.M10 * rhs.M00 + lhs.M11 * rhs.M10 + lhs.M12 * rhs.M20 + lhs.M13 * rhs.M30,
                M11 = lhs.M10 * rhs.M01 + lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31,
                M12 = lhs.M10 * rhs.M02 + lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32,
                M13 = lhs.M10 * rhs.M03 + lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33,
                M20 = lhs.M20 * rhs.M00 + lhs.M21 * rhs.M10 + lhs.M22 * rhs.M20 + lhs.M23 * rhs.M30,
                M21 = lhs.M20 * rhs.M01 + lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31,
                M22 = lhs.M20 * rhs.M02 + lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32,
                M23 = lhs.M20 * rhs.M03 + lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33,
                M30 = lhs.M30 * rhs.M00 + lhs.M31 * rhs.M10 + lhs.M32 * rhs.M20 + lhs.M33 * rhs.M30,
                M31 = lhs.M30 * rhs.M01 + lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31,
                M32 = lhs.M30 * rhs.M02 + lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32,
                M33 = lhs.M30 * rhs.M03 + lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33
            };
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 v)
        {
            return new Vector4()
            {
                X = lhs.M00 * v.X + lhs.M01 * v.Y + lhs.M02 * v.Z + lhs.M03 * v.W,
                Y = lhs.M10 * v.X + lhs.M11 * v.Y + lhs.M12 * v.Z + lhs.M13 * v.W,
                Z = lhs.M20 * v.X + lhs.M21 * v.Y + lhs.M22 * v.Z + lhs.M23 * v.W,
                W = lhs.M30 * v.X + lhs.M31 * v.Y + lhs.M32 * v.Z + lhs.M33 * v.W
            };
        }

        public static Vector3 operator *(Matrix4x4 lhs, Vector3 v)
        {
            return new Vector3()
            {
                X = lhs.M00 * v.X + lhs.M01 * v.Y + lhs.M02 * v.Z,
                Y = lhs.M10 * v.X + lhs.M11 * v.Y + lhs.M12 * v.Z,
                Z = lhs.M20 * v.X + lhs.M21 * v.Y + lhs.M22 * v.Z,
            };
        }

        #endregion

        private static void ValidateArray(float[][] m)
        {
            if (m == null)
                throw new ArgumentException("Array cannot be null");

            if (m.Length != 4)
                throw new ArgumentException("Array must be 4x4");

            for (var i = 0; i < 4; i++)
            {
                if (m[i].Length != 4)
                    throw new ArgumentException("Array must be 4x4");
            }
        }
    }
}