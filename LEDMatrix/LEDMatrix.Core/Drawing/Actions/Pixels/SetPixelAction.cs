using LEDMatrix.Core.Drawing.Transitions;

namespace LEDMatrix.Core.Drawing.Actions.Pixels
{
    public class SetPixelAction : ITransition1, IDrawAction
    {
        public Pixel From { get; private set; }
        public Pixel To { get; private set; }
        public IRGBLEDCanvas Canvas { get; }

        public SetPixelAction(IRGBLEDCanvas canvas, Pixel from, Pixel to)
        {
            From = from;
            To = to;
            Canvas = canvas;
        }
    }
}
