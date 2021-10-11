using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO
{
    /// <summary>
    /// Enumerator of Log Flags
    /// </summary>
    public enum LogFlags
    {
        /// <summary>
        /// Section of damage Taken and Given
        /// </summary>
        Damage = 1,
        /// <summary>
        /// Lines with chat
        /// </summary>
        Chat = 2,
        /// <summary>
        /// Lines about match info like start and finish
        /// </summary>
        MatchInfo = 3,
        /// <summary>
        /// Lines unclassified 
        /// </summary>
        Debug = 10,
        /// <summary>
        /// All Logs
        /// </summary>
        All = 20,
    }
}