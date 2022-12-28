using LEDMatrix.Core.Canvas.Drawing.Transitions;

namespace LEDMatrix.Core.Canvas.Drawing.Actions.Pixels
{
    public class SetPixelAction : PixelValueGetter
    {
        public SetPixelAction(IRGBLEDCanvas canvas, Pixel to) : base(canvas, to)
        {
        }
    }
}
