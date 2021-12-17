using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO
{

    #region Enumerator Log Flag

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

    #endregion

    #region Enumerator Chat Type

    /// <summary>
    /// Enumerator for Type of console chat
    /// </summary>
    public enum ChatType
    {
        /// <summary>
        /// Counter Terrorist chat, only readable for counter terrorist team
        /// </summary>
        CT = 1,
        /// <summary>
        /// Terrorist chat, only readable for terrorist team
        /// </summary>
        TT = 2,
        /// <summary>
        /// Global chat, readable for everyone
        /// </summary>
        GLOBAL = 3,
    }

    #endregion


}