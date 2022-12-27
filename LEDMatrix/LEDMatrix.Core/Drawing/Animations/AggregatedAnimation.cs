﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public sealed class AggregatedAnimation : IAnimation
    {
        private readonly IList<IAnimation> _animations;
        public double DurationMilliseconds { get; private set; }
        public AggregatedAnimation(double durationMilliseconds)
        {
            DurationMilliseconds = durationMilliseconds;
            _animations = new List<IAnimation>();
        }
        public AggregatedAnimation(double durationMilliseconds, params IAnimation[] animations)
        {
            DurationMilliseconds = durationMilliseconds;
            _animations = new List<IAnimation>(animations);
        }

        public void Add(IAnimation animation)
        {
            _animations.Add(animation);
        }

        public void Tick()
        {
            foreach(var animation in _animations)
            {
                animation.Tick();
            }
        }
    }
}
