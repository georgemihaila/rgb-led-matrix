using LEDMatrix.Core.Canvas;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Matrix
{
    public class MockRGBLEDMatrix : IRGBLEDMatrix
    {
        private readonly IRGBLEDCanvas _canvas = new MockRGBLEDCanvas();
        public byte Brightness { get; set; }

        public IRGBLEDCanvas CreateOffscreenCanvas()
        {
            return _canvas;
        }

        public IRGBLEDCanvas GetCanvas()
        {
            return _canvas;
        }

        public IRGBLEDCanvas SwapOnVsync(IRGBLEDCanvas canvas)
        {
            return _canvas;
        }
    }
}
