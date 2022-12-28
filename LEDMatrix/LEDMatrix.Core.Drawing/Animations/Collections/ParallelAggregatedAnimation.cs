using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations.Collections
{
    public sealed class ParallelAggregatedAnimation : AggregatedAnimation
    {
        public ParallelAggregatedAnimation(bool autoremoveOnCompletion = false) : base(autoremoveOnCompletion)
        {
        }

        public ParallelAggregatedAnimation(bool autoremoveOnCompletion = false, params IAnimation[] animations) : base(autoremoveOnCompletion, animations)
        {
        }

        public override double DurationMilliseconds 
        {
            get
            {
                if (_animations.Count > 0)
                {
                    return _animations.Max(x => x.DurationMilliseconds);
                }
                return 0;
            }
        }

        public override void Update(IRGBLEDCanvas canvas)
        {
            IEnumerable<IAnimation> copy;
            lock (_animationsLockObj)
                copy = _animations.ToList();
            foreach (var animation in copy)
            {
                animation.Update(canvas);
            }
        }
    }
}
