using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal abstract class DamageType
    {
        #region Public Method
        /// <summary>
        /// Method that returns a right Damage object from provided log line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal abstract Base.Damage AddDamageObjectToColection(string line);
        #endregion

        #region Protected Methods
        /// <summary>
        /// Method that returns right Amount data from provided log line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal protected int CalculateAlmount(string line)
        {
            return int.TryParse(SubstringAmount(line), out int result) ? result : 0;
        }

        /// <summary>
        /// Method that returns a Target data from provided log line and DamageType.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal protected string CalculateTarget(string line, DamageFlag type)
        {
            return SubstringTarget(line, type);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method returns a Amount data from provided log damage line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string SubstringAmount(string line)
        {
            return line[(line.IndexOf(Variables.MessageDamageUserMinusSeparator) + 4)..line.IndexOf(Variables.MessageDamageUserInSeparator)];
        }

        /// <summary>
        /// Method returns a Target data from provided log damage line and type of damage.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string SubstringTarget(string line, DamageFlag type)
        {
            string damageType = type == DamageFlag.Taken ? Variables.MessageDamageTaken 
                : type == DamageFlag.Given ? Variables.MessageDamageGiven
                : string.Empty;
            return line[(line.IndexOf(damageType) + damageType.Length + 2)..line.IndexOf(Variables.MessageDamageUserMinusSeparator)];
        }
        #endregion
    }
}
