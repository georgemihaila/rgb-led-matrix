using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Invocation
{
    public sealed class TypeDescriptor
    {
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}
