using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public class SmoothTransitionAnimation<TAction> : IAnimation
        where TAction : class, IDrawAction
    {
        protected TAction _action;
        public double DurationMilliseconds { get; private set; }

        public SmoothTransitionAnimation(TAction action, double durationMilliseconds)
        {
            _action = action;
            DurationMilliseconds = durationMilliseconds;
        }

        public void Tick()
        {

        }
    }
}
