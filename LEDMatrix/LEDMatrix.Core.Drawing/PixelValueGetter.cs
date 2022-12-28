using LEDMatrix.Core.Canvas.Drawing.Transitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing
{
    public abstract class PixelValueGetter : ITransition1
    {
        protected PixelValueGetter(IRGBLEDCanvas canvas, Pixel to)
        {
            To = to;
            From = canvas.GetPixel(to);
        }

        public Pixel From { get; }
        public Pixel To { get; }
    }
}
