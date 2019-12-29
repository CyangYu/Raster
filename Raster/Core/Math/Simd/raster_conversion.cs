using System;
using Raster.Core.Math;

namespace Raster.Core.Math.Simd
{
    public partial struct float2
    {
        public static implicit operator Vector2(float2 v) { return new Vector2(v.x, v.y); }
        public static implicit operator float2(Vector2 v) { return new float2(v.X, v.Y); }
    }

    public partial struct float3
    {
        public static implicit operator Vector3(float3 v) { return new Vector3(v.x, v.y, v.z); }
        public static implicit operator float3(Vector3 v) { return new float3(v.X, v.Y, v.Z); }
    }

    public partial struct float4
    {
        public static implicit operator Vector4(float4 v) { return new Vector4(v.x, v.y, v.z, v.w); }
        public static implicit operator float4(Vector4 v) { return new float4(v.X, v.Y, v.Z, v.W); }
    }

    public partial struct quaternion
    {
        public static implicit operator Quaternion(quaternion q) { return new Quaternion(q.value.x, q.value.y, q.value.z, q.value.w); }
        public static implicit operator quaternion(Quaternion q) { return new quaternion(q.X, q.Y, q.Z, q.W); }
    }

    public partial struct float2x2
    {
        public static implicit operator float2x2(in Matrix2x2 m) { return new float2x2(m.M00, m.M01, m.M10, m.M11); }
        public static implicit operator Matrix2x2(in float2x2 m) { return new Matrix2x2(m.c0.x, m.c1.x, m.c0.y, m.c1.y); }
    }

    public partial struct float2x3
    {
        public static implicit operator float2x3(in Matrix2x3 m) { return new float2x3(m.M00, m.M01, m.M02, m.M10, m.M11, m.M12); }
        public static implicit operator Matrix2x3(in float2x3 m) { return new Matrix2x3(m.c0.x, m.c1.x, m.c2.x, m.c0.y, m.c1.y, m.c2.y); }
    }

    public partial struct float2x4
    {
        public static implicit operator float2x4(in Matrix2x4 m) { return new float2x4(m.M00, m.M01, m.M02, m.M03, m.M10, m.M11, m.M12, m.M13); }
        public static implicit operator Matrix2x4(in float2x4 m) { return new Matrix2x4(m.c0.x, m.c1.x, m.c2.x, m.c3.x, m.c0.y, m.c1.y, m.c2.y, m.c3.y); }
    }

    public partial struct float3x2
    {
        public static implicit operator float3x2(in Matrix3x2 m) { return new float3x2(m.M00, m.M01, m.M10, m.M11, m.M20, m.M21); }
        public static implicit operator Matrix3x2(in float3x2 m) { return new Matrix3x2(m.c0.x, m.c1.x, m.c0.y, m.c1.y, m.c0.z, m.c1.z); }
    }

    public partial struct float3x3
    {
        public static implicit operator float3x3(in Matrix3x3 m) { return new float3x3(m.M00, m.M01, m.M02, m.M10, m.M11, m.M12, m.M20, m.M21, m.M22); }
        public static implicit operator Matrix3x3(in float3x3 m) { return new Matrix3x3(m.c0.x, m.c1.x, m.c2.x, m.c0.y, m.c1.y, m.c2.y, m.c0.z, m.c1.z, m.c2.z); }
    }

    public partial struct float3x4
    {
        public static implicit operator float3x4(in Matrix3x4 m) { return new float3x4(m.M00, m.M01, m.M02, m.M03, m.M10, m.M11, m.M12, m.M13, m.M20, m.M21, m.M22, m.M23); }
        public static implicit operator Matrix3x4(in float3x4 m) { return new Matrix3x4(m.c0.x, m.c1.x, m.c2.x, m.c3.x, m.c0.y, m.c1.y, m.c2.y, m.c3.y, m.c0.z, m.c1.z, m.c2.z, m.c3.z); }
    }

    public partial struct float4x2
    {
        public static implicit operator float4x2(in Matrix4x2 m) { return new float4x2(m.M00, m.M01, m.M10, m.M11, m.M20, m.M21, m.M30, m.M31); }
        public static implicit operator Matrix4x2(in float4x2 m) { return new Matrix4x2(m.c0.x, m.c1.x, m.c0.y, m.c1.y, m.c0.z, m.c1.z, m.c0.w, m.c1.w); }
    }

    public partial struct float4x3
    {
        public static implicit operator float4x3(in Matrix4x3 m) { return new float4x3(m.M00, m.M01, m.M02, m.M10, m.M11, m.M12, m.M20, m.M21, m.M22, m.M30, m.M31, m.M32); }
        public static implicit operator Matrix4x3(in float4x3 m) { return new Matrix4x3(m.c0.x, m.c1.x, m.c2.x, m.c0.y, m.c1.y, m.c2.y, m.c0.z, m.c1.z, m.c2.z, m.c0.w, m.c1.w, m.c2.w); }
    }

    public partial struct float4x4
    {
        public static implicit operator float4x4(in Matrix4x4 m) { return new float4x4(m.M00, m.M01, m.M02, m.M03, m.M10, m.M11, m.M12, m.M13, m.M20, m.M21, m.M22, m.M23, m.M30, m.M31, m.M32, m.M33); }
        public static implicit operator Matrix4x4(in float4x4 m) { return new Matrix4x4(m.c0.x, m.c1.x, m.c2.x, m.c3.x, m.c0.y, m.c1.y, m.c2.y, m.c3.y, m.c0.z, m.c1.z, m.c2.z, m.c3.z, m.c0.w, m.c1.w, m.c2.w, m.c3.w); }
    }
}
