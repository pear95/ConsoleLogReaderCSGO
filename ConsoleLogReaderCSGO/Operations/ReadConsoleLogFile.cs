using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Operations
{
    internal static class ReadConsoleLogFile
    {
        #region Read log Methods
        /// <summary>
        /// Method that read provided logs and returns Tuple: Array of SortedLogs and length of logs 
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        internal static (LogSorted[], int) ReadConsoleFile(IEnumerable<string> logs)
        {
            int counter = 0;
            if (logs != null)
            {
                return ((LogSorted[])logs.Select(x => new LogSorted(x, Flag.SetFlagToLogLine.DetermineFlag(x), counter++)).ToArray(), logs.ToArray().Length);
            }
            return (null, 0);

        }
        #endregion
    }
}