using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Vectors
{
    public class Vector2<T>
        where T : struct
    {
        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }
        public T Y { get; set; }
        public static Vector2<T> Zero => new(default, default);
        public override string ToString() => $"X: {X} Y: {Y}";
    }
}
