using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Classes
{
    public class Fine
    {
        public int FineId { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Paid { get; set; }
        public string Description { get; set; }

        public Fine( int fineId, int amount, DateTime dueDate, bool paid, string description)
        {
            this.FineId = fineId;
            this.Amount = amount;
            this.DueDate = dueDate;
            this.Paid = paid;
            this.Description = description;
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Fine: " + Amount;
        }
    }
}
