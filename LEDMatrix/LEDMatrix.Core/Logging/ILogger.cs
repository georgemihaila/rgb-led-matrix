using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Logging
{
    public interface ILogger
    {
        public void Info(string message);
        public void Warn(string message);
        public void Error(string message);
        public void Error(Exception e);
        public void Fatal(string message);
        public void Debug(string message);
        public void Fatal(string message, Exception exception);
    }
}
