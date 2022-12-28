using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public interface IRGBLEDMatrix
    {
        public byte Brightness { get; set; }
        public IRGBLEDCanvas CreateOffscreenCanvas();
        public IRGBLEDCanvas GetCanvas();
        public IRGBLEDCanvas SwapOnVsync(IRGBLEDCanvas canvas);
    }
}
