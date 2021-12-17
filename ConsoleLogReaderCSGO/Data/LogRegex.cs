using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Data
{
    internal static class LogRegex
    {

        public static Regex LogChat = new Regex($@"({Variables.MessageUserTextSeparator})");

        public static Regex LogDamage = new Regex($@"^(({Variables.MessageDmg1})|({Variables.MessageDmg2})|({Variables.MessageDmg3})|({Variables.MessageDmg4})|({Variables.MessageDmg5}))");

        public static Regex LogMatchInfo = new Regex($@"^(({Variables.MessageStartGame})|({Variables.MessageEndGame}))");
        public static Regex LogChatTeam { get; private set; } = new Regex($@" ?({Variables.MessageDead}|)(({Variables.MessageCT}|{Variables.MessageTT})(.*))");
        public static (Regex, LogFlags)[] RegexLog { get; private set; } =
        {
            (LogChat, LogFlags.Chat), 
            (LogDamage, LogFlags.Damage), 
            (LogMatchInfo, LogFlags.MatchInfo),
        };
    }
}
