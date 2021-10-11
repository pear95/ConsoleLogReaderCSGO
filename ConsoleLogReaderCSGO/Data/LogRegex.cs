using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Data
{
    internal static class LogRegex
    {
        public static Regex LogChat = new Regex(@"[ ][:][ ]");

        public static Regex LogDamage = new Regex(@"^((Damage Given to)|(Damage Taken from)|(-------------------------)|(Player:(.*)- Damage Given)|(Player: (.*)- Damage Taken))");

        public static Regex LogMatchInfo = new Regex(@"^((Steamworks Stats: CSteamWorksGameStatsClient Received CLIENT session id:)|(Steamworks Stats: CSteamWorksGameStatsClient Ending CLIENT session id:))");

        public static (Regex, LogFlags)[] regexLog { get; private set; } =
        {
            (LogChat, LogFlags.Chat), 
            (LogDamage, LogFlags.Damage), 
            (LogMatchInfo, LogFlags.MatchInfo), 
        };
    }
}
