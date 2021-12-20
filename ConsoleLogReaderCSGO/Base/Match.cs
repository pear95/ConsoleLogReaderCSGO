using ConsoleLogReaderCSGO.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    public class Match : IMatch
    {
        #region Fields
        public string ID { get; set; }
        public int Index { get; set; }
        public MatchStatus Status { get; set; }

        #endregion

        #region Constructor

        public Match(string id, int index, MatchStatus status)
        {
            Index = index;
            ID = id;
            Status = status;
        }

        #endregion
    }
}
