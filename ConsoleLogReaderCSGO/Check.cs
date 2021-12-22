using ConsoleLogReaderCSGO.Base;
using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal static class ExtractDamage
    {
        #region Fields

        private static List<List<string>> _extractedDamage;
        private static List<string> _damageSection;

        #endregion

        #region public method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="currentMatchStartIndez"></param>
        /// <returns></returns>
        public static List<List<string>> ExtractCurrentMatchDamageFromLogFile(List<LogSorted> logs, int currentMatchStartIndez)
        {
            _extractedDamage = new List<List<string>>();
            _damageSection = new List<string>();
            foreach (var item in logs.Where(x => x.LogTypeFlag == LogFlags.Damage && x.Index > currentMatchStartIndez))
            {
                CheckLineForDamage(item);
            }
            return _extractedDamage;
        }
        #endregion

        #region private method
        private static void CheckLineForDamage(LogSorted log)
        {
            if (LogRegex.StartSegmentDamage.IsMatch(log.Line))
            {
                if (_damageSection.Count > 1)
                {
                    if (_extractedDamage.Count > 0)
                    {
                        if (!Enumerable.SequenceEqual(_damageSection, _extractedDamage.Last()))
                        {
                            _extractedDamage.Add(_damageSection);
                        }
                    }
                    else
                    {
                        _extractedDamage.Add(_damageSection);
                    }
                    _damageSection = new List<string>();
                }
            }
            _damageSection.Add(log.Line);
        }
        #endregion

    }
}
