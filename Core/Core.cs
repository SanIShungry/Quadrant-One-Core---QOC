using System.Numerics;

namespace Core
{
    class Program
    {
        static void Main()
        {
            int width = 80;
            int height = 40;

            Camera cam = new Camera
            {
                Position = Vector3.Zero,
                Forward = Vector3.UnitZ,
                Right = Vector3.UnitX,
                Up = Vector3.UnitY,
                Width = width,
                Height = height,
                Fov = MathF.PI / 3f
            };
            
            FrameBuffer fb = new FrameBuffer(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Ray ray = cam.GetRay(x, y);

                    float dx = x - width / 2f;
                    float dy = y - height / 2f;
                    float d = MathF.Sqrt(dx * dx + dy * dy);
                    
                    byte v = d < height * 0.4f ? (byte)255 : (byte)0;
                    fb.SetPixel(x, y, v);
                }
            }
            
            Print.ToBmp(fb, "qoc.bmp");
            
            Console.WriteLine("\nQOC toasted.");
        }
    }
}