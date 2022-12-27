using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public interface IAnimation
    {
        public double DurationMilliseconds { get; }
    }
}
