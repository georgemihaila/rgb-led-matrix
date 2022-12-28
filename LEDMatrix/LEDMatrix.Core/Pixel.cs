using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core
{
    public class Pixel
    {
        public Pixel() { }
        public Pixel(int x, int y, byte r, byte g, byte b) : this(new Vector2<int>(x, y), new Color(r, g, b)) { }
        public Pixel(int x, int y, Color color) : this(new Vector2<int>(x, y), color)
        {

        }

        public Pixel(Vector2<int> position, Color color)
        {
            Position = position;
            Color = color;
        }

        public Vector2<int> Position { get; set; } = Vector2<int>.Zero;
        public Color Color { get; set; } = Color.White;
    }
}
