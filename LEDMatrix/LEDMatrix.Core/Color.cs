using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public struct Color
    {
        public Color(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public byte R;
        public byte G;
        public byte B;

        public static Color FromRGB(byte r, byte g, byte b) => new(r, g, b);
        public static Color Red => FromRGB(255, 0, 0);
        public static Color Green => FromRGB(0, 255, 0);
        public static Color Blue => FromRGB(0, 0, 255);
    }
}
