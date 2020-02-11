using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Raster.Tests
{
    using Raster.Core.Math;
    using Raster.Core.Math.Geometry;
    using Raster.Drawing.Primitive;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(args[0]);
            float distance = float.Parse(args[1]);

            float distanceSqr = distance * distance;

            Vector3[] array = new Vector3[count];
            Vector3 pos = new Vector3(0.5f, 0.5f, 0.5f);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < count; i++)
            {
                if (Vector3.DistanceSquared(pos, array[i]) < distanceSqr)
                {
                    
                }
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
