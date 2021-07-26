using System;
using System.IO;

namespace Z1 {
    
    public static class Example {
        public static void Main() {
            var factory = LoggerFactory.Instance();
            ILogger logger1 = LoggerFactory.GetLogger( LogType.File, "./foo.txt" );
            logger1.Log( "foo bar" ); // logowanie do pliku
            ILogger logger2 = LoggerFactory.GetLogger( LogType.None );
            logger2.Log( "qux" );
            ILogger logger3 = LoggerFactory.GetLogger(LogType.Console);

            logger1.Log("foo");
            logger2.Log("foo");
            logger3.Log("foo");
        }
    }

    public interface ILogger {
        void Log(string message);
    }

    public enum LogType { None, Console, File }

    public class NullLogger : ILogger {
        public void Log(string message) {}
    }

    public class ConsoleLogger : ILogger {
        public void Log(string message) {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger {
        private readonly StreamWriter _file;

        public void Log(string message) {
            _file.WriteLine(message);
        }

        public FileLogger(string path) {
            if (path == null) {
                throw new ArgumentException("Null path");
            }

            this._file = new StreamWriter(path);
        }
    }

    public class LoggerFactory {
        private static LoggerFactory _instance;

        private LoggerFactory()
        {
            return;
        }

        public static ILogger GetLogger(LogType type, string parameter = null)
        {
            return type switch
            {
                LogType.None => new NullLogger(),
                LogType.Console => new ConsoleLogger(),
                LogType.File => new FileLogger(parameter),
                _ => throw new ArgumentException()
            };
        }

        public static LoggerFactory Instance()
        {
            return _instance ??= new LoggerFactory();
        }
    }

}