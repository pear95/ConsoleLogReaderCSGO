using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Data
{
    internal static class Variables
    {
        #region logs

        public static List<LogSorted> ConsoleLines { get; set; }

        public static LogSorted[] ConsoleLinesArray { get; set; }

        #endregion

        #region chat

        public static int LastIndexChat { get; set; }

        #endregion

        #region Console Log Lines

        public const string MessageStartGame = "Steamworks Stats: CSteamWorksGameStatsClient Received CLIENT session id:";
        public const string MessageEndGame = "Steamworks Stats: CSteamWorksGameStatsClient Ending CLIENT session id:";
        public const string MessageDisconnectFromGame = "ChangeGameUIState: CSGO_GAME_UI_STATE_MAINMENU -> CSGO_GAME_UI_STATE_MAINMENU";
        public const string MessageGameStartConfirm = "LoadingScreen::OnNetMsgSetConVar";
        public const string MessageGameEndConfirmPNG = "PNG load error Interlace handling should be turned on when using png_read_image";

        public const string MessageTT = "(Terrorist) ";
        public const string MessageCT = "(Counter-Terrorist) ";
        public const string MessageDead = "*DEAD*";
        public const string MessageTTRegex = @"\(Terrorist\) ";
        public const string MessageCTRegex = @"\(Counter-Terrorist\) ";
        public const string MessageDeadRegex = @"\*DEAD\*";
        public const string MessageUserTextSeparator = " : ";
        public const string MessageMapSpotSeparator = " @ ";
        public const string MessageIDSeperator = "id:";
        public const string MessageDamageUserMinusSeparator = "\" - ";
        public const string MessageDamageUserInSeparator = " in ";

        public const string MessageDamageTaken = "Damage Taken from";
        public const string MessageDamageGiven = "Damage Given to";

        public const string MessageDmg1 = "Damage Given to";
        public const string MessageDmg2 = "Damage Taken from";
        public const string MessageDmg3 = "-------------------------";
        public const string MessageDmg4 = "Player: (.*)- Damage Given";
        public const string MessageDmg5 = "Player: (.*)- Damage Taken";



        #endregion
    }
}
