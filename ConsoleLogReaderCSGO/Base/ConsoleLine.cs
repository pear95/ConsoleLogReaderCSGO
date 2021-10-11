using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    internal class ConsoleLine
    {
        public string Line { get; set; }

        public ConsoleLine(string line)
        {
            this.Line = line;
        }
    }
}
