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
            string content = File.ReadAllText(args[0]);
            string[] numbers = content.Split(',');

            Matrix4x4 matrix = Matrix4x4.Zero;

            for (int i = 0; i < numbers.Length; i++)
            {
                matrix[i] = float.Parse(numbers[i]);
            }
        }
    }
}
