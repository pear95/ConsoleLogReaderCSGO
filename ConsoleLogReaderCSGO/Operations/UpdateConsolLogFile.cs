using ConsoleLogReaderCSGO.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleLogReaderCSGO.Operations
{
    internal static class UpdateConsolLogFile
    {
        #region Update methods
        /// <summary>
        /// <br>Method that take logs and index. It gets logs starting from provided index.</br>
        /// <br>Returns Tuple of array of SortLogs and length of this array.</br>
        /// <br>Index is index of last line on previous logs.</br>
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static (LogSorted[], int) UpdateLogExtendedFIle(IEnumerable<string> logs, int startIndex)
        {
            int counter = startIndex;
            return ((LogSorted[])logs.Where(y => Array.IndexOf(logs.ToArray(), y) >= startIndex).Select(y => new LogSorted(y, SetFlagToLogLine.DetermineFlag(y), counter++)).ToArray(), logs.ToArray().Length);
        }

        /// <summary>
        /// <br>Method that take logs and index. It gets all logs.</br>
        /// <br>Returns Tuple of array of SortLogs and length of this array.</br>
        /// <br>Index is index of last line on previous logs.</br>
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static (LogSorted[], int) UpdateLogNewFile(IEnumerable<string> logs, int startIndex)
        {
            int counter = startIndex;
            return ((LogSorted[])logs.Select(x => new LogSorted(x, SetFlagToLogLine.DetermineFlag(x), counter++)).ToArray(), logs.ToArray().Length);
        }

        #endregion
    }
}
