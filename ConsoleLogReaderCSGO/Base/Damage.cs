using ConsoleLogReaderCSGO.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    public struct Damage : IDamage
    {
        #region Fields
        public string Target { get; set; }
        public int AmountDamage { get; set; }
        #endregion
    }
}
