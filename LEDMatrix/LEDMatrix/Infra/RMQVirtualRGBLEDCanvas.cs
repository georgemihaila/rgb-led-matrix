using LEDMatrix.Core;
using LEDMatrix.Core.Pixels;
using LEDMatrix.Core.Fonts;
using LEDMatrix.Core.Vectors;
using LEDMatrix.Core.Canvas.Drawing.Remote.DrawActions;
using LEDMatrix.AssemblyHelper.Invocation;
using LEDMatrix.Core.Canvas;

namespace LEDMatrix.Server.Infra
{
    public class RMQVirtualRGBLEDCanvas : CanvasWithVirtualCanvas
    {
        private readonly IDrawActionProducer _drawActionProducer;

        public RMQVirtualRGBLEDCanvas(IDrawActionProducer drawActionProducer, int width = 128, int height = 128) : base(width, height)
        {
            _drawActionProducer = drawActionProducer;
        }
        public override void Clear() => _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("Clear"));

        public override void DrawCircle(int x0, int y0, int radius, Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawCircle", (nameof(x0), x0), (nameof(y0), y0), (nameof(radius), radius), (nameof(color), color)));
        }

        public override void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawLine", (nameof(x0), x0), (nameof(y0), y0), (nameof(x1), x1), (nameof(y1), y1), (nameof(color), color)));
        }

        public override int DrawText(RGBLedFont font, int x, int y, Color color, string text, int spacing = 0, bool vertical = false)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.From("DrawText", (nameof(font), font), (nameof(x), x), (nameof(y), y), (nameof(color), color), (nameof(text), text), (nameof(spacing), spacing), (nameof(vertical), vertical)));
            return 0;
        }

        public override void Fill(Color color)
        {
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("Fill", color));
        }

        public override void SetPixel(int x, int y, Color color)
        {
            VirtualCanvas[x, y] = color;
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("SetPixel", new Pixel(x, y, color)));
        }

        public new void AddColorToPixel(int x, int y, Color color)
        {
            VirtualCanvas[x, y] += color;
            _drawActionProducer.SendActionToQueue(MethodInvocationDescriptor.FromInstance("AddColorToPixelAction", new Pixel(x, y, color)));
        }
    }
}
