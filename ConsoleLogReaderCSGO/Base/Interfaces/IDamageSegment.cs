using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base.Interfaces
{
    interface IDamageSegment
    {
        int ID { get; set; }
        Damage[] Taken { get; set; }
        Damage[] Given { get; set; }
    }
}
