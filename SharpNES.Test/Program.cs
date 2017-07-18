using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpNES.Utility;

namespace SharpNES.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test logging
            var logger = new Logger<DefaultFormater, ConsoleStream>(LogLevel.DEBUG3);

            logger.Log(LogLevel.INFO, "Main", "This is an Info message");
            logger.Log(LogLevel.WARNING, "Main", "This is an Warning message");
            logger.Log(LogLevel.ERROR, "Main", "This is an Error message");
            logger.Log(LogLevel.FATAL, "Main", "This is an Fatal message");

            logger.Log(LogLevel.DEBUG, "Main", "This is a Debug message");
            logger.Log(LogLevel.DEBUG2, "Main", "This is an Debug2 message");
            logger.Log(LogLevel.DEBUG3, "Main", "This is an Debug3 message");
        }
    }
}
