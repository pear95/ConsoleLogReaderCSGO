using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConsoleLogReaderCSGO.Base;

namespace ConsoleLogReaderCSGO.Operations
{
    internal static class SetFlagToLogLine
    {
        /// <summary>
        /// Methods return LogFlag from given Log line
        /// </summary>
        /// <param name="line">Line of console log</param>
        /// <returns></returns>
        public static LogFlags DetermineFlag(string line)
        {
            foreach (var regex in Data.LogRegex.regexLog)
            {
                if (regex.Item1.IsMatch(line))
                {
                    foreach (var coincidense in Data.LogCoincidence.Coincidense)
                    {
                        if (coincidense.Item2 == regex.Item2)
                        {
                            if (!coincidense.Item1.Any(x => line.StartsWith(x)))
                            {
                                return coincidense.Item2;
                            }
                        }
                    }
                }
            }

            return LogFlags.Debug;
        }
    }
}
