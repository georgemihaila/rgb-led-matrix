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
        private DoubleVector3 _transitionPerMillisecond = (DoubleVector3)Vector3<double>.Zero;
        public SmoothTransitionAnimation(IRGBLEDCanvas canvas, TAction action, double durationMilliseconds) : base(canvas, action, durationMilliseconds)
        {
            _transitionPerMillisecond = (action.To.Color - From.Color) / DurationMilliseconds;
        }

        protected override void OnUpdateInternal(AnimationUpdateParams updateParams)
        {
            Canvas.AddColorToPixel(From.Position, (_transitionPerMillisecond * updateParams.MillisecondsSinceLastUpdate).ToColor());
        }
    }
}
