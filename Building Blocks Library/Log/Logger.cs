using Building_Blocks_Library.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace Building_Blocks_Library
{

    /// <summary>
    /// 
    /// </summary>
    public class Logger : Log.ILogger
    {

        #region private Members
        /// <summary>
        /// Highlander mode -There Can Be Only One
        /// </summary>
        private static Logger singelton = null;

        #endregion

        #region public Properties

        /// <summary>
        /// Loglevel of Messages to be logged 
        /// </summary>
        public LogLevel DefaultLogLevel { get; set; }

        /// <summary>
        /// Default Loglevel property
        /// </summary>
        public LogEngine DefaultLogEngine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type typeToLog { get; set; } // TODO: Summary description missing

        #endregion

        #region Public Constructores

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="typeToLog"></param>
        public Logger(Type typeToLog)
        {
            this.typeToLog = typeToLog;
            DefaultLogLevel = LogLevel.ERROR;
            DefaultLogEngine = LogEngine.SIMPLE;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public enum LogEngine : long
        {
            SIMPLE = 0,     // Stupid File Logger
            LOG4NET = 1     // Log4net Logger
        }

        /// <summary>
        /// Supported LogLevel
        /// </summary>
        public enum LogLevel : long
        {
            // TODO: this code is a dublicate move it to seperate file
            FATAL = 0,      // Error App. can't continue
            ERROR = 1,      // Exceptions
            WARN = 2,       // Object is invalid
            INFO = 3,       // relevant result
            DEBUG = 4       // Enter or Exit Method
        }

        #region static Methodes

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Logger Factory(Type typeToLog)
        {
            return new Logger(typeToLog);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Logger Create(Type typeToLog)
        {
            if (singelton == null)
            {
                singelton = Factory(typeToLog);
            }
            return singelton;
        }


        #endregion

        #region public Methodes

        /// <summary>
        /// Is Debug the current Log Level
        /// </summary>
        /// <returns></returns>
        public bool IsDebugEnabled()
        {
            return DefaultLogLevel == LogLevel.DEBUG;
        }

        /// <summary>
        /// Is Error the current Log Level
        /// </summary>
        /// <returns></returns>
        public bool IsErrorEnabled()
        {
            return DefaultLogLevel == LogLevel.ERROR;
        }

        /// <summary>
        /// Is Fatal the current Log Level
        /// </summary>
        /// <returns></returns>
        public bool IsFatalEnabled()
        {
            return DefaultLogLevel == LogLevel.FATAL;
        }

        /// <summary>
        /// Is Info the current Log Level
        /// </summary>
        /// <returns></returns>
        public bool IsInfoEnabled()
        {
            return DefaultLogLevel == LogLevel.INFO;
        }

        /// <summary>
        /// Is Warn the current Log Level
        /// </summary>
        /// <returns></returns>
        public bool IsWarnEnabled()
        {
            return DefaultLogLevel == LogLevel.WARN;
        }

        /// <summary>
        /// Log a Debug Message
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            if (IsDebugEnabled())
            {
                printLine(message, LogLevel.DEBUG);
            }
        }

        /// <summary>
        /// Log a Error Message
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            // print if DEBUG or INFO or WARN or ERR
            if (IsDebugEnabled() || IsInfoEnabled() || IsWarnEnabled() || IsErrorEnabled())
            {
                printLine(message, LogLevel.ERROR);
            }
        }

        /// <summary>
        /// Log a Fatal Error Message
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message)
        {
            // print if DEBUG or INFO or WARN or ERR
            if (IsDebugEnabled() || IsInfoEnabled() || IsWarnEnabled() || IsErrorEnabled() || IsFatalEnabled())
            {
                printLine(message, LogLevel.FATAL);
            }
        }

        /// <summary>
        /// Log a Info Message
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            // print if DEBUG or INFO
            if (IsDebugEnabled() || IsInfoEnabled())
            {
                printLine(message, LogLevel.INFO);
            }
        }

        /// <summary>
        /// Log a Warning
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            // print if DEBUG or INFO or WARN
            if (IsDebugEnabled() || IsInfoEnabled() || IsWarnEnabled())
            {
                printLine(message, LogLevel.WARN);
            }
        }

        /// <summary>
        /// Log a Message at Default Log Level
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            WriteLine(message, DefaultLogLevel);
        }

        /// <summary>
        /// Log a Message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="logLevel">Log Level of the message</param>
        public void WriteLine(string message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.DEBUG: { Debug(message); break; }
                case LogLevel.ERROR: { Error(message); break; }
                case LogLevel.FATAL: { Fatal(message); break; }
                case LogLevel.INFO: { Info(message); break; }
                case LogLevel.WARN: { Warn(message); break; }
                default: { throw new NotSupportedException("Unsupported LogLevel selected"); }
            }
        }

        /// <summary>
        /// Conditional Log Message at Default Log Level
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="condition">Message will be logged if condition is true</param>
        public void WriteLineIf(string message, bool condition)
        {
            if (condition)
            {
                switch (DefaultLogLevel)
                {
                    case LogLevel.DEBUG: { Debug(message); break; }
                    case LogLevel.ERROR: { Error(message); break; }
                    case LogLevel.FATAL: { Fatal(message); break; }
                    case LogLevel.INFO: { Info(message); break; }
                    case LogLevel.WARN: { Warn(message); break; }
                    default: { throw new NotSupportedException("Unsupported LogLevel selected"); }
                }
            }
        }

        /// <summary>
        /// Conditional Log Message with given Log Level 
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="logLevel">Log Level of the message</param>
        /// <param name="condition">Message will be logged if condition is true</param>
        public void WriteLineIf(string message, LogLevel logLevel, bool condition)
        {
            if (condition)
            {
                switch (logLevel)
                {
                    case LogLevel.DEBUG: { Debug(message); break; }
                    case LogLevel.ERROR: { Error(message); break; }
                    case LogLevel.FATAL: { Fatal(message); break; }
                    case LogLevel.INFO: { Info(message); break; }
                    case LogLevel.WARN: { Warn(message); break; }
                    default: { throw new NotSupportedException("Unsupported LogLevel selected"); }
                }
            }
        }

        #endregion

        #region private Methodes

        /// <summary>
        /// This Message does the real work
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="logLevel">Log Level of the message</param>
        private void printLine(string message, LogLevel logLevel)
        {

            ILogger log = Log4netLogger.Create(null);

            switch (DefaultLogEngine)
            {
                case LogEngine.LOG4NET:
                    {
                        // everything is done so we do nothing :-)
                        break;
                    }
                case LogEngine.SIMPLE:
                    {
                        log = SimpleLogger.Create(null);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException("Unsupported Login Engine selected");
                    }
            }

            switch (logLevel)
            {
                case LogLevel.DEBUG:
                    {
                        log.Debug(message);
                        break;
                    }
                case LogLevel.INFO:
                    {
                        log.Info(message);
                        break;
                    }
                case LogLevel.WARN:
                    {
                        log.Warn(message);
                        break;
                    }
                case LogLevel.ERROR:
                    {
                        log.Error(message);
                        break;
                    }
                case LogLevel.FATAL:
                    {
                        log.Fatal(message);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException("Unsupported LogLevel selected");
                    }
            }
        }

        #endregion
    }
}
