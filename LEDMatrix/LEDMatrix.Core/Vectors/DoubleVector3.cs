using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Vectors
{
    public class DoubleVector3 : Vector3<double>
    {
        public DoubleVector3(double u) : this(u, u, u) { }
        public DoubleVector3(double x, double y, double z) : base(x, y, z)
        {

        }
        public Color ToColor() => new(X, Y, Z);

        public static DoubleVector3 operator +(DoubleVector3 left, DoubleVector3 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        public static DoubleVector3 operator -(DoubleVector3 left, DoubleVector3 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        public static DoubleVector3 operator *(DoubleVector3 left, DoubleVector3 right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        public static DoubleVector3 operator *(DoubleVector3 v, double scalar) => new(v.X * scalar, v.Y * scalar, v.Z * scalar);
        public static DoubleVector3 Zero => new(0);

        public static implicit operator DoubleVector3(Color v) => new(v.R, v.G, v.B);
    }
}
