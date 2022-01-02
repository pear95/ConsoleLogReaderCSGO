using ConsoleLogReaderCSGO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLogReaderCSGO.Operations.Damage
{
    internal static class CreateDamageSegment
    {
        #region Field

        private static List<Base.Damage> _taken, _given;
        private static List<Base.DamageSegment> _segments;

        #endregion

        #region public method
        /// <summary>
        /// Method that create List of Damage from provided segments (List of List of strings)
        /// </summary>
        /// <param name="segments">Segments</param>
        /// <returns></returns>
        public static List<Base.DamageSegment> CreateDamageSegments(List<List<string>> segments)
        {
            _segments = new List<Base.DamageSegment>();
            foreach (var i1 in segments.Select((Value, Index) => (Value, Index)).Where(x => x.Index >= 0))
            {
                _taken = new List<Base.Damage>();
                _given = new List<Base.Damage>();

                foreach (var line in i1.Value)
                {
                    CheckLineForDamageType(line);
                }

                _segments.Add(new Base.DamageSegment()
                {
                    ID = i1.Index,
                    Taken = _taken.ToArray(),
                    Given = _given.ToArray(),
                }) ;
            }
            return _segments;
        }

        #endregion

        #region Private method
        /// <summary>
        /// <br>Method that checking what type of damage is damage line.</br>
        /// <br>If log type is not null then log line data is added to right collection.</br>
        /// </summary>
        /// <param name="line"></param>
        private static void CheckLineForDamageType(string line)
        {
            var factory = DamageFactory.CreateDamageType(line);
            if(factory != null)
            {
                switch (factory)
                {
                    case DamageTaken _:
                        _taken.Add(factory.AddDamageObjectToColection(line));
                        break;
                    case DamageGiven _:
                        _given.Add(factory.AddDamageObjectToColection(line));
                        break;
                }
            }
        }
        #endregion
    }
}