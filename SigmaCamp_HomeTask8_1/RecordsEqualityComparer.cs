using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask8_1
{
    internal class PersonKeyComparer:IEqualityComparer<KeyValuePair<Person, List<ConsumptionRecord>>>
    {
        public bool Equals(KeyValuePair<Person, List<ConsumptionRecord>> personRecords1, KeyValuePair<Person, List<ConsumptionRecord>> personRecords2)
        {
            return personRecords1.Key.Equals(personRecords2.Key);
        }

        public int GetHashCode(KeyValuePair<Person, List<ConsumptionRecord>> personRecords)
        {
            return personRecords.Key.GetHashCode();
        }
    }
}
