using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base.Interfaces
{
    public interface IMessage
    {
        #region Fields
        public int ID { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        #endregion
    }
}
