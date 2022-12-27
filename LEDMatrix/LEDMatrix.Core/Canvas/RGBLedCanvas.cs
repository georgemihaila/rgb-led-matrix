using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LEDMatrix.Core.Canvas.Pixels;
using LEDMatrix.Core.Fonts;

namespace LEDMatrix.Core.Canvas
{
    public class RGBLedCanvas : PixelModifierBase, IRGBLEDCanvas
    {
        #region DLLImports
        [DllImport("librgbmatrix.so")]
        internal static extern void led_canvas_get_size(IntPtr canvas, out int width, out int height);

        [DllImport("librgbmatrix.so")]
        internal static extern void led_canvas_set_pixel(IntPtr canvas, int x, int y, byte r, byte g, byte b);

        [DllImport("librgbmatrix.so")]
        internal static extern void led_canvas_clear(IntPtr canvas);

        [DllImport("librgbmatrix.so")]
        internal static extern void led_canvas_fill(IntPtr canvas, byte r, byte g, byte b);

        [DllImport("librgbmatrix.so")]
        internal static extern void draw_circle(IntPtr canvas, int xx, int y, int radius, byte r, byte g, byte b);

        [DllImport("librgbmatrix.so")]
        internal static extern void draw_line(IntPtr canvas, int x0, int y0, int x1, int y1, byte r, byte g, byte b);
        #endregion

        // This is a wrapper for canvas no need to implement IDisposable here 
        // because RGBLedMatrix has ownership and takes care of disposing canvases
        internal IntPtr _canvas;

        // this is not called directly by the consumer code,
        // consumer uses factory methods in RGBLedMatrix
        internal RGBLedCanvas(IntPtr canvas)
        {
            _canvas = canvas;
            int width;
            int height;
            led_canvas_get_size(_canvas, out width, out height);
            Width = width;
            Height = height;
            VirtualCanvas = new VirtualCanvas(Width, Height, () => Color.FromRGB(0));
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        IntPtr IRGBLEDCanvas.CanvasPtr { get; set; }
        private VirtualCanvas VirtualCanvas { get; set; }
        public override void SetPixel(int x, int y, Color color)
        {
            VirtualCanvas[x, y] = color;
            led_canvas_set_pixel(_canvas, x, y, color.R, color.G, color.B);
        }

        public void Fill(Color color)
        {
            led_canvas_fill(_canvas, color.R, color.G, color.B);
        }

        public void Clear()
        {
            led_canvas_clear(_canvas);
        }

        public void DrawCircle(int x0, int y0, int radius, Color color)
        {
            draw_circle(_canvas, x0, y0, radius, color.R, color.G, color.B);
        }

        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            draw_line(_canvas, x0, y0, x1, y1, color.R, color.G, color.B);
        }

        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            return font.DrawText(_canvas, x, y, color, text, spacing, vertical);
        }

        public override Pixel GetPixel(int x, int y) => new(x, y, VirtualCanvas[x, y]);
    }
}
