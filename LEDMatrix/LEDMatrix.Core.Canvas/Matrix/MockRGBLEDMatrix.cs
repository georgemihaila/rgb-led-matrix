using LEDMatrix.Core.Canvas;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Matrix
{
    public class MockRGBLEDMatrix : IRGBLEDMatrix<MockRGBLEDCanvas>
    {
        private readonly MockRGBLEDCanvas _canvas = new MockRGBLEDCanvas();
        public byte Brightness { get; set; }

        public MockRGBLEDCanvas CreateOffscreenCanvas()
        {
            return _canvas;
        }

        public MockRGBLEDCanvas GetCanvas()
        {
            return _canvas;
        }

        public MockRGBLEDCanvas SwapOnVsync(MockRGBLEDCanvas canvas)
        {
            return _canvas;
        }
    }
}
