using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Vectors;

using Newtonsoft.Json;

namespace LEDMatrix.Core.Canvas
{
    public class MockRGBLEDCanvas : CanvasWithVirtualCanvas
    {
        public MockRGBLEDCanvas(int width, int height) : base(width, height)
        {
        }

        public override void Clear()
        {
            //Console.WriteLine("Cleared matrix");
        }

        public override void DrawCircle(int x0, int y0, int radius, Color color)
        {
            Console.WriteLine($"Draw circle {JsonConvert.SerializeObject(new { x0, y0, radius, color })}");
        }

        public override void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            Console.WriteLine($"Draw line {JsonConvert.SerializeObject(new { x0, y0, x1, y1, color })}");
        }

        public override int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            Console.WriteLine($"Draw text {JsonConvert.SerializeObject(new { font, x, y, color, text, spacing, vertical })}");
            return 0;    
        }

        public override void Fill(Color color)
        {
            Console.WriteLine($"Fill {color}");
        }

        public override Pixel GetPixel(int x, int y) => new(x, y, VirtualCanvas[x, y]);

        public override void SetPixel(int x, int y, Color color)
        {
            Console.WriteLine($"Setting {(x, y)} to {color}");
            VirtualCanvas[x, y] += color;
        }
    }
}
