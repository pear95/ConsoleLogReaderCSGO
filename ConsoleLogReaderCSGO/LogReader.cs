﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO
{
    /// <summary>
    /// <para>Main class that contain all user methods</para>
    /// <para>Preferible T types</para>
    /// <br>• string</br>
    /// <br>• string array</br>
    /// <br>• string list</br>
    /// </summary>
    public class LogReader<T>
    {
        #region fields

        internal static IEnumerable<string> Value{ get; set; }
        internal static int LastLogIndex { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// <para>Constructor for main class</para>
        /// <para>Preferible T types</para>
        /// <br>• string</br>
        /// <br>• string array</br>
        /// <br>• string list</br>
        /// </summary>
        public LogReader(T logs)
        {
            Data.Variables.ConsoleLinesArray = new LogSorted[0];

            Value = CheckTypeT(logs);

            var response = Operations.ReadConsoleLogFile.ReadConsoleFile(Value);
            Data.Variables.ConsoleLinesArray = response.Item1;
            LastLogIndex = response.Item2;
        }

        #endregion

        #region Methods public
        /// <summary>
        /// Method that return assigned (flag) lines of console log
        /// </summary>
        /// <param name="logFlag"> A flag that indicates what type of lines are to be returned </param>
        /// <param name="logFlags"> An aditional flags that indicates what type of lines are to be returned </param>
        /// <returns>
        /// <para>Obect Array where every object cointains:</para>
        /// <br>1) (string) line of console log</br>  
        /// <br>2) (Flag) describing line type</br>
        /// <br>3) (integer) index of line on given Logs</br>
        /// </returns>
        public object[] GetLogs(LogFlags logFlag, params LogFlags[] logFlags)
        {
            if (Data.Variables.ConsoleLinesArray != (null))
            {
                LogFlags[] logFlagAll = new LogFlags[0];
                logFlagAll = logFlags.Length > 0 
                    ? (LogFlags[])logFlags.Concat(new LogFlags[] { logFlag }).ToArray()
                    : new LogFlags[] { logFlag };

                return !logFlagAll.Contains(LogFlags.All) 
                    ? (object[])Data.Variables.ConsoleLinesArray.Where(x => logFlagAll.Contains(x.LogTypeFlag)).ToArray()
                    : (object[])Data.Variables.ConsoleLinesArray.ToArray();
            }
            else { return new object[] { }; }
        }

        /// <summary>
        /// Method that updates log file replacing previous log with new file (biggest).
        /// </summary>
        /// <param name="newLog">New log of type set at create instance</param>
        public void UpdateLogExtendedFile(T newLog) // oldlogs.txt replaced by newlogs.txt
        {
            UpdateLog(newLog, true);
        }

        /// <summary>
        /// Method that update log file appending new logs to previous file.
        /// </summary>
        /// <param name="newLog">New log of type set at create instance</param>
        public void UpdateLogNewFile(T newLog) // old.txt + newlogs.txt
        {
            UpdateLog(newLog, false);
        }

        /// <summary>
        /// Method that remove all logs from instance.
        /// </summary>
        public void ClearLog()
        {
            Data.Variables.ConsoleLines = default;
            Value = default;
        }
        #endregion

        #region Methods private
        private IEnumerable<string> CheckTypeT(T logs)
        {
            return logs is IEnumerable<string> enumerable ? enumerable
                : logs is string ? logs.ToString().Split(new char[] { '\r', '\n' }).Where(y => !string.IsNullOrEmpty(y)).ToArray()
                : default(IEnumerable<string>);
        }

        private void UpdateLog(T logs, bool isExtendedFile)
        {
            Value = CheckTypeT(logs);

            if (Value != null)
            {
                (List<LogSorted>, int) response = isExtendedFile ? Operations.UpdateConsoleLogFile.UpdateLogExtendedFIle(Value, LastLogIndex)
                    : Operations.UpdateConsoleLogFile.UpdateLogNewFile(Value, LastLogIndex);
                
                Data.Variables.ConsoleLines.AddRange(response.Item1);
                LastLogIndex = response.Item2;
            }
        }

        #endregion
    }
}
