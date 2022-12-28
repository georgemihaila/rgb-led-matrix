using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LEDMatrix.Core.Vectors;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public abstract class AnimationBase<TAction> : PixelValueGetter, IAnimation
        where TAction : class, IDrawAction
    {
        protected TAction _action;
        public double DurationMilliseconds { get; private set; }
        public bool Completed { get; private set; } = false;
        public event EventHandler<AnimationRunStatistics> OnAnimationCompleted = delegate { };
        private readonly AnimationUpdateParams _animationUpdateParams = new();

        protected AnimationBase(IRGBLEDCanvas canvas, TAction action, double durationMilliseconds) : base(canvas, action.To)
        {
            _action = action;
            DurationMilliseconds = durationMilliseconds;
        }
        protected abstract void OnUpdateInternal(AnimationUpdateParams updateParams);
        public void Update()
        {
            if (!Completed)
            {
                _animationUpdateParams.MarkUpdated();
                OnUpdateInternal(_animationUpdateParams);
                if (_animationUpdateParams.MillisecondsSinceStarted >= DurationMilliseconds)
                {
                    Completed = true;
                    Canvas.SetPixel(To);
                    OnAnimationCompleted?.Invoke(this, _animationUpdateParams.BuildStatistics());
                }
            }
        }
        public void Play()
        {
            Completed = false;
            _animationUpdateParams.Restart();
        }
    }
}
