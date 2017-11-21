﻿using System;
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

        public Fine( int fineId, int amount, string dueDate, string paid, string description)
        {
            this.FineId = fineId;
            this.Amount = amount;
            this.DueDate = DateTime.Parse(dueDate);
            this.Paid = bool.Parse(paid);
            this.Description = description;
        }
    }
}
