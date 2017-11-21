using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Classes
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Award (int awardId, string name, int year)
        {
            AwardId = awardId;
            Name = name;
            Year = year;
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Award: " + Name;
        }
    }
}
