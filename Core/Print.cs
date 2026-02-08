namespace Core
{
    public static class Print
    {
        public static void ToConsole(FrameBuffer fb)
        {
            for (int y = 0; y < fb.Height; y++)
            {
                for (int x = 0; x < fb.Width; x++)
                {
                    byte v = fb.Pixels[y * fb.Width + x];

                    char c =
                        v > 200 ? '#' :
                        v > 120 ? '*' :
                        v > 50 ? '.' :
                        ' ';
                    
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }

        public static void ToBmp(FrameBuffer fb, string path)
        {
            int width = fb.Width;
            int height = fb.Height;

            int rowSize = (width * 3 + 3) & ~3;
            int pixelDataSize = rowSize * height;
            int fileSize = 54 + pixelDataSize;
            
            using var bw = new BinaryWriter(File.Create(path));
            
            bw.Write((byte)'B');
            bw.Write((byte)'M');
            bw.Write(fileSize);
            bw.Write(0);
            bw.Write(54);
            
            bw.Write(40);
            bw.Write(width);
            bw.Write(height);
            bw.Write((short)1);
            bw.Write((short)24); // RGB 24bit
            bw.Write(0);
            bw.Write(pixelDataSize);
            bw.Write(0);
            bw.Write(0);
            bw.Write(0);
            bw.Write(0);
            
            for (int y = height - 1; y >= 0; y--)
            {
                int padding = rowSize - width * 3;

                for (int x = 0; x < width; x++)
                {
                    byte v = fb.Pixels[y * width + x];
                    bw.Write(v); // B
                    bw.Write(v); // G
                    bw.Write(v); // R
                }
                for (int p = 0; p < padding; p++)
                    bw.Write((byte)0);
            }    
        }
    }
}