using LEDMatrix.Core.Vectors;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public class Color
    {
        public Color() { }
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
        public static Color operator *(Color c, DoubleVector3 vector3) => new(c.R * vector3.X, c.G + vector3.Y, c.B * vector3.Z);
        public static Color operator *(Color c, double scalar) => new(c.R * scalar, c.G + scalar, c.B * scalar);
        public static DoubleVector3 operator /(Color c, double scalar) => new((double)c.R / scalar, (double)c.G / scalar, (double)c.B / scalar);
        public static Color operator -(Color c, DoubleVector3 vector3) => new(c.R - vector3.X, c.G - vector3.Y, c.B - vector3.Z);
        public static Color operator -(Color a, Color b) => new(a.R - b.R, a.G - b.G, a.B - b.B);
        public static Color operator +(Color a, Color b) => new(a.R + b.R, a.G + b.G, a.B + b.B);
        public static Color operator +(Color c, DoubleVector3 vector3) => new(c.R + vector3.X, c.G + vector3.Y, c.B + vector3.Z);
        public override string ToString() => $"R: {R} G: {G} B: {B}";
    }
}
