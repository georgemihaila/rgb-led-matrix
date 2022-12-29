using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core.Pixels
{
    public interface IPixelSetter
    {
        public void SetPixel(int x, int y, Color color);
        public void SetPixel(Vector2<int> position, Color color);
        public void SetPixel(Pixel pixel);
        public void SetPixels(params Pixel[] pixels);
    }
}
