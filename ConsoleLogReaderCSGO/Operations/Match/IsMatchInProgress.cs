using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Match
{
    /// <summary>
    /// Class to calculate if match is in progress.
    /// </summary>
    internal static class IsMatchInProgress
    {
        /// <summary>
        /// Method to check if game is in progress from provided List of Match
        /// </summary>
        /// <param name="matches"></param>
        /// <returns>
        /// <br>• bool - if game match is in progress</br>
        /// <br>• int - Index when match start</br>
        /// </returns>
        public static (bool, int) Check(List<Base.Match> matches)
        {
            if (matches.Count > 0)
            {
                if (matches.Last().Status == MatchStatus.Start)
                {
                    return (true, matches.Last().Index);
                }
            }
            return (false, -1);
        }
    }
}
