using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public interface Item
    {
        string Title { get; set; }
        bool Available { get; set; }
        int WeeklyFine { get; set; }
        int DamageFine { get; set; }
        Condition Condition { get; set; }
        Genre Genre { get; set; }
        int ID { get; set; }
        // TODO: IMPLEMENT PEOPLE ON MERGE
    }
}
