using ConsoleLogReaderCSGO.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleLogReaderCSGO.Operations.Flag;

namespace ConsoleLogReaderCSGO.Operations
{
    internal static class UpdateConsoleLogFile
    {
        #region Update methods
        /// <summary>
        /// <br>Method that take logs and index. It gets logs starting from provided index.</br>
        /// <br>Returns Tuple of IEnumerable of SortLogs and length of this array.</br>
        /// <br>Index is index of last line on previous logs.</br>
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static (IEnumerable<LogSorted>, int) UpdateLogExtendedFile(IEnumerable<string> logs, int startIndex)
        {
            int counter = startIndex;
            return (logs.Select((Value, Index) => new { Value, Index }).Where(x => x.Index >= startIndex).Select(x => new LogSorted(x.Value, SetFlagToLogLine.DetermineFlag(x.Value), counter++)), logs.Count());
        }

        /// <summary>
        /// <br>Method that take logs and index. It gets all logs.</br>
        /// <br>Returns Tuple of IEnumerable of SortLogs and length of this array.</br>
        /// <br>Index is index of last line on previous logs.</br>
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static (IEnumerable<LogSorted>, int) UpdateLogNewFile(IEnumerable<string> logs, int startIndex)
        {
            return (logs.Select(x => new LogSorted(x, SetFlagToLogLine.DetermineFlag(x), startIndex++)), logs.Count());
        }

        #endregion
    }
}
