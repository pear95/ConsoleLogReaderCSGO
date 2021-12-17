using ConsoleLogReaderCSGO.Base.Roots;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Base
{
    public class MessageConsole : Message
    {
        #region Fields
        public bool IsDead { get; set; }
        public ChatType MessageType { get; set; }
        public string Location { get; set; }

        #endregion

        #region Constructors

        public MessageConsole() { }
        public MessageConsole(int id, string user, string text, bool isDead, ChatType type, string location = null) : base(id, user, text)
        {
            IsDead = isDead;
            MessageType = type;
            Location = location;
        }

        #endregion
    }

}
