using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public sealed class ParallelAggregatedAnimation : IAnimation, IEnumerable<IAnimation>
    {
        private readonly IList<IAnimation> _animations;
        private AnimationRunStatistics _completedAnimationStatistics = new();
        public double DurationMilliseconds { get; private set; }
        public bool Completed
        {
            get
            {
                if (_animations.Count == 0)
                    return true;

                return _animations.All(x => x.Completed);
            }
        }
        private readonly bool _autoremoveOnCompletion;

        public event EventHandler<AnimationRunStatistics> OnAnimationCompleted;

        public ParallelAggregatedAnimation(double durationMilliseconds, bool autoremoveOnCompletion = false)
        {
            DurationMilliseconds = durationMilliseconds;
            _animations = new List<IAnimation>();
            _autoremoveOnCompletion = autoremoveOnCompletion;
        }
        public ParallelAggregatedAnimation(double durationMilliseconds, bool autoremoveOnCompletion = false, params IAnimation[] animations) : this(durationMilliseconds, autoremoveOnCompletion)
        {
            _animations = new List<IAnimation>(animations);
        }

        public void Add(IAnimation animation)
        {
            if (_autoremoveOnCompletion)
            {
                animation.OnAnimationCompleted += (object? sender, AnimationRunStatistics e) =>
                {
                    if (sender != null)
                        Remove((IAnimation)sender);
                };
            }
            animation.OnAnimationCompleted += Animation_OnAnimationCompleted;
            _animations.Add(animation);
        }

        private void Animation_OnAnimationCompleted(object? sender, AnimationRunStatistics e)
        {
            _completedAnimationStatistics = _completedAnimationStatistics.Aggregate(e);
            if (Completed)
            {
                OnAnimationCompleted(this, _completedAnimationStatistics);
            }
        }

        public void Remove(IAnimation animation)
        {
            if (_animations.Contains(animation))
            {
                _animations.Add(animation);
            }
        }

        public void Update()
        {
            foreach (var animation in _animations)
            {
                animation.Update();
            }
        }

        public void Play()
        {
            foreach (var animation in _animations)
            {
                animation.Play();
            }
        }

        public IEnumerator<IAnimation> GetEnumerator()
        {
            return _animations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_animations).GetEnumerator();
        }
    }
}
