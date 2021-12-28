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
        /// <br>Method returns a List of List of strings from provided console logs and start index.</br>
        /// <br>Every List of List contains a single damage section of console logs.</br>
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="currentMatchStartIndex"></param>
        /// <returns></returns>
        internal static List<List<string>> ExtractCurrentMatchDamageFromLogFile(List<LogSorted> logs, int currentMatchStartIndex)
        {
            _extractedDamage = new List<List<string>>();
            _damageSection = new List<string>();
            foreach (var item in logs.Where(x => x.LogTypeFlag == LogFlags.Damage && x.Index > currentMatchStartIndex))
            {
                CheckLineForDamage(item);
            }
            return _extractedDamage;
        }
        #endregion

        #region private method
        /// <summary>
        /// Method that separates the damege segments.
        /// </summary>
        /// <param name="log"></param>
        private static void CheckLineForDamage(LogSorted log)
        {
            if (CheckIfLineIsStartOfDamageSegment(log.Line))
            {
                if (CheckIfDamageSectionHasValues(_damageSection))
                {
                    AddSectionToSectionGroup(_extractedDamage, _damageSection);
                }
            }
            _damageSection.Add(log.Line);
        }

        /// <summary>
        /// Method that return if log line is first line of damage section.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static bool CheckIfLineIsStartOfDamageSegment(string line)
        {
            return LogRegex.StartSegmentDamage.IsMatch(line);
        }
        /// <summary>
        /// Method that return if section is not empty.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private static bool CheckIfDamageSectionHasValues(List<string> section)
        {
            return section.Count > 1;
        }

        /// <summary>
        /// Method that add section to group section.
        /// </summary>
        /// <param name="groupSection"></param>
        /// <param name="section"></param>
        private static void AddSectionToSectionGroup(List<List<string>> groupSection, List<string> section)
        {
            if (groupSection.Count > 0)
            {
                if (!Enumerable.SequenceEqual(section, groupSection.Last()))
                {
                    groupSection.Add(section);
                }
            }
            else
            {
                groupSection.Add(section);
            }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            section = new List<string>();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

        }

        #endregion

    }
}
