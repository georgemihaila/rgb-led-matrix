using LEDMatrix.Core.Canvas.Drawing.Transitions;

namespace LEDMatrix.Core.Canvas.Drawing.Drawing.Actions.Pixels
{
    public class AddColorToPixelAction : PixelValueGetter
    {
        public AddColorToPixelAction(IRGBLEDCanvas canvas, int x, int y, Color delta) : base(canvas, new(x, y, delta))
        {
        }
        public AddColorToPixelAction(IRGBLEDCanvas canvas, Vector2<int> position, Color delta) : base(canvas, new(position, delta))
        {
        }
    }
}
