using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

/// <summary>
/// 
/// </summary>
namespace Building_Blocks_Library.Log
{

    /// <summary>
    /// 
    /// </summary>
    class Log4netLogger : Log.ILogger
    {
        #region private Members
 
        /// <summary>
        /// 
        /// </summary>
        private static Log4netLogger singelton = null;

        #endregion

        #region Public Properties
 
        /// <summary>
        /// Loglevel of Messages to be logged
        /// </summary>
        public LogLevel DefaultLogLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type typeToLog { get; set; }  // TODO: Summary description missing

        #endregion

        #region public Constructores

        /// <summary>
        /// 
        /// </summary>
        public Log4netLogger(Type typeToLog)  // TODO: Summary description missing
        {
            this.typeToLog = typeToLog;
            DefaultLogLevel = LogLevel.ERROR;
        } 

        #endregion

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
        public static Log4netLogger Factory(Type typeToLog)
        {
            var logger = new Log4netLogger(typeToLog);
            return logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Log4netLogger Create(Type typeToLog)
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
        /// Log a Debug Message
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            printLine(message, LogLevel.DEBUG);
        }

        /// <summary>
        /// Log a Error Message
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            printLine(message, LogLevel.ERROR); ;
        }

        /// <summary>
        /// Log a Fatal Error Message
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message)
        {
            printLine(message, LogLevel.FATAL);
        }

        /// <summary>
        /// Log a Info Message
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            printLine(message, LogLevel.INFO);
        }

        /// <summary>
        /// Log a Warning
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            printLine(message, LogLevel.WARN);
        }

        /// <summary>
        /// Log a Message at Default Log Level
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            printLine(message, DefaultLogLevel);
        }

        /// <summary>
        /// Log a Message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="logLevel">Log Level of the message</param>
        public void WriteLine(string message, LogLevel logLevel)
        {
            printLine(message, logLevel);
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
                printLine(message, DefaultLogLevel);
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
                printLine(message, logLevel);
            }
        }

        #endregion

        #region private Methodes

        /// <summary>
        /// This Message does the real work
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="logLevel">Log Level of the message</param>
        private void printLine(string message, LogLevel loglevel)
        {
            // TODO: this code is rubbish move it to correct place
            // BasicConfigurator.Configure();
            XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(Log4netLogger));
            logger.Debug(message);
        }

    
        #endregion
    }
}
