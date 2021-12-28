using ConsoleLogReaderCSGO.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    public class DamageSegment : IDamageSegment
    {
        #region Fields
        public int ID { get; set; }
        public Damage[] Taken { get; set; }
        public Damage[] Given { get; set; }
        #endregion
        #region Constructor
        public DamageSegment() { }
        #endregion
    }
}
