using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core.Pixels
{
    public interface IPixelModifier : IPixelGetter, IPixelSetter
    {
        public void AddColorToPixel(int x, int y, Color color);
        public void AddColorToPixel(Vector2<int> position, Color color);
    }
}
