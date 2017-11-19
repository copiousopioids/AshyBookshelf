using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public enum Genres {
        Rap,
        Rock,
        Pop,
        KPOP,
        RandB,
        Country,
        Latin,
        EDM,
        Death,
        Screamyo,
        Metal,
        Action,
        Adventure,
        Comedy,
        Crime,
        Drama,
        Horror,
        Western,
        Romance,
        Uknown
    }

    public class Genre
    {
        public Genres Type;
        public int ID;

        public Genre(string genre, int genreID)
        {
            if (genre == null)
            {
                this.Type = Genres.Uknown;
            }

            this.ID = genreID;

            switch (genre)
            {
                case "Rap":
                    this.Type = Genres.Rap;
                    break;
                case "Rock":
                    this.Type = Genres.Rock;
                    break;
                case "Pop":
                    this.Type = Genres.Pop;
                    break;
                case "KPOP":
                    this.Type = Genres.Pop;
                    break;
                case "RandB":
                    this.Type = Genres.RandB;
                    break;
                case "Country":
                    this.Type = Genres.Country;
                    break;
                case "Latin":
                    this.Type = Genres.Latin;
                    break;
                case "EDM":
                    this.Type = Genres.EDM;
                    break;
                case "Death":
                    this.Type = Genres.Death;
                    break;
                case "Screamyo":
                    this.Type = Genres.Screamyo;
                    break;
                case "Metal":
                    this.Type = Genres.Metal;
                    break;
                case "Action":
                    this.Type = Genres.Action;
                    break;
                case "Adventure":
                    this.Type = Genres.Adventure;
                    break;
                case "Comedy":
                    this.Type = Genres.Comedy;
                    break;
                case "Crime":
                    this.Type = Genres.Crime;
                    break;
                case "Drama":
                    this.Type = Genres.Drama;
                    break;
                case "Horror":
                    this.Type = Genres.Horror;
                    break;
                case "Western":
                    this.Type = Genres.Western;
                    break;
                case "Romance":
                    this.Type = Genres.Romance;
                    break;
                default:
                    this.Type = Genres.Uknown;
                    break;
            }
        }
    }
}
