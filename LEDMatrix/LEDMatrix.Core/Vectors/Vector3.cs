using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Vectors
{
    public class Vector3<T>
        where T : struct
    {
        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
        public static Vector3<T> Zero => new(default, default, default);
    }
}
