using LEDMatrix.Core.Drawing.Actions.Pixels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Animations
{
    public class AnimationBuilder
    {
        private readonly IRGBLEDCanvas _canvas;
        private readonly AggregatedAnimation _result;
        public AnimationBuilder(IRGBLEDCanvas canvas, int durationMilliseconds)
        {
            _canvas = canvas;
            _result = new AggregatedAnimation(durationMilliseconds);
        }

        public void AddPixelTransition(Pixel value)
        {
            _result.Add(new SmoothTransitionAnimation<SetPixelAction>(new SetPixelAction(_canvas, value), _result.DurationMilliseconds));
        }

        public IAnimation Build() => _result;
    }
}
