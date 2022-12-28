using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core.Canvas
{
    public class MockRGBLEDCanvas : PixelModifierBase, IRGBLEDCanvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        VirtualCanvas VirtualCanvas { get; set; } = new(64, 64, () => Color.Black);
        public void Clear()
        {
             
        }

        public void DrawCircle(int x0, int y0, int radius, Color color)
        {
             
        }

        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
             
        }

        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            return 0;    
        }

        public void Fill(Color color)
        {
             
        }

        public override Pixel GetPixel(int x, int y) => new(x, y, VirtualCanvas[x, y]);

        public override void SetPixel(int x, int y, Color color)
        {
            Console.WriteLine($"Setting {(x, y)} to {color}");
            VirtualCanvas[x, y] += color;
        }
    }
}
