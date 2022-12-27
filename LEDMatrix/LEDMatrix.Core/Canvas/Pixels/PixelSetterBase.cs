namespace LEDMatrix.Core.Canvas.Pixels
{
    public abstract class PixelSetterBase : IPixelSetter
    {

        public abstract void SetPixel(int x, int y, Color color);

        public void SetPixel(Pixel pixel) => SetPixel(pixel.Position.X, pixel.Position.Y, pixel.Color);
    }
}
