using LEDMatrix.Core.Vectors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations.Pixels
{
    public class LinearTransitionAnimation<TAction> : AnimationBase<TAction>
        where TAction : class, IDrawAction
    {
        private DoubleVector3 _colorTransitionPerMillisecond = DoubleVector3.Zero;
        public LinearTransitionAnimation(IRGBLEDCanvas canvas, TAction action, double durationMilliseconds) : base(canvas, action, durationMilliseconds)
        {
            _colorTransitionPerMillisecond = (action.To.Color - From.Color) / DurationMilliseconds;
        }

        protected override void OnUpdateInternal(IRGBLEDCanvas canvas, AnimationUpdateParams updateParams)
        {
            canvas.AddColorToPixel(From.Position, (_transitionPerMillisecond * updateParams.MillisecondsSinceLastUpdate).ToColor());
        }

        public override string ToString() => GetType().Name;
    }
}
