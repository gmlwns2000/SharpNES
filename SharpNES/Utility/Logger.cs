using System;

namespace SharpNES.Utility
{
    public enum LogLevel
    {
        DEBUG3, DEBUG2, DEBUG,
        INFO, WARNING, ERROR, FATAL
    }

    // ---------- Policies ---------- //
    public interface FormatPolicy
    {
        string Format(string timestamp, LogLevel level, string tag, string message);
    }

    public interface StreamPolicy
    {
        void Write(LogLevel level, string buffer);
    }

    public class Logger<Formater, StreamWriter>
        where Formater : FormatPolicy, new()
        where StreamWriter : StreamPolicy, new()
    {
        private FormatPolicy _formater = new Formater();
        private StreamPolicy _streamWriter = new StreamWriter();

        public LogLevel MinLogLevel { get; set; }

        public Logger(LogLevel minLevel = LogLevel.INFO)
        {
            MinLogLevel = minLevel;
        }

        virtual public void Log(LogLevel level, string tag, string msg)
        {
            if (level > MinLogLevel)
            {
                _streamWriter.Write(
                    level,
                    _formater.Format(
                            DateTime.Now.ToString("HH:mm:ss.fff"),
                            level,
                            tag,
                            msg
                        )
                );
            }
        }

        public void LogFatal(string tag, string msg) { Log(LogLevel.FATAL, tag, msg); }
        public void LogError(string tag, string msg) { Log(LogLevel.ERROR, tag, msg); }
        public void LogWarning(string tag, string msg) { Log(LogLevel.WARNING, tag, msg); }
        public void LogInfo(string tag, string msg) { Log(LogLevel.INFO, tag, msg); }
        public void LogDebug(string tag, string msg) { Log(LogLevel.DEBUG, tag, msg); }
        public void LogDebug2(string tag, string msg) { Log(LogLevel.DEBUG2, tag, msg); }
        public void LogDebug3(string tag, string msg) { Log(LogLevel.DEBUG3, tag, msg); }
    }

    public class DefaultLogger : Logger<DefaultFormater, ConsoleStream>
    {
        public DefaultLogger(LogLevel level = LogLevel.INFO)
            : base(level)
        {
        }
    }

    // ---------- Basic policies ---------- //
    public class DefaultFormater : FormatPolicy
    {
        string FormatPolicy.Format(string timestamp, LogLevel level, string tag, string msg)
        {
            string buffer = "- ";
            buffer += timestamp;
            buffer += " [";
            buffer += Enum.GetName(level.GetType(), level);
            buffer += "]";
            buffer += " (";
            buffer += tag;
            buffer += "): ";
            buffer += msg;

            return buffer;
        }
    }

    public class ConsoleStream : StreamPolicy
    {
        private static readonly ConsoleColor[] _colorSet =
            {
                ConsoleColor.White, // DEBUG3
                ConsoleColor.White, // DEBUG2
                ConsoleColor.White, // DEBUG

                ConsoleColor.DarkGreen, // INFO
                ConsoleColor.Yellow, // WARNING
                ConsoleColor.Red, // ERROR
                ConsoleColor.Red, // FATAL
            };

        void StreamPolicy.Write(LogLevel level, string buffer)
        {
            Console.ForegroundColor = _colorSet[(int)level];
            Console.WriteLine(buffer);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
