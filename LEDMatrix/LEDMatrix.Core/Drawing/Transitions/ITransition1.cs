using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Drawing.Transitions
{
    public interface ITransition1 
    {
        public Pixel From { get; }
        public Pixel To { get; }
        public IRGBLEDCanvas Canvas { get; }
    }
}
