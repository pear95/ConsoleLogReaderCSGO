using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Data
{
    internal static class Variables
    {
        public static List<LogSorted> ConsoleLines { get; set; }

        public static LogSorted[] ConsoleLinesArray { get; set; }
    }
}
