using LEDMatrix.Core.Vectors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas
{
    public class VirtualCanvas : ICanvas
    {
        IDictionary<(int, int), Color> _pixels = new Dictionary<(int, int), Color>();
        private readonly Func<Color> _defaultColorFunc;
        public VirtualCanvas(int width, int height, Func<Color> defaultColor)
        {
            Width = width;
            Height = height;
            _defaultColorFunc = defaultColor;
        }
        public Color this[Vector2<int> position]
        {
            get
            {
                return this[position.X, position.Y];
            }
            set
            {
                var defaultColor = _defaultColorFunc();
                if (value == defaultColor)
                    _pixels.Remove((position.X, position.Y));

                this[position.X, position.Y] = value;
            }
        }
        public Color this[int x, int y]
        {
            get
            {
                if (!_pixels.ContainsKey((x, y)))
                {
                    _pixels.Add((x, y), _defaultColorFunc());
                }
                return _pixels[(x, y)];
            }
            set
            {
                if (!_pixels.ContainsKey((x, y)))
                {
                    _pixels.Add((x, y), value);
                }
                _pixels[(x, y)] = value;
            }
        }
        public IEnumerable<Pixel> Pixels => _pixels.Keys.Select(x => new Pixel(x.Item1, x.Item2, _pixels[x]));
        public int Width { get; private set; }
        public int Height { get; private set; }
        public void Clear() => _pixels.Clear();
        public void Fill(Color color)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _pixels[(x, y)] = color;
                }
            }
        }
    }
}
