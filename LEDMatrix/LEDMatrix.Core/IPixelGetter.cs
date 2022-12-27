namespace LEDMatrix.Core
{
    public interface IPixelGetter
    {
        public Pixel GetPixel(int x, int y);
        public Pixel GetPixel(Pixel pixel);
    }
}
