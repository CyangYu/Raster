using System;
using System.Runtime.CompilerServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public struct EulerAngles : IEquatable<EulerAngles>
    {
		#region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float Pitch;
        /// <summary>
        /// 
        /// </summary>
        public float Roll;
        /// <summary>
        /// 
        /// </summary>
        public float Yaw;
		#endregion Public Fields
		
		#region Constructor
        public EulerAngles(Vector3 vec3)
            : this(vec3.X, vec3.Y, vec3.Z)
        {
        }
		
		public EulerAngles(in EulerAngles euler)
			: this(euler.Pitch, euler.Roll, euler.Yaw)
		{
		}
		
        public EulerAngles(float pitch, float roll, float yaw)
        {
            Pitch = pitch;
            Roll  = roll;
            Yaw   = yaw;
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
            if (obj is EulerAngles)
            {
                return Equals((EulerAngles)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = HashHelpers.Combine(Pitch.GetHashCode(), Roll.GetHashCode());
            return HashHelpers.Combine(hash, Yaw.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("EulerAngles: Pitch = {0}, Roll = {1}, Yaw = {2}", Pitch, Roll, Yaw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EulerAngles other) => this == other;

        #endregion Public Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EulerAngles FromQuaternion(float x, float y, float z, float w)
        {
            float xx = x * x;
            float xy = x * y;
            float xz = x * z;
            float xw = x * w;
            float yy = y * y;
            float yz = y * z;
            float yw = y * w;
            float zz = z * z;
            float zw = z * w;

            float lenSqr = xx + yy + zz + w * w;
            if (!MathHelper.IsOne(lenSqr) && !MathHelper.IsZero(lenSqr))
            {
                xx /= lenSqr;
                xy /= lenSqr;
                xz /= lenSqr;
                xw /= lenSqr;
                yy /= lenSqr;
                yz /= lenSqr;
                yw /= lenSqr;
                zz /= lenSqr;
                zw /= lenSqr;
            }

            EulerAngles euler;

            euler.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (euler.Pitch < MathF.PI_2)
            {
                if (euler.Pitch > -MathF.PI_2)
                {
                    euler.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    euler.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                } 
                else
                {
                    euler.Roll = 0.0f;
                    euler.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                euler.Roll = 0.0f;
                euler.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }

            euler.Pitch = MathF.RadToDeg(euler.Pitch);
            euler.Roll = MathF.RadToDeg(euler.Roll);
            euler.Yaw = MathF.RadToDeg(euler.Yaw);

            return euler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quat"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EulerAngles FromQuaternion(in Quaternion quaternion) =>
            FromQuaternion(quaternion.W, quaternion.X, quaternion.Y, quaternion.Z);

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in EulerAngles left, in EulerAngles right) =>
            left.Pitch == right.Pitch && left.Roll == right.Roll && left.Yaw == right.Yaw;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in EulerAngles left, in EulerAngles right) =>
           left.Pitch != right.Pitch || left.Roll != right.Roll || left.Yaw != right.Yaw;

        #endregion Operator Overload
    }
}
