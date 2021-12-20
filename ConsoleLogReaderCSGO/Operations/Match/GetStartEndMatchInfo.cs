using ConsoleLogReaderCSGO.Base;
using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleLogReaderCSGO.Operations.Match
{
    /// <summary>
    /// A class to calculate all matches basic information.
    /// </summary>
    internal static class GetStartEndMatchInfo
    {
        #region Fields
        /// <summary>
        /// List of Match that is returned
        /// </summary>
        private static List<Base.Match> Matches { get; set; }
        /// <summary>
        /// Last match start ID
        /// </summary>
        private static string LastIDMatchStart { get; set; }
        /// <summary>
        /// Last match end ID
        /// </summary>
        private static string LastIDMatchEnd { get; set; }
        /// <summary>
        /// Last match end Index
        /// </summary>
        private static int LastIndexMatchEnd { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// Method to calculated and return List of Match that contains information about all start and end games data.
        /// </summary>
        /// <param name="logs">List of LogSorted </param>
        /// <returns>
        /// <br>• List of Match - A list that contains information about all start and end games data.</br>
        /// </returns>
        public static List<Base.Match> GetMatches(List<LogSorted> logs)
        {
            Matches = new List<Base.Match>();

            for (int i = 0; i < logs.Count; i++)
            {
                var log = logs[i];
                if (log.LogTypeFlag == LogFlags.MatchInfo)
                {
                    if (LogRegex.MatchStart.IsMatch(log.Line) && log.Index.ToString() != LastIDMatchStart)
                    {
                        GetMatchStart(logs, i);
                    }
                    else if (LogRegex.MatchEnd.IsMatch(log.Line))
                    {
                        GetMatchEnd(log);
                    }
                    else if (LogRegex.MatchDisconnect.IsMatch(log.Line))
                    {
                        GetMatchDisconnect(logs, i);
                    }
                }
            }
            return Matches;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Method that confirms if game starts.
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="actualIndex"></param>
        private static void GetMatchStart(List<LogSorted> logs, int actualIndex)
        {
            var log = logs[actualIndex];
            for (int j = -4; j < 4; j++)
            {
                try
                {
                    if (logs[actualIndex + j].Line.Contains(Variables.MessageGameStartConfirm))
                    {
                        Matches.Add(new Base.Match(
                            log.Line[(log.Line.IndexOf(Variables.MessageIDSeperator) + Variables.MessageIDSeperator.Length + 1)..],
                            log.Index,
                            MatchStatus.Start
                            ));
                        LastIDMatchStart = log.Index.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }

        /// <summary>
        /// Method that saves ID and Index of posibble end game.
        /// </summary>
        /// <param name="log"></param>
        private static void GetMatchEnd(LogSorted log)
        {
            string tempMatchID = log.Line[(log.Line.IndexOf(Variables.MessageIDSeperator) + Variables.MessageIDSeperator.Length)..];
            if (tempMatchID != LastIDMatchEnd)
            {
                LastIndexMatchEnd = log.Index;
                LastIDMatchEnd = tempMatchID;
            }
        }

        /// <summary>
        /// Method that confirms if game ends.
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="actualIndex"></param>
        private static void GetMatchDisconnect(List<LogSorted> logs, int actualIndex)
        {
            try
            {
                if (logs[actualIndex + 1].Line.Contains(Variables.MessageDisconnectFromGame))
                {
                    Matches.Add(new Base.Match(
                        LastIDMatchEnd,
                        LastIndexMatchEnd,
                        MatchStatus.End
                        ));
                    return;
                }
                else
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (logs[actualIndex + j].Line.Contains(Variables.MessageGameEndConfirmPNG))
                        {
                            Matches.Add(new Base.Match(
                                LastIDMatchEnd,
                                LastIndexMatchEnd,
                                MatchStatus.End
                                ));
                            return;
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        #endregion

    }
}
