using LEDMatrix.Core;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Vectors;
using LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions;
using LEDMatrix.AssemblyHelper.Invocation;

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
        public void Clear()
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("Clear"));
        }

        public void DrawCircle(int x0, int y0, int radius, Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawCircle", (nameof(x0), x0), (nameof(y0), y0), (nameof(radius), radius), (nameof(color), color)));
        }

        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawLine", (nameof(x0), x0), (nameof(y0), y0), (nameof(x1), x1), (nameof(y1), y1), (nameof(color), color)));
        }

        public int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawText", (nameof(font), font), (nameof(x), x), (nameof(y), y), (nameof(color), color), (nameof(text), text), (nameof(spacing), spacing), (nameof(vertical), vertical)));
            return 0;
        }

        public void Fill(Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("Fill", color));
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
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("SetPixel", color));
        }

        public void AddColorToPixel(int x, int y, Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("AddColorToPixelAction", color));
        }

        public void AddColorToPixel(Vector2<int> position, Color color) => AddColorToPixel(position.X, position.Y, color);
    }
}
