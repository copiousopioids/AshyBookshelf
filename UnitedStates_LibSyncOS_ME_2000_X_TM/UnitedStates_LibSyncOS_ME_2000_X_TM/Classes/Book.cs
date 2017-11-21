using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public class Book : Item
    {
        public Book(Condition condition, bool available, int damageFine, Genre genre, int id, string title, int weeklyFine, int isbn, string publisher, int numberOfPages, List<Person> contributors) {
            this.Isbn = isbn;
            this.Publisher = publisher;
            this.NumberOfPages = numberOfPages;
            this.Available = available;
            this.Condition = condition;
            this.DamageFine = DamageFine;
            this.Genre = genre;
            this.ID = id;
            this.Title = title;
            this.WeeklyFine = weeklyFine;
            this.contributors = contributors;
        }
        public List<Person> contributors { get; set; }
        public int Isbn { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }

        public bool Available { get; set; }

        public Condition Condition { get; set; }

        public int DamageFine { get; set; }

        public Genre Genre { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }

        public int WeeklyFine { get; set; }

        public override string ToString()
        {
            return "Book: Title - " + Title;
        }
    }
}
