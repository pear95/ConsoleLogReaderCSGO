using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal class DamageTaken : DamageType
    {
        #region Public Method
        internal override Base.Damage AddDamageObjectToColection(string line)
        {
            return new Base.Damage()
            {
                AmountDamage = CalculateAlmount(line),
                Target = CalculateTarget(line, DamageFlag.Taken)
            };
        }
        #endregion
    }
}