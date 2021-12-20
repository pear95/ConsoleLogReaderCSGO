using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base.Interfaces
{
    public interface IMatch
    {
        public int Index { get; set; }
        public string ID { get; set; }
        public MatchStatus Status { get; set; }
    }
}
