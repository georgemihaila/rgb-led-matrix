using LEDMatrix.Core.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public class Pixel
    {
        public Pixel(Vector2<int> position, Color color)
        {
            Position = position;
            Color = color;
        }

        public Vector2<int> Position { get; private set; }
        public Color Color { get; set; }
    }
}
