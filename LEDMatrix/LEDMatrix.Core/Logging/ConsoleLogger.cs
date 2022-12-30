using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            PrintPrefix("Debug");
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            PrintPrefix("Error");
            Console.WriteLine(message);
        }

        public void Error(Exception e) => Error(e.ToString());

        public void Fatal(string message)
        {
            PrintPrefix("Fatal");
            Console.WriteLine(message);
        }

        public void Fatal(string message, Exception exception)
        {
            PrintPrefix("Fatal");
            Console.WriteLine(message);
            Console.WriteLine("Exception:");
            Console.WriteLine(exception);
        }

        public void Info(string message)
        {
#if DEBUG
            PrintPrefix("Info");
            Console.WriteLine(message);
#endif
        }

        public void Warn(string message)
        {
            PrintPrefix("Warn");
            Console.WriteLine(message);
        }

        private static void PrintPrefix(string logLevel) => Console.Write($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} [{logLevel}]: ");
    }
}
