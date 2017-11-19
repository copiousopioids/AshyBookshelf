using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public class Movie : Item
    {
        public Movie(Condition condition, bool available, int damageFine, Genre genre, int id, string title, int weeklyFine, int barcode, string studio, int duration, string description)
        {
            this.Barcode = barcode;
            this.Duration = duration;
            this.Studio = studio;
            this.Decription = description;
            this.Available = available;
            this.Condition = condition;
            this.DamageFine = DamageFine;
            this.Genre = genre;
            this.ID = id;
            this.Title = title;
            this.WeeklyFine = weeklyFine;
        }

        public int Barcode { get; set; }
        public string Studio { get; set; }
        public int Duration { get; set; }
        public string Decription { get; set; }
        public bool Available { get; set; }
        public Condition Condition { get; set; }
        public int DamageFine { get; set; }
        public Genre Genre { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public int WeeklyFine { get; set; }
    }
}
