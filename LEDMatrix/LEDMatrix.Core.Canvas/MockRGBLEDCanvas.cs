using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Vectors;

using Newtonsoft.Json;

namespace LEDMatrix.Core.Canvas
{
    public class MockRGBLEDCanvas : PixelModifierBase, IRGBLEDCanvas
    {
        public int Width
        {
            get
            {
                return VirtualCanvas.Width;
            }
            set
            {
                VirtualCanvas = new(value, VirtualCanvas.Height, _backgroundColorFunc);
            }
        }
        public int Height
        {
            get
            {
                return VirtualCanvas.Height;
            }
            set
            {
                VirtualCanvas = new(VirtualCanvas.Width, value, _backgroundColorFunc);
            }
        }
        private readonly Func<Color> _backgroundColorFunc = () => Color.Black;
        VirtualCanvas VirtualCanvas { get; set; }
        public MockRGBLEDCanvas()
        {
            VirtualCanvas = new(64, 64, _backgroundColorFunc);
        }

        public void Clear()
        {
            //Console.WriteLine("Cleared matrix");
        }

        public void DrawCircle(int x0, int y0, int radius, Color color)
        {
            Console.WriteLine($"Draw circle {JsonConvert.SerializeObject(new { x0, y0, radius, color })}");
        }

        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            Console.WriteLine($"Draw line {JsonConvert.SerializeObject(new { x0, y0, x1, y1, color })}");
        }

        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            Console.WriteLine($"Draw text {JsonConvert.SerializeObject(new { font, x, y, color, text, spacing, vertical })}");
            return 0;    
        }

        public void Fill(Color color)
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
