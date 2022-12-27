using LEDMatrix.Core;
using LEDMatrix.Core.Canvas;
using LEDMatrix.Core.Drawing.Actions.Pixels;
using LEDMatrix.Core.Fonts;

namespace LEDMatrix.Server.Infra
{
    public class RMQVirtualRGBLEDCanvas : PixelSetterBase, IRGBLEDCanvas
    {
        private readonly IDrawActionProducer _drawActionProducer;

        public RMQVirtualRGBLEDCanvas(IDrawActionProducer drawActionProducer)
        {
            _drawActionProducer = drawActionProducer;
        }

        public int Width { get; private set; } = 64;
        public int Height { get; private set; } = 64;
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
            _drawActionProducer.SendActionToQueue(new SetPixelAction(this, new Pixel(x, y, color)));
        }
    }
}
