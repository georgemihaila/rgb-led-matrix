using LEDMatrix.Core.Drawing.Transitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing
{
    public abstract class PixelValueGetter : ITransition1
    {
        protected PixelValueGetter(IRGBLEDCanvas canvas, Pixel to)
        {
            Canvas = canvas;
            To = to;
            From = canvas.GetPixel(to);
        }

        public Pixel From { get; }
        public IRGBLEDCanvas Canvas { get; }
        public Pixel To { get; }
    }
}
