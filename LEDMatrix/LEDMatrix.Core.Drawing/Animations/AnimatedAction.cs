using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public abstract class AnimatedAction<TAction, TAnimation>
        where TAction: class, IDrawAction
        where TAnimation: class, IAnimation
    {
    }
}
