using LEDMatrix.Core.Drawing.Actions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public class SmoothTransitionAnimation<T> : IAnimation
        where T : class, IDrawAction
    {
        protected T _action;
        public double DurationMilliseconds { get; private set; }

        public SmoothTransitionAnimation(T action, double durationMilliseconds)
        {
            _action = action;
            DurationMilliseconds = durationMilliseconds;
        }

    }
}
