using System;

namespace SharpNES.Utility
{
    public enum LogLevel
    {
        Debug3, Debug2, Debug,
        Info, Warning, Error, Fatal
    }

    // ---------- Policies ---------- //
    public interface IFormatPolicy
    {
        string Format(string timestamp, LogLevel level, string tag, string message);
    }

    public interface IStreamPolicy
    {
        void Write(LogLevel level, string buffer);
    }

    public class Logger<Formater, StreamWriter>
        where Formater : IFormatPolicy, new()
        where StreamWriter : IStreamPolicy, new()
    {
        private IFormatPolicy _formater = new Formater();
        private IStreamPolicy _streamWriter = new StreamWriter();

        public LogLevel MinLogLevel { get; set; }

        public Logger(LogLevel minLevel = LogLevel.Info)
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

        public void LogFatal(string tag, string msg) { Log(LogLevel.Fatal, tag, msg); }
        public void LogError(string tag, string msg) { Log(LogLevel.Error, tag, msg); }
        public void LogWarning(string tag, string msg) { Log(LogLevel.Warning, tag, msg); }
        public void LogInfo(string tag, string msg) { Log(LogLevel.Info, tag, msg); }
        public void LogDebug(string tag, string msg) { Log(LogLevel.Debug, tag, msg); }
        public void LogDebug2(string tag, string msg) { Log(LogLevel.Debug2, tag, msg); }
        public void LogDebug3(string tag, string msg) { Log(LogLevel.Debug3, tag, msg); }
    }

    public class DefaultLogger : Logger<DefaultFormater, ConsoleStream>
    {
        public DefaultLogger(LogLevel level = LogLevel.Info)
            : base(level)
        {
        }
    }

    // ---------- Basic policies ---------- //
    public class DefaultFormater : IFormatPolicy
    {
        string IFormatPolicy.Format(string timestamp, LogLevel level, string tag, string msg)
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

    public class ConsoleStream : IStreamPolicy
    {
        private static readonly ConsoleColor[] _colorSet =
            {
                ConsoleColor.White, // Debug3
                ConsoleColor.White, // Debug2
                ConsoleColor.White, // Debug

                ConsoleColor.DarkGreen, // Info
                ConsoleColor.Yellow, // Warning
                ConsoleColor.Red, // Error
                ConsoleColor.Red, // Fatal
            };

        void IStreamPolicy.Write(LogLevel level, string buffer)
        {
            Console.ForegroundColor = _colorSet[(int)level];
            Console.WriteLine(buffer);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
