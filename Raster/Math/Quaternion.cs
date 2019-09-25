using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        #region Private Static Fields
        /// <summary>
        /// 
        /// </summary>
        private static readonly float SlerpEpsilon = 1e-6f;
        #endregion Pirvate Static Fields

        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        /// <summary>
        /// 
        /// </summary>
        public float Z;
        /// <summary>
        /// 
        /// </summary>
		public float W;
        #endregion Public Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Quaternion Zero = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Quaternion Conjugated
        {
            get { return new Quaternion(-X, -Y, -Z, W); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsIdentity
        {
            get { return X == 0.0f && Y == 0.0f && Z == 0.0f && W == 1.0f; }
        }


        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get { return MathF.Sqrt(X * X + Y * Y + Z * Z + W * W); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z + W * W; }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Quaternion(in Quaternion other)
            : this(other.X, other.Y, other.Z, other.W)
        {
        }

        public Quaternion(in Vector4 vec4)
            : this(vec4.X, vec4.Y, vec4.Z, vec4.W)
        {
        }

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion(in Matrix3x3 mat)
        {
            Vector3 u = mat.Column0;
            Vector3 v = mat.Column1;
            Vector3 w = mat.Column2;

            uint u_sign = (MathF.AsUInt(u.X) & 0x80000000);
            float t = v.Y;

            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
            W = 0.0f;
        }

        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Quaternion)
            {
                return Equals((Quaternion)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
            int hash2 = HashHelpers.Combine(Z.GetHashCode(), W.GetHashCode());
            return HashHelpers.Combine(hash1, hash2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Quaternion: X = {0}, Y = {1}, Z = {2}, W = {3}", X, Y, Z, W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Quaternion other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z &&
                   this.W == other.W;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z + W * W;

            if (!MathHelper.IsZero(lenSqr))
            {
                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    X *= invNorm;
                    Y *= invNorm;
                    Z *= invNorm;
                    W *= invNorm;
                }
            }
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Concatenate(in Quaternion value1, in Quaternion value2)
        {
            Concatenate(value1, value2, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Quaternion value1, in Quaternion value2)
        {
            return value1.X * value2.X +
                   value1.Y * value2.Y +
                   value1.Z * value2.Z +
                   value1.W * value1.W;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromAxisAngle(in AxisAngle axisAngle)
        {
            FromAxisAngle(axisAngle, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="yaw"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order)
        {
            FromEulerAngles(eulerAngles, order, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesXYZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXYZ(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesXZY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXZY(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesYXZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXZ(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesYZX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYZX(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesZXY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXY(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Quaternion FromEulerAnglesZYX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZYX(in eulerAngles, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromRotationMatrix(in Matrix3x3 matrix)
        {
            FromRotationMatrix(matrix, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Quaternion FromToRotation(in Vector3 from, in Vector3 to)
        {
            FromToRotation(in from, in to, out Quaternion result);
            return result;
        }

        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Lerp(in Quaternion value1, in Quaternion value2, float factor)
        {
            Lerp(value1, value2, factor, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Normalize(in Quaternion value)
        {
            Normalize(value, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SLerp(in Quaternion value1, in Quaternion value2, float factor)
        {
            Slerp(value1, value2, factor, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Concatenate(in Quaternion value1, in Quaternion value2, out Quaternion result)
        {
            float cx = value2.Y * value1.Z - value2.Z * value1.Y;
            float cy = value2.Z * value1.X - value2.X * value1.Z;
            float cz = value2.X * value1.Y - value2.Y * value1.X;

            float dot = value2.X * value1.X + value2.Y * value1.Y + 
                        value2.Z * value1.Z;

            result.X = value2.X * value1.W + value1.X * value2.W + cx;
            result.Y = value2.Y * value1.W + value1.Y * value2.W + cy;
            result.Z = value2.Z * value1.W + value1.Z * value2.W + cz;
            result.W = value2.W * value1.W - dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void FromAxisAngle(in AxisAngle axisAngle, out Quaternion result)
        {
            float halfAngle = 0.5f * axisAngle.Angle;
            float s = MathF.Sin(halfAngle);
            float c = MathF.Cos(halfAngle);

            result.X = axisAngle.Axis.X * s;
            result.Y = axisAngle.Axis.Y * s;
            result.Z = axisAngle.Axis.Z * s;
            result.W = c;
        }

        public static void FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order, out Quaternion result)
        {
            switch (order)
            {
                case MathF.RotationOrder.XYZ:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                case MathF.RotationOrder.XZY:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YXZ:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YZX:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZXY:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZYX:
                    FromEulerAnglesXYZ(in eulerAngles, out result);
                    break;

                default:
                    FromEulerAnglesZXY(in eulerAngles, out result);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXYZ(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr - sy * sr * cp;
            result.Y = sy * cp * cr + sp * sr * cy;
            result.Z = sr * cp * cy - sp * sy * sr;
            result.W = cp * cy * cr + sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXZY(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr + sy * sr * cp;
            result.Y = sy * cp * cr + sp * sr * cy;
            result.Z = sr * cp * cy - sp * sy * cr;
            result.W = cp * cy * cr - sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYXZ(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr - sy * sr * cp;
            result.Y = sy * cp * cr + sp * sr * cy;
            result.Z = sr * cp * cy + sp * sy * cr;
            result.W = cp * cy * cr - sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYZX(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr - sy * sr * cp;
            result.Y = sy * cp * cr - sp * sr * cy;
            result.Z = sr * cp * cy + sp * sy * cr;
            result.W = cp * cy * cr + sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZXY(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr + sy * sr * cp;
            result.Y = sy * cp * cr - sp * sr * cy;
            result.Z = sr * cp * cy - sp * sy * cr;
            result.W = cp * cy * cr + sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZYX(in EulerAngles eulerAngles, out Quaternion result)
        {
            float sr, cr, sp, cp, sy, cy;

            float halfPitch = 0.5f * eulerAngles.Pitch;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = 0.5f * eulerAngles.Yaw;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            float halfRoll = 0.5f * eulerAngles.Roll;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            result.X = sp * cy * cr + sy * sr * cp;
            result.Y = sy * cp * cr - sp * sr * cy;
            result.Z = sr * cp * cy + sp * sy * cr;
            result.W = cp * cy * cr - sy * sr * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static void FromRotationMatrix(in Matrix3x3 matrix, out Quaternion result)
        {
            float trace = matrix.M00 + matrix.M11 + matrix.M22;
            
            if (trace > 0.0f)
            {
                float s = MathF.Sqrt(trace + 1.0f);
                result.W = s * 0.5f;
                s = 0.5f / s;
                result.X = (matrix.M12 - matrix.M21) * s;
                result.Y = (matrix.M20 - matrix.M02) * s;
                result.Z = (matrix.M01 - matrix.M10) * s;
            } 
            else
            {
                if (matrix.M00 >= matrix.M11 && matrix.M00 >= matrix.M22)
                {
                    float s = MathF.Sqrt(1.0f + matrix.M00 - matrix.M11 - matrix.M22);
                    float invS = 0.5f / s;
                    result.X = 0.5f * s;
                    result.Y = (matrix.M01 + matrix.M10) * invS;
                    result.Z = (matrix.M02 + matrix.M20) * invS;
                    result.W = (matrix.M12 - matrix.M21) * invS;
                }
                else if (matrix.M11 > matrix.M22)
                {
                    float s = MathF.Sqrt(1.0f + matrix.M11 - matrix.M00 - matrix.M22);
                    float invS = 0.5f / s;
                    result.X = (matrix.M10 + matrix.M01) * invS;
                    result.Y = 0.5f * s;
                    result.Z = (matrix.M21 + matrix.M12) * invS;
                    result.W = (matrix.M20 - matrix.M02) * invS;
                }
                else
                {
                    float s = MathF.Sqrt(1.0f + matrix.M22 - matrix.M00 - matrix.M11);
                    float invS = 0.5f / s;
                    result.X = (matrix.M20 + matrix.M02) * invS;
                    result.Y = (matrix.M21 + matrix.M02) * invS;
                    result.Z = 0.5f * s;
                    result.W = (matrix.M01 - matrix.M10) * invS;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="result"></param>
        public static void FromToRotation(in Vector3 from, in Vector3 to, out Quaternion result)
        {
            Vector3.Normalize(from, out Vector3 v0);
            Vector3.Normalize(to, out Vector3 v1);

            float d = Vector3.Dot(v0, v1) + 1.0f;
            if (MathHelper.IsZero(d))
            {
                Vector3.Cross(Vector3.UnitX, v0, out Vector3 axis);
                if (MathHelper.IsZero(axis.LengthSquared))
                {
                    Vector3.Cross(Vector3.UnitY, v0, out axis);
                }

                axis.Normalize();
                result.X = axis.X;
                result.Y = axis.Y;
                result.Z = axis.Z;
                result.W = 0.0f;

                return;
            }

            float sqrt = MathHelper.FastSqrtInverse(2.0f * d);
            float invSqrt = 1.0f / sqrt;
            Vector3 rotationAxis = Vector3.Cross(v0, v1);

            result.X = rotationAxis.X * invSqrt;
            result.Y = rotationAxis.Y * invSqrt;
            result.Z = rotationAxis.Z * invSqrt;
            result.W = sqrt * 0.5f;

            result.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        public static void Lerp(in Quaternion value1, in Quaternion value2, float factor, out Quaternion result)
        {
            float t = factor;
            float t1 = 1.0f - t;

            float dot = value1.X * value2.X + value1.Y * value2.Y +
                        value1.Z * value2.Z + value1.W * value2.W;

            if (dot >= 0.0f)
            {
                result.X = t1 * value1.X + t * value2.X;
                result.Y = t1 * value1.Y + t * value2.Y;
                result.Z = t1 * value1.Z + t * value2.Z;
                result.W = t1 * value1.W + t * value2.W;
            }
            else
            {
                result.X = t1 * value1.X - t * value2.X;
                result.Y = t1 * value1.Y - t * value2.Y;
                result.Z = t1 * value1.Z - t * value2.Z;
                result.W = t1 * value1.W - t * value2.W;
            }

            float lenSqr = result.X * result.X + result.Y * result.Y +
                           result.Z * result.Z + result.W * result.W;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            result.X *= invNorm;
            result.Y *= invNorm;
            result.Z *= invNorm;
            result.W *= invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="t"></param>
        /// <param name="result"></param>
        public static void NLerp(in Quaternion value1, in Quaternion value2, float t, out Quaternion result)
        {
            if (t <= 0.0f)
            {
                result = value1;
                return;
            }
            else if (t >= 1.0f)
            {
                result = value2;
                return;
            }

            result = value2;
            float dot = Quaternion.Dot(value1, value2);
            if (dot < 0.0f)
            {
                result = -value2;
            }

            result.X = value1.X * (1.0f - t) + value2.X * t;
            result.Y = value1.Y * (1.0f - t) + value2.Y * t;
            result.Z = value1.Z * (1.0f - t) + value2.Z * t;
            result.W = value2.W * (1.0f - t) + value2.W * t;
            result.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Quaternion value, out Quaternion result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y +
                           value.Z * value.Z + value.W * value.W;

            if (!MathHelper.IsZero(lenSqr))
            {
                result.X = value.X;
                result.Y = value.Y;
                result.Z = value.Z;
                result.W = value.W;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    result.X *= invNorm;
                    result.Y *= invNorm;
                    result.Z *= invNorm;
                    result.W *= invNorm;
                }
            }
            else
            {
                result = Quaternion.Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        public static void Slerp(in Quaternion value1, in Quaternion value2, float factor, out Quaternion result)
        {
            float t = factor;

            float cosOmega = value1.X * value2.X + value1.Y * value2.Y +
                             value1.Z * value2.Z + value1.W * value2.W;

            bool flip = false;

            if (cosOmega < 0.0f)
            {
                flip = true;
                cosOmega = -cosOmega;
            }

            float s1, s2;

            if (cosOmega > (1.0f - SlerpEpsilon))
            {
                s1 = 1.0f - t;
                s2 = (flip) ? -t : t;
            }
            else
            {
                float omega = MathF.Acos(cosOmega);
                float invSinOmega = 1.0f / MathF.Sin(omega);

                s1 = MathF.Sin((1.0f - t) * omega) *invSinOmega;
                s2 = (flip)
                    ? -MathF.Sin(t * omega) * invSinOmega
                    : MathF.Sin(t * omega) * invSinOmega;
       
            }

            result.X = s1 * value1.X + s2 * value2.X;
            result.Y = s1 * value1.Y + s2 * value2.Y;
            result.Z = s1 * value1.Z + s2 * value2.Z;
            result.W = s1 * value1.W + s2 * value2.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Quaternion value1, in Quaternion value2, out Quaternion result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
            result.W = value1.W + value2.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Quaternion value1, in Quaternion value2, out Quaternion result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
            result.W = value1.W - value2.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Quaternion value1, float value2, out Quaternion result)
        {
            result.X = value1.X * value2;
            result.Y = value1.Y * value2;
            result.Z = value1.Z * value2;
            result.W = value1.W * value2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Quaternion value1, in Quaternion value2, out Quaternion result)
        {
            float cx = value1.X * value2.Z - value1.Z * value2.Y;
            float cy = value1.Z * value2.X - value1.X * value2.Z;
            float cz = value1.X * value2.Y - value1.Y * value2.X;

            float dot = value1.X * value2.X + value1.Y * value2.Y +
                        value1.Z * value2.Z + value1.W * value2.W;

            result.X = value1.X * value2.W + value2.X * value1.W + cx;
            result.Y = value1.Y * value2.W + value2.Y * value1.W + cy;
            result.Z = value1.Z * value2.W + value2.Z * value1.W + cz;
            result.W = value1.W * value2.W - dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Divide(in Quaternion value1, in Quaternion value2, out Quaternion result)
        {
            float q1x = value1.X;
            float q1y = value1.Y;
            float q1z = value1.Z;
            float q1w = value1.W;

            float lenSqr = value2.X * value2.X + value2.Y * value2.Y +
                           value2.Z * value2.Z + value2.W * value2.W;
            float invNorm = 1.0f / lenSqr;

            float q2x = -value2.X * invNorm;
            float q2y = -value2.Y * invNorm;
            float q2z = -value2.Z * invNorm;
            float q2w =  value2.W * invNorm;

            float cx = q1y * q1z - q1z * q2y;
            float cy = q1z * q1x - q1x * q2z;
            float cz = q1x * q1y - q1y * q2x;

            float dot = q1x * q2x + q1y * q2y + q1z * q2z + q1w * q2w;

            result.X = q1x * q2w + q2x * q1w + cx;
            result.Y = q1y * q2w + q2y * q1w + cy;
            result.Z = q1z * q2w + q2z * q1w + cz;
            result.W = q1w * q2w - dot;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator +(in Quaternion left, in Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Quaternion operator -(in Quaternion quaternion)
        {
            return new Quaternion(-quaternion.X, -quaternion.Y, -quaternion.Z, -quaternion.W);
        }
           
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator -(in Quaternion left, in Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator *(in Quaternion left, float right)
        {
            return new Quaternion(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator *(in Quaternion left, in Quaternion right)
        {
            Multiply(left, right, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator /(in Quaternion left, in Quaternion right)
        {
            Divide(left, right, out Quaternion result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Quaternion left, in Quaternion right)
        {
            return left.X == right.X && left.Y == right.Y && 
                   left.Z == right.Z && left.W == right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Quaternion left, in Quaternion right)
        {
            return left.X != right.X || left.Y != right.Y || 
                   left.Z != right.Z || left.W != right.W;
        }

        #endregion Operator Overload                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    }
}