using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Blocks_Library.Log
{
    public interface ILogger
    {
 
        // enum LogLeve

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void WriteLine(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="condition"></param>
        void WriteLineIf(string message, bool condition);
    }
}
