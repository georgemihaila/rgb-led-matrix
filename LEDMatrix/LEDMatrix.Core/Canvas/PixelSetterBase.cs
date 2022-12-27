using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas
{
    public abstract class PixelSetterBase : IPixelSetter
    {
        public abstract void SetPixel(int x, int y, Color color);

        public void SetPixel(Pixel pixel) => SetPixel(pixel.Position.X, pixel.Position.Y, pixel.Color);
    }
}
