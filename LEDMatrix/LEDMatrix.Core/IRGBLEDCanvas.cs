using LEDMatrix.Core.Fonts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public interface IRGBLEDCanvas
    {
        public int Width { get; }
        public int Height { get; }
        public void SetPixel(int x, int y, Color color);
        public void Fill(Color color);
        public void Clear();
        public void DrawCircle(int x0, int y0, int radius, Color color);
        public void DrawLine(int x0, int y0, int x1, int y1, Color color);
        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false);
        internal IntPtr _canvasPtr { get; set; }
    }
}
