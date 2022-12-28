using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public class AnimationRunStatistics
    {
        public AnimationRunStatistics Aggregate(params AnimationRunStatistics[] statistics) => new();
    }
}
