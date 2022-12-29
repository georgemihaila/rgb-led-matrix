using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core.Pixels
{
    public abstract class PixelSetterBase : IPixelSetter
    {

        public abstract void SetPixel(int x, int y, Color color);

        public void SetPixel(Pixel pixel) => SetPixel(pixel.Position, pixel.Color);

        public void SetPixel(Vector2<int> position, Color color) => SetPixel(position.X, position.Y, color);

        public void SetPixels(params Pixel[] pixels)
        {
            foreach(var pixel in pixels)
            {
                SetPixel(pixel);
            }
        }
    }
}
