using LEDMatrix.Core.Canvas.Drawing.Actions.Pixels;
using LEDMatrix.Core.Canvas.Drawing.Animations.Collections;
using LEDMatrix.Core.Canvas.Drawing.Animations.Pixels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Animations
{
    public class AnimationBuilder
    {
        private readonly IRGBLEDCanvas _canvas;
        private readonly ParallelAggregatedAnimation _result;
        public AnimationBuilder(IRGBLEDCanvas canvas, bool autoremoveOnCompletion = true)
        {
            _canvas = canvas;
            _result = new(autoremoveOnCompletion);
        }

        public AnimationBuilder AddPixelTransition(Pixel value, double durationMilliseconds)
        {
            _result.Add(new LinearTransitionAnimation<SetPixelAction>(_canvas, new SetPixelAction(_canvas, value), durationMilliseconds));
            return this;
        }

        public IAnimation Build() => _result;
    }
}
