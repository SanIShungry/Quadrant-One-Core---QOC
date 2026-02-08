namespace Core;

public class FrameBuffer
{
    public int Width;
    public int Height;
    public byte[] Pixels;

    public FrameBuffer(int w, int h)
    {
        Width = w;
        Height = h;
        Pixels = new byte[w * h];
    }

    public void SetPixel(int x, int y, byte value)
    {
        Pixels[y * Width + x] = value;
    }
}