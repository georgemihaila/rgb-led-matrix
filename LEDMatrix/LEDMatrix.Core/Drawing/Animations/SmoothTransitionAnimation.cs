using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public class SmoothTransitionAnimation<TAction> : PixelValueGetter, IAnimation
        where TAction : class, IDrawAction
    {
        protected TAction _action;
        public double DurationMilliseconds { get; private set; }
        public bool Completed { get; private set; } = false;
        private DateTime _lastTickTimestamp = DateTime.Now;
        private DateTime _startedAt = DateTime.Now;
        private Vector3<double> _transitionPerMillisecond = Vector3<double>.Zero;
        public SmoothTransitionAnimation(IRGBLEDCanvas canvas, TAction action, double durationMilliseconds) : base(canvas, action.To)
        {
            _action = action;
            DurationMilliseconds = durationMilliseconds;
            _transitionPerMillisecond = new Vector3<double>((_action.To.Color.R - From.Color.R) / DurationMilliseconds,(_action.To.Color.G - From.Color.G) / DurationMilliseconds,(_action.To.Color.B - From.Color.B) / DurationMilliseconds);
        }

        public void Tick()
        {
            if (!Completed)
            {
                var millisecondsSinceLastTick = (DateTime.Now - _startedAt).TotalMilliseconds;
                Canvas.AddColorToPixel(From.Position, new Color(_transitionPerMillisecond.X * millisecondsSinceLastTick, _transitionPerMillisecond.Y * millisecondsSinceLastTick, _transitionPerMillisecond.Z * millisecondsSinceLastTick));
                _lastTickTimestamp = DateTime.Now;
                if ((DateTime.Now - _startedAt).TotalMilliseconds >= DurationMilliseconds)
                {
                    Completed = true;
                    Canvas.SetPixel(To);
                }
            }
        }

        public void Play()
        {
            Completed = false;
            _lastTickTimestamp = DateTime.Now;
            _startedAt = DateTime.Now;
        }
    }
}
