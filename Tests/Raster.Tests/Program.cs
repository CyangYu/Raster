using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Raster.Tests
{
    using Raster.Math;
    using Raster.Math.Geometry;
    using Raster.Drawing.Primitive;
    class Program
    {
        static void Main(string[] args)
        {
            Rgba[] frameBuffer = new Rgba[320 * 240];

            Color color0 = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Color color1 = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            Color color2 = new Color(0.0f, 0.0f, 1.0f, 1.0f);

            Triangle triangle = new Triangle(new Vector3( 160.0f, 80.0f, 0.0f),
                                             new Vector3( 80.0f, 180.0f, 0.0f),
                                             new Vector3( 240.0f, 180.0f, 0.0f));

            triangle.Vertex0.X = (triangle.Vertex0.X * 0.5f + 0.5f) * 320.0f;
            triangle.Vertex0.Y = (triangle.Vertex0.Y * 0.5f + 0.5f) * 240.0f;
            triangle.Vertex1.X = (triangle.Vertex1.X * 0.5f + 0.5f) * 320.0f;
            triangle.Vertex1.Y = (triangle.Vertex1.Y * 0.5f + 0.5f) * 240.0f;
            triangle.Vertex2.X = (triangle.Vertex2.X * 0.5f + 0.5f) * 320.0f;
            triangle.Vertex2.Y = (triangle.Vertex2.Y * 0.5f + 0.5f) * 240.0f;

            float area = Triangle.InsideEdge(triangle.Vertex0, triangle.Vertex1, triangle.Vertex2);
            Console.WriteLine(area);

            Rgba pixel = new Rgba(0x00, 0x00, 0x00, 0x00);

            Vector3 uv = new Vector3(0.0f);

            for (int i = 0; i < 320; i++)
            {
                for (int j = 0; j < 240; j++)
                {
                    uv.X = i + 0.5f;
                    uv.Y = j + 0.5f;

                    float w0 = Triangle.InsideEdge(triangle.Vertex1, triangle.Vertex2, uv);
                    float w1 = Triangle.InsideEdge(triangle.Vertex2, triangle.Vertex0, uv);
                    float w2 = Triangle.InsideEdge(triangle.Vertex0, triangle.Vertex1, uv);

                    if (w0 >= 0.0f && w1 >= 0.0f && w2 >= 0.0f)
                    {
                        w0 /= area;
                        w1 /= area;
                        w2 /= area;

                        float r = w0 * color0.R + w1 * color1.R + w2 * color2.R;
                        float g = w0 * color0.G + w1 * color1.G + w2 * color2.G;
                        float b = w0 * color0.B + w1 * color1.B + w2 * color2.B;

                        int index = j * 320 + i;
                        frameBuffer[index].R = (byte)(r * 255.0f);
                        frameBuffer[index].G = (byte)(g * 255.0f);
                        frameBuffer[index].B = (byte)(b * 255.0f);
                        frameBuffer[index].A = 0xFF;

                        Console.WriteLine(frameBuffer[index]);
                    }
                }
            }

            IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(frameBuffer, 0);
            Bitmap bitmap = new Bitmap(320, 240, 320 * 4, PixelFormat.Format32bppRgb, ptr);
            bitmap.Save("triangle.png", ImageFormat.Png);

        }
    }
}
