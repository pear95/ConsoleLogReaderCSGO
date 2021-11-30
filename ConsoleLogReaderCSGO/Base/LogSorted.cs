using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    internal class LogSorted
    {
        public string Line { get; set; }
        public int Index { get; set; }
        public LogFlags LogTypeFlag { get; set; }

        public LogSorted(string line, LogFlags logFlags, int startIndex)
        {
            Line = line;
            Index = startIndex;
            LogTypeFlag = logFlags;
        }
    }
}
