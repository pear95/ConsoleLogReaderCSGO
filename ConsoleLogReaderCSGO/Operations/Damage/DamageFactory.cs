using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal static class DamageFactory
    {
        #region Public Method
        /// <summary>
        /// Method that returns apporpriate DamageType from provided damage log line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static DamageType CreateDamageType(string line)
        {
            if(IsDamage(line, Variables.MessageDamageTaken)) { return new DamageTaken(); }
            if(IsDamage(line, Variables.MessageDamageGiven)) { return new DamageGiven(); }
            return null;
        }
        #endregion
        #region Private Method
        /// <summary>
        /// Method that returns true if provided log line starts with comparison parameter.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        private static bool IsDamage(string line, string comparison)
        {
            return line.StartsWith(comparison);
        }
        #endregion
    }
}
