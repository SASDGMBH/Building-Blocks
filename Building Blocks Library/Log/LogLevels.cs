using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Blocks_Library.Log
{

    /// <summary>
    /// 
    /// </summary>
    public enum LogLevel : long
    {
        FATAL = 0,      // Error App. can't continue
        ERROR = 1,      // Exceptions
        WARN = 2,       // Object is invalid
        INFO = 3,       // relevant result
        DEBUG = 4       // Enter or Exit Method
    }

}
