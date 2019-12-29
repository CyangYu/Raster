using System;
using System.Runtime.InteropServices;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Triangle : IEquatable<Triangle>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex0;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex1;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex2;
        #endregion Public Instance Fields

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Triangle(in Triangle other)
            : this(other.Vertex0, other.Vertex1, other.Vertex2)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex0"></param>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public Triangle(in Vector3 vertex0, in Vector3 vertex1, in Vector3 vertex2)
        {
            Vertex0 = vertex0;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        #endregion Constructor

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Area
        {
            get
            {
                Vector3.Subtract(Vertex1, Vertex0, out Vector3 edge0);
                Vector3.Subtract(Vertex2, Vertex0, out Vector3 edge1);

                Vector3.Cross(edge0, edge1, out Vector3 area);
                return 0.5f * area.Length;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Centroid
        {
            get
            {
                Vector3 centroid;
                float factor = 1.0f / 3.0f;

                centroid.X = (Vertex0.X + Vertex1.X + Vertex2.Z) * factor;
                centroid.Y = (Vertex0.Y + Vertex1.Y + Vertex2.Z) * factor;
                centroid.Z = (Vertex0.Z + Vertex1.Z + Vertex2.Z) * factor;
                return centroid;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Edge0
        {
            get
            {
                Vector3.Subtract(Vertex1, Vertex0, out Vector3 edge0);
                return edge0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Edge1
        {
            get
            {
                Vector3.Subtract(Vertex2, Vertex0, out Vector3 edge1);
                return edge1;
            }
        }

        public Vector3 Edge2
        {
            get
            {
                Vector3.Subtract(Vertex2, Vertex1, out Vector3 edge2);
                return edge2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Perimeter
        {
            get
            {
                float distance0 = Vector3.Distance(Vertex0, Vertex1);
                float distance1 = Vector3.Distance(Vertex1, Vertex2);
                float distance2 = Vector3.Distance(Vertex2, Vertex0);

                return distance0 + distance1 + distance2;
            }
        }

        #endregion Public Instance Properties

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Triangle other)
        {
            return this.Vertex0 == other.Vertex0 &&
                   this.Vertex1 == other.Vertex1 &&
                   this.Vertex2 == other.Vertex2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uv"></param>
        /// <returns></returns>
        public Vector3 PointAt(in Vector2 uv)
        {
            PointAt(this, uv, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uv"></param>
        /// <returns></returns>
        public Vector3 PointAt(in Vector3 uvw)
        {
            PointAt(this, uvw, out Vector3 result);
            return result;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex0"></param>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public static float Area2D(in Vector3 vertex0, in Vector3 vertex1, in Vector3 vertex2)
        {
            return (vertex0.X - vertex1.X) * (vertex1.Y - vertex2.Y) -
                   (vertex1.X - vertex2.X) * (vertex0.Y - vertex1.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex0"></param>
        /// <param name="vertex1"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static float InsideEdge(in Vector3 vertex0, in Vector3 vertex1, in Vector3 point)
        {
            return (point.X - vertex0.X) * (vertex1.Y - vertex0.Y) - 
                   (point.Y - vertex0.Y) * (vertex1.X - vertex0.X);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="uv"></param>
        /// <returns></returns>
        public static Vector3 PointAt(in Triangle triangle, in Vector2 uv)
        {
            PointAt(triangle, uv, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="uv"></param>
        /// <returns></returns>
        public static Vector3 PointAt(in Triangle triangle, in Vector3 uvw)
        {
            PointAt(triangle, uvw, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="uv"></param>
        /// <param name="result"></param>
        public static void PointAt(in Triangle triangle, in Vector2 uv, out Vector3 result)
        {
            PointAt(triangle, uv.X, uv.Y, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="uvw"></param>
        /// <param name="result"></param>
        public static void PointAt(in Triangle triangle, in Vector3 uvw, out Vector3 result)
        {
            PointAt(triangle, uvw.X, uvw.Y, uvw.Z, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="result"></param>
        public static void PointAt(in Triangle triangle, float u, float v, out Vector3 result)
        {
            result.X = triangle.Vertex0.X + ((triangle.Vertex1.X - triangle.Vertex0.X) * u + 
                                             (triangle.Vertex2.X - triangle.Vertex2.X) * v);
            result.Y = triangle.Vertex0.Y + ((triangle.Vertex1.X - triangle.Vertex0.X) * u + 
                                             (triangle.Vertex2.X - triangle.Vertex2.X) * v);
            result.Z = triangle.Vertex0.Z + ((triangle.Vertex1.X - triangle.Vertex0.X) * u + 
                                             (triangle.Vertex2.X - triangle.Vertex2.X) * v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="result"></param>
        public static void PointAt(in Triangle triangle, float u, float v, float w, out Vector3 result)
        {
            result.X = u * triangle.Vertex0.X + v * triangle.Vertex1.X + w * triangle.Vertex2.X;
            result.Y = u * triangle.Vertex0.Y + v * triangle.Vertex1.Y + w * triangle.Vertex2.Y;
            result.Z = u * triangle.Vertex0.Z + v * triangle.Vertex1.Z + w * triangle.Vertex2.Z;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="vertex0"></param>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public static float SignedArea(in Vector3 point, in Vector3 vertex0, in Vector3 vertex1, in Vector3 vertex2)
        {
            Vector3.Cross(vertex1 - point, vertex2 - point, out Vector3 v0);
            Vector3.Cross(vertex1 - vertex0, vertex2 - vertex0, out Vector3 v1);

            v1.Normalize();
            return Vector3.Dot(v0, v1);
        }

        #endregion Public Static Methods
    }
}
