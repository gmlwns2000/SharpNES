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
            var logger = new Logger<DefaultFormater, ConsoleStream>(LogLevel.Debug3);

            logger.Log(LogLevel.Info, "Main", "This is an Info message");
            logger.Log(LogLevel.Warning, "Main", "This is an Warning message");
            logger.Log(LogLevel.Error, "Main", "This is an Error message");
            logger.Log(LogLevel.Fatal, "Main", "This is an Fatal message");

            logger.Log(LogLevel.Debug, "Main", "This is a Debug message");
            logger.Log(LogLevel.Debug2, "Main", "This is an Debug2 message");
            logger.Log(LogLevel.Debug3, "Main", "This is an Debug3 message");
 
       }
    }
}
