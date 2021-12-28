using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base.Interfaces
{
    public interface IDamage
    {
        string Target { get; set; }
        int AmountDamage { get; set; }
    }
}
