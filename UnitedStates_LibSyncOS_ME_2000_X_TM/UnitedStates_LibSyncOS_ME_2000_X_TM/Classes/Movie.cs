using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public class Movie : Item
    {
        public Movie(Condition condition, bool available, int damageFine, Genre genre, int id, string title, int weeklyFine, int barcode, string studio, int duration, string description, List<Person> contributors)
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
            this.contributors = contributors;
        }

        public List<Person> contributors;
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

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Movie: Title - " + Title + ", Genre - " + Genre.ToString() + ", Available - " + Available.ToString();
        }
    }
}
