using LEDMatrix.Core.Drawing.Actions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public abstract class AnimatedAction<TAction, TAnimation>
        where TAction: class, IDrawAction
        where TAnimation: class, IAnimation
    {
    }
}
