using LEDMatrix.Core.Vectors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public class SmoothTransitionAnimation<TAction> : AnimationBase<TAction>
        where TAction : class, IDrawAction
    {
        private DoubleVector3 _transitionPerMillisecond = DoubleVector3.Zero;
        public SmoothTransitionAnimation(IRGBLEDCanvas canvas, TAction action, double durationMilliseconds) : base(canvas, action, durationMilliseconds)
        {
            _transitionPerMillisecond = (action.To.Color - From.Color) / DurationMilliseconds;
        }

        protected override void OnUpdateInternal(IRGBLEDCanvas canvas, AnimationUpdateParams updateParams)
        {
            canvas.AddColorToPixel(From.Position, (_transitionPerMillisecond * updateParams.MillisecondsSinceLastUpdate).ToColor());
        }

        public override string ToString() => GetType().Name;
    }
}
