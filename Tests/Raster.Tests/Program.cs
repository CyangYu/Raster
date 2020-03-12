using System;
using System.Diagnostics;
using System.IO;

namespace Raster.Tests
{
    using Raster.Core.Math;
    using Raster.Core.Math.Geometry;
    using Raster.Drawing.Primitive;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Vector3 v0 = new Vector3(0.1f, 0.2f, 0.3f);
            Vector3 v1 = v0;

            Console.WriteLine(v1.ToString());
        }
    }
}
