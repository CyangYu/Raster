﻿using System;
using Raster.Drawing.Primitive;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    public class Viewport : IEquatable<Viewport>
    {
        #region Public Instance Fields
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
        public float Width;
        /// <summary>
        /// 
        /// </summary>
        public float Height;
        /// <summary>
        /// 
        /// </summary>
        public float MinDepth;
        /// <summary>
        /// 
        /// </summary>
        public float MaxDepth;
        #endregion Public Instance Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float AspectRation
        {
            get
            {
                if (!MathHelper.IsZero(Height))
                {
                    return Width / Height;
                }

                return 0.0f;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public RectangleF Bounds
        {
            get { return new RectangleF(X, Y, Width, Height); }
            set
            {
                X = value.X;
                Y = value.Y;
                Width = value.Width;
                Height = value.Height;
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Viewport(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            MinDepth = 0.0f;
            MaxDepth = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="minDepth"></param>
        /// <param name="maxDepth"></param>
        public Viewport(float x, float y, float width, float height, float minDepth, float maxDepth)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            MinDepth = minDepth;
            MaxDepth = maxDepth;
        }

        public Viewport(in RectangleF bounds)
        {
            X = bounds.X;
            Y = bounds.Y;
            Width = bounds.Width;
            Height = bounds.Height;
            MinDepth = 0.0f;
            MaxDepth = 1.0f;
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
            if (obj is Viewport)
            {
                return Equals((Viewport)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Viewport X: {0}, Y: {1} Width: {2}, Height: {3}, MinDepth: {4}, MaxDepth: {5}",
                                 X, Y, Width, Height, MinDepth, MaxDepth);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Viewport other)
        {
            return this.X == other.X && this.Y == other.Y &&
                   this.Width == other.Width && this.Height == other.Height &&
                   this.MinDepth == other.MinDepth && this.MaxDepth == other.MaxDepth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="world"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <returns></returns>
        public Vector3 Project(in Vector3 position,
                               in Matrix4x4 world, in Matrix4x4 view, in Matrix4x4 projection)
        {
            Matrix4x4.Multiply(world, view, out Matrix4x4 temp);
            Matrix4x4.Multiply(temp, projection, out Matrix4x4 worldViewProjection);

            Project(position, worldViewProjection, out Vector3 vector);
            return vector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="worldViewProjection"></param>
        /// <param name="vector"></param>
        public void Project(in Vector3 position, in Matrix4x4 worldViewProjection, out Vector3 result)
        {
            Vector3.Transform(position, worldViewProjection, out result);
            float a = (position.X * worldViewProjection.M03) + (position.Y * worldViewProjection.M13) +
                      (position.Z * worldViewProjection.M23) + worldViewProjection.M33;

            if (!MathHelper.IsOne(a))
            {
                result.X /= a;
                result.Y /= a;
                result.Z /= a;
            }

            result.X = (((result.X + 1.0f) * 0.5f) * Width) + X;
            result.Y = (((-result.Y + 1.0f) * 0.5f) * Height) + Y;
            result.Z = (result.Z * (MaxDepth - MinDepth)) + MinDepth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="world"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <returns></returns>
        public Vector3 Unproject(in Vector3 position,
                                 in Matrix4x4 world, in Matrix4x4 view, in Matrix4x4 projection)
        {
            Matrix4x4.Multiply(world, view, out Matrix4x4 temp);
            Matrix4x4.Multiply(temp, projection, out Matrix4x4 worldViewProjection);

            Matrix4x4.Inverse(worldViewProjection, out temp);
            Unproject(position, temp, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="invertedWorldViewProjection"></param>
        /// <param name="vector"></param>
        public void Unproject(in Vector3 position, in Matrix4x4 invertedWorldViewProjection, out Vector3 result)
        {
            result.X = (((position.X - X) / Width) * 2.0f) - 1.0f;
            result.Y = -((((position.Y - Y) / Height) * 2.0f) - 1.0f);
            result.Z = (position.Z - MinDepth) / (MaxDepth - MinDepth);

            float a = (result.X * invertedWorldViewProjection.M03) + (result.Y * invertedWorldViewProjection.M13) +
                      (result.Z * invertedWorldViewProjection.M23) + invertedWorldViewProjection.M33;

            Vector3.Transform(result, invertedWorldViewProjection, out Vector3 temp);

            if (!MathHelper.IsOne(a))
            {
                result.X = temp.X / a;
                result.Y = temp.Y / a;
                result.Z = temp.Z / a;
            }
        }

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Viewport left, in Viewport right)
        {
            return left.X == right.X && left.Y == right.Y &&
                   left.Width == right.Width && left.Height == right.Height &&
                   left.MinDepth == right.MinDepth && left.MaxDepth == right.MaxDepth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Viewport left, in Viewport right)
        {
            return left.X != right.X && left.Y != right.Y &&
                   left.Width == right.Width && left.Height == right.Height &&
                   left.MinDepth == right.MinDepth && left.MinDepth == right.MaxDepth;
        }

        #endregion Operator Overload
    }
}
