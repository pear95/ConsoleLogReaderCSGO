using System;
using System.Collections.Generic;
using System.Text;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Data
{
    internal static class LogCoincidence
    {
        public static string[] LogChat { get; private set; } = 
        {
            "bind",
            "props",
            "player : ",
            "players : ",
            "version : ",
            "map     : ",
            "type    :  ",
            "os      :  ",
            "     ",
            "-->  ",
            "                ",
            "colony/window11c.mdl",
            "Scoreboard:",
            "Steam Net connection",
            "Disconnect:",
            "    End-to-end",
            "OnEngineDisconnectReason",
            "    reason Kicked",
            "quarry/qr_",
            "Loaded : ",
        };

        public static string[] LogDamage { get; private set; } =
        {
            
        };
        public static string[] LogMatchInfo { get; private set; } =
        {
            
        };
        public static string[] LogDebug { get; private set; } =
        {
            
        };

        public static (string[], LogFlags)[] Coincidense { get; private set; } =
        {
            (LogChat, LogFlags.Chat), //nameof(LogChat)
            (LogDamage, LogFlags.Damage), //nameof(LogDamage)
            (LogMatchInfo, LogFlags.MatchInfo),
            (LogDebug, LogFlags.Debug),
        };
    }
}
