using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Pixels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas
{
    public abstract class CanvasWithVirtualCanvas : PixelModifierBase, IRGBLEDCanvas
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
        protected VirtualCanvas VirtualCanvas { get;  set; }
        public CanvasWithVirtualCanvas(int width, int height)
        {
            VirtualCanvas = new(width, height, _backgroundColorFunc);
        }
        public override Pixel GetPixel(int x, int y) => new(x, y, VirtualCanvas[x, y]);
        public abstract void Fill(Color color);
        public abstract void Clear();
        public abstract void DrawCircle(int x0, int y0, int radius, Color color);
        public abstract void DrawLine(int x0, int y0, int x1, int y1, Color color);
        public abstract int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false);
    }
}
