using LEDMatrix.Core.Vectors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public class AnimationUpdateParams
    {
        public AnimationUpdateParams() 
        {
            LastTickTimestamp = DateTime.Now;
            StartedAt = DateTime.Now;
        }
        public AnimationUpdateParams(DateTime lastTickTimestamp, DateTime startedAt)
        {
            LastTickTimestamp = lastTickTimestamp;
            StartedAt = startedAt;
        }
        public void Restart() => StartedAt = DateTime.Now;
        public void MarkUpdated() => LastTickTimestamp = DateTime.Now;
        public AnimationRunStatistics BuildStatistics() => new();
        public DateTime LastTickTimestamp { get; private set; }
        public DateTime StartedAt { get; private set; }
        public double MillisecondsSinceLastUpdate => (DateTime.Now - LastTickTimestamp).TotalMilliseconds;
    }
}
