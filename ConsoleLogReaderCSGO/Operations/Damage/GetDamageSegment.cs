using ConsoleLogReaderCSGO.Base;
using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal static class GetDamageSegment
    {
        #region Fields
        private static List<Base.Match> _matches;
        private static int _startMatchLastIndex;
        #endregion

        #region Methods
        /// <summary>
        /// A general method that calculate DamageSegment of acual played match from provided console logs.
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public static Base.DamageSegment[] GetActualGameAllDamageSegment(List<LogSorted> logs)
        {
            var matchesStartEndInfo = Match.GetStartEndMatchInfo.GetMatches(logs);

            if (_matches == null) { _matches = matchesStartEndInfo; }
            else { _matches.AddRange(matchesStartEndInfo); }

            var matchInProgress = Match.IsMatchInProgress.Check(_matches);
            return TryGetDamage(matchInProgress, logs);
        }
        #endregion

        #region Method private
        /// <summary>
        /// Method that returns a Array of DamageSegment if match is playing in this moment, from provided logs and MatchInfo data.
        /// </summary>
        /// <param name="matchInfo"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        private static Base.DamageSegment[] TryGetDamage((bool, int) matchInfo, List<LogSorted> logs)
        {
            if (matchInfo.Item1)
            {
                if (IsNewMatch(matchInfo.Item2))
                {
                    _startMatchLastIndex = matchInfo.Item2;
                    return null;
                }
                else
                {
                    var damageExtracted = ExtractDamage.ExtractCurrentMatchDamageFromLogFile(logs, matchInfo.Item2); //_startMatchLastIndex
                    return CreateDamageSegment.CreateDamageSegments(damageExtracted).ToArray();
                }
            }
            return null;
        }
        /// <summary>
        /// Method return true if match index is newest. That mean if is new match.
        /// </summary>
        /// <param name="matchIndex"></param>
        /// <returns></returns>
        private static bool IsNewMatch(int matchIndex)
        {
            return _startMatchLastIndex > matchIndex;
        }
        #endregion
    }
}
