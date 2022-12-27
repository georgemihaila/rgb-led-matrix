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
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
