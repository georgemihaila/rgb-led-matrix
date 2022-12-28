using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations.Collections
{
    public abstract class AggregatedAnimation : IAnimation, IEnumerable<IAnimation>
    {
        protected readonly IList<IAnimation> _animations;
        protected readonly object _animationsLockObj = new();
        private AnimationRunStatistics _completedAnimationStatistics = new();
        public abstract double DurationMilliseconds { get; }
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

        public event EventHandler<AnimationRunStatistics>? OnAnimationCompleted;

        protected AggregatedAnimation(bool autoremoveOnCompletion = false)
        {
            _animations = new List<IAnimation>();
            _autoremoveOnCompletion = autoremoveOnCompletion;
        }
        protected AggregatedAnimation(bool autoremoveOnCompletion = false, params IAnimation[] animations) : this(autoremoveOnCompletion)
        {
            _animations = new List<IAnimation>(animations);
        }

        public void Add(IAnimation animation)
        {
            if (_autoremoveOnCompletion)
            {
                animation.OnAnimationCompleted += (sender, e) =>
                {
                    if (sender != null)
                        Remove((IAnimation)sender);
                };
            }
            animation.OnAnimationCompleted += Animation_OnAnimationCompleted;
            lock(_animationsLockObj)
                _animations.Add(animation);
        }

        private void Animation_OnAnimationCompleted(object? sender, AnimationRunStatistics e)
        {
            _completedAnimationStatistics = _completedAnimationStatistics.Aggregate(e);
            if (Completed)
            {
                if (sender != null)
                    Console.WriteLine($"{(IAnimation)sender} completed");
                OnAnimationCompleted?.Invoke(this, _completedAnimationStatistics);
            }
        }

        public void Remove(IAnimation animation)
        {
            lock (_animationsLockObj)
            {
                if (_animations.Contains(animation))
                {
                    _animations.Add(animation);
                }
            }
        }

        public abstract void Update(IRGBLEDCanvas canvas);

        public void Play()
        {
            IEnumerable<IAnimation> copy;
            lock (_animationsLockObj)
                copy = _animations.ToList();
            foreach (var animation in copy)
            {
                Console.WriteLine($"Playing {animation}...");
                animation.Play();
            }
        }

        public IEnumerator<IAnimation> GetEnumerator()
        {
            lock (_animationsLockObj)
                return _animations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (_animationsLockObj)
                return ((IEnumerable)_animations).GetEnumerator();
        }
    }
}
