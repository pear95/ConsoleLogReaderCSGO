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

        public static Regex MatchStart { get; private set; } = new Regex($@"^({Variables.MessageStartGame})(.*)");
        public static Regex MatchEnd { get; private set; } = new Regex($@"^({Variables.MessageEndGame})(.*)");
        public static Regex MatchDisconnect { get; private set; } = new Regex($@"^({Variables.MessageDisconnectFromGame})");
        public static Regex MatchLoadingScreen { get; private set; } = new Regex($@"^({Variables.MessageGameStartConfirm})");
        public static Regex MatchPngReadMessage { get; private set; } = new Regex($@"^({Variables.MessageGameEndConfirmPNG})");
        public static Regex StartSegmentDamage { get; private set; } = new Regex(@"^(Player: (.*)- Damage Given)");
    }
}
