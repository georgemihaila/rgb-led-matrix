namespace LEDMatrix.Core.Canvas.Pixels
{
    public abstract class PixelModifierBase : PixelSetterBase, IPixelModifier
    {
        public abstract Pixel GetPixel(int x, int y);
        public void AddColorToPixel(int x, int y, Color color)
        {
            var oldValue = GetPixel(x, y).Color;
            SetPixel(x, y, new Color(oldValue.R + color.R, oldValue.G + color.G, oldValue.B + color.B));
        }
        public void AddColorToPixel(Vector2<int> position, Color color) => AddColorToPixel(position.X, position.Y, color);
        public Pixel GetPixel(Pixel pixel) => GetPixel(pixel.Position.X, pixel.Position.Y);
    }
}
