using LEDMatrix.Core.Drawing.Transitions;

namespace LEDMatrix.Core.Drawing.Actions.Pixels
{
    public class SetPixelAction : PixelValueGetter
    {
        public SetPixelAction(IRGBLEDCanvas canvas, Pixel to) : base(canvas, to)
        {
        }
    }
}
