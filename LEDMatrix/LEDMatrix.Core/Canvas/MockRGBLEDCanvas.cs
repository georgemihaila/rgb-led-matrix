using LEDMatrix.Core.Canvas.Pixels;
using LEDMatrix.Core.Fonts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas
{
    public class MockRGBLEDCanvas : PixelSetterBase, IRGBLEDCanvas
    {
        public int Width { get; }
        public int Height { get; }
        IntPtr IRGBLEDCanvas.CanvasPtr { get; set; }

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

        public Pixel GetPixel(int x, int y)
        {
            return new Pixel(0, 0, Color.Red);
        }

        public Pixel GetPixel(Pixel pixel)
        {
            return new Pixel(0, 0, Color.Red);
        }
        public override void SetPixel(int x, int y, Color color)
        {

        }

        void IPixelModifier.AddColorToPixel(int x, int y, Color color)
        {
        }

        void IPixelModifier.AddColorToPixel(Vector2<int> position, Color color)
        {
        }
    }
}
