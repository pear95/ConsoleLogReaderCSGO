using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Operations.Flag
{
    internal static class SetFlagToLogLine
    {
        /// <summary>
        /// Methods return LogFlag from given Log line
        /// </summary>
        /// <param name="line">Line of console log</param>
        /// <returns>
        /// Log flag that describe line type.
        /// </returns>
        public static LogFlags DetermineFlag(string line)
        {
            //Every Logflag has Regular Expression pattern and Exceptions list.
            
            //Iterate patterns of RegularExpression looking for a match with 'line'.
            foreach (var patternRegex in Data.LogRegex.regexLog)
            {
                if (patternRegex.Item1.IsMatch(line))
                {
                    //Iterate coincidense for find the same ID (Logflag) that patternRegex.
                    foreach (var coincidence in Data.LogCoincidence.Coincidence)
                    {
                        if (coincidence.Item2 == patternRegex.Item2)
                        {
                            //If there is not concurrence with exceptions list. 
                            if (!coincidence.Item1.Any(x => line.StartsWith(x)))
                            {
                                return coincidence.Item2;
                            }
                        }
                    }
                }
            }
            return LogFlags.Debug;
        }
    }
}
