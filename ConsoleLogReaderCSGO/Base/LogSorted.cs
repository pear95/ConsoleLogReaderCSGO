using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    internal class LogSorted : ConsoleLine
    {
        internal int Index { get; set; }
        internal LogFlags LogTypeFlag { get; set; }

        public LogSorted(string line, LogFlags logFlags, int id) : base(line)
        {
            Index = id;
            LogTypeFlag = logFlags;
        }

        //Steamworks Stats: CSteamWorksGameStatsClient Received CLIENT session id: start
        //Steamworks Stats: CSteamWorksGameStatsClient Ending CLIENT session id: close
    }
}
