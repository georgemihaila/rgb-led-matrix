using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public sealed class ParallelAggregatedAnimation : IAnimation
    {
        private readonly IList<IAnimation> _animations;
        public double DurationMilliseconds { get; private set; }
        public bool Completed { get => _animations.All(x => x.Completed); }

        public ParallelAggregatedAnimation(double durationMilliseconds)
        {
            DurationMilliseconds = durationMilliseconds;
            _animations = new List<IAnimation>();
        }
        public ParallelAggregatedAnimation(double durationMilliseconds, params IAnimation[] animations)
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

        public void Play()
        {
            foreach(var animation in _animations)
            {
                animation.Play();
            }
        }
    }
}
