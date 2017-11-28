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
        Uknown,
        War,
        SciFi,
        Thriller,
        Musical,
        Family,
        Mystery,
        Music,
        FilmNoir,
        Fantasy,
        History,
        Biography,
        Documentary,
        Animation,
        Sport
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
                case "War":
                    this.Type = Genres.War;
                    break;
                case "Sci-Fi":
                    this.Type = Genres.SciFi;
                    break;
                case "Thriller":
                    this.Type = Genres.Thriller;
                    break;
                case "Musical":
                    this.Type = Genres.Musical;
                    break;
                case "Family":
                    this.Type = Genres.Family;
                    break;
                case "Mystery":
                    this.Type = Genres.Mystery;
                    break;
                case "Music":
                    this.Type = Genres.Music;
                    break;
                case "Film-Noir":
                    this.Type = Genres.FilmNoir;
                    break;
                case "Fantasy":
                    this.Type = Genres.Fantasy;
                    break;
                case "History":
                    this.Type = Genres.History;
                    break;
                case "Biography":
                    this.Type = Genres.Biography;
                    break;
                case "Documentary":
                    this.Type = Genres.Documentary;
                    break;
                case "Animation":
                    this.Type = Genres.Animation;
                    break;
                case "Sport":
                    this.Type = Genres.Sport;
                    break;
                default:
                    this.Type = Genres.Uknown;
                    break;
            }
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Genre: " + Type.ToString();
        }
    }
}
