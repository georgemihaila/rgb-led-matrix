using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public class Color
    {
        public Color(double r, double g, double b) : this((byte)r, (byte)b, (byte)b) { }
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public static Color FromRGB(byte r, byte g, byte b) => new(r, g, b);
        public static Color FromRGB(byte uniform) => new(uniform, uniform, uniform);
        public static Color FromRGB(int uniform) => new((byte)uniform, (byte)uniform, (byte)uniform);
        public static Color Red => FromRGB(255, 0, 0);
        public static Color Green => FromRGB(0, 255, 0);
        public static Color Blue => FromRGB(0, 0, 255);
        public static Color White => FromRGB(255);
        public static Color Black => FromRGB(0);
    }
}
