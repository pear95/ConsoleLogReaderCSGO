using ConsoleLogReaderCSGO.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base.Roots
{
    public abstract class Message : IMessage
    {
        #region Fields
        public int ID { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        #endregion

        #region Constructors
        internal Message() { }
        internal Message(int id, string user, string text)
        {
            ID = id;
            User = user;
            Text = text;
        }
        #endregion
    }
}
