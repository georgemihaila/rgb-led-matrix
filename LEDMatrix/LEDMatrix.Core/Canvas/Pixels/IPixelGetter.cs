namespace LEDMatrix.Core.Canvas.Pixels
{
    public interface IPixelGetter
    {
        public Pixel GetPixel(int x, int y);
        public Pixel GetPixel(Pixel pixel);
    }
}
