using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Building_Blocks_Library;

namespace Building_Blocks_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Create(null).DefaultLogEngine = Logger.LogEngine.SIMPLE;
            Logger.Create(null).DefaultLogLevel = Logger.LogLevel.ERROR;

            Logger.Create(null).WriteLine("WriteLine Debug", Logger.LogLevel.DEBUG);
            Logger.Create(null).WriteLine("WriteLine Info", Logger.LogLevel.INFO);
            Logger.Create(null).WriteLine("WriteLine Warn", Logger.LogLevel.WARN);
            Logger.Create(null).WriteLine("WriteLine Error", Logger.LogLevel.ERROR);
            Logger.Create(null).WriteLine("WriteLine Fatal", Logger.LogLevel.FATAL);
        }
    }
}
