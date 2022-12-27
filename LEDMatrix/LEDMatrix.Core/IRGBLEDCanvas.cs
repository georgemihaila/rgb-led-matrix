using LEDMatrix.Core.Fonts;

namespace LEDMatrix.Core
{
    public interface IRGBLEDCanvas : IPixelGetter, IPixelSetter
    {
        public int Width { get; }
        public int Height { get; }
        public void Fill(Color color);
        public void Clear();
        public void DrawCircle(int x0, int y0, int radius, Color color);
        public void DrawLine(int x0, int y0, int x1, int y1, Color color);
        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false);
        public IntPtr CanvasPtr { get; set; }
    }
}
