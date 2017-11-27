using System;
using System.Collections.Generic;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Database;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public class LoggedInInformation {
        public bool isLoggedIn;
        public Customer loggedInCustomer;

        public LoggedInInformation(bool loggedIn, Customer loggedInCustomer) {
            this.isLoggedIn = loggedIn;
            this.loggedInCustomer = loggedInCustomer;
        }
    }

    public class LibraryController : IControllerFunctions
    {
        // Initialize a new DB class that implements the IDB interface.
        private DatabaseController databaseController;
        private Customer loggedInCustomer;

        public LibraryController()
        {
            databaseController = new DatabaseController();
        }

        public Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success, out string errorMessage)
        {
            success = true;
            var contributors1 = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors.Add(person1);
            contributors.Add(person2);
            contributors.Add(person3);
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return new Book(new Condition("good", 1), true, 2, new Genre("gospel", 1), 1, "YOLO", 2, 123445, "Happy Tree Friends", 432, contributors1);
            throw new NotImplementedException();
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            result = true;
            return new Fine(1, 23, DateTime.Now, false, "This is the description");
            throw new NotImplementedException();
        }

        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            success = true;
            var contributors1 = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors.Add(person1);
            contributors.Add(person2);
            contributors.Add(person3);

            return new Movie(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the studio", 3, "This is the description", contributors1);
            throw new NotImplementedException();
        }

        public bool CheckoutItem(ItemTypes itemType, Customer loggedInCustomer, int itemId, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomer(string username, out bool success, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            var itemsCheckedOut = new List<Item>();
            var contributors1 = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors1.Add(person1);
            contributors1.Add(person2);
            contributors1.Add(person3);

            var book1 = new Book(new Condition("good", 1), true, 2, new Genre("gospel", 1), 1, "YOLO", 2, 123445, "Happy Tree Friends", 432, contributors1);
            var book2 = new Book(new Condition("good", 1), true, 2, new Genre("gospel", 1), 1, "YOLO", 2, 123445, "Happy Tree Friends", 432, contributors1);
            var movie1 = new Movie(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the studio", 3, "This is the description", contributors1);

            itemsCheckedOut.Add(book1);
            itemsCheckedOut.Add(book2);
            itemsCheckedOut.Add(movie1);
            var fineList = new List<Fine>();
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            success = true;
            return databaseController.GetCustomer(username, out success, out errorMessage);
            //return new Customer(12234, "reaganwood1", "poopoo", "Reagan", "123 Abduction Lane", "1234566", fineList, itemsCheckedOut);
            //throw new NotImplementedException();
        }

        //public Item GetItem(ItemTypes itemType, string searchTitle)
        //{
        //    var contributors = new List<Person>();
        //    var awards = new List<Award>();
        //    var award1 = new Award(1, "pooAward", 21);
        //    var award2 = new Award(1, "pooAward", 21);
        //    var award3 = new Award(1, "pooAward", 21);
        //    var award4 = new Award(1, "pooAward", 21);
        //    awards.Add(award1);
        //    awards.Add(award2);
        //    awards.Add(award3);
        //    awards.Add(award4);

        //    var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
        //    var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
        //    var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
        //    contributors.Add(person1);
        //    contributors.Add(person2);
        //    contributors.Add(person3);

        //    return new Movie(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the studio", 3, "This is the description", contributors);
        //    throw new NotImplementedException();
        //}

        public bool PayFine(string username, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public bool CheckUserLoginCredentials(string username, string password, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public LoggedInInformation GetUserIfLoggedIn() {
            var itemsCheckedOut = new List<Item>();
            var contributors1 = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors1.Add(person1);
            contributors1.Add(person2);
            contributors1.Add(person3);

            var book1 = new Book(new Condition("good", 1), true, 2, new Genre("gospel", 1), 1, "YOLO", 2, 123445, "Happy Tree Friends", 432, contributors1);
            var book2 = new Book(new Condition("good", 1), true, 2, new Genre("gospel", 1), 1, "YOLO", 2, 123445, "Happy Tree Friends", 432, contributors1);
            var movie1 = new Movie(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the studio", 3, "This is the description", contributors1);

            itemsCheckedOut.Add(book1);
            itemsCheckedOut.Add(book2);
            itemsCheckedOut.Add(movie1);
            var fineList = new List<Fine>();
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));
            fineList.Add(new Fine(1, 2, DateTime.Now, true, "this is a fine!"));

            //loggedInCustomer = new Customer(12234, "reaganwood1", "poopoo", "Reagan", "123 Abduction Lane", "1234566", fineList, itemsCheckedOut);
            loggedInCustomer = new Customer(2, "dredmore1", "null", "Drew Redmore", "123 Abduction Lane", "123456", fineList, itemsCheckedOut);
            if (loggedInCustomer == null)
                return new LoggedInInformation(false, null);
            else
                return new LoggedInInformation(true,loggedInCustomer);
        }

        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            return true;
            throw new NotImplementedException();
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage)
        {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            var objectList = new List<object>();
            var contributors = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors.Add(person1);
            contributors.Add(person2);
            contributors.Add(person3);

            var movie = new Movie(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the studio", 3, "This is the description", contributors);
            var book = new Book(new Condition("Good", 1), true, 2, new Genre("thisGenre", 1), 1, "This is the title", 2, 2, "This is the publisher", 3, contributors);
            objectList.Add(book);
            objectList.Add(movie);
            //return objectList;
            return databaseController.searchItems(searchTitle, searchCriteria, out errorMessage);
            //throw new NotImplementedException();
        }
        public List<object> getFines(int CustomerId)
        {
            return databaseController.getFines(CustomerId);
        }

        public int getTotalAmtOwed(int CustomerId)
        {
            return databaseController.getTotalAmtOwed(CustomerId);
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            success = true;
            return person1;
            throw new NotImplementedException();
        }

        public bool LogoutUser() {
            loggedInCustomer = null;
            return true;
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            var contributors = new List<Person>();
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);

            var person1 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person2 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            var person3 = new Person(1, "Roy", "Poo", DateTime.Now, "twitterBro", DateTime.Now, awards, new Role(1, "stageCleaner"));
            contributors.Add(person1);
            contributors.Add(person2);
            contributors.Add(person3);
            success = true;
            return contributors;
            throw new NotImplementedException();
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            var awards = new List<Award>();
            var award1 = new Award(1, "pooAward", 21);
            var award2 = new Award(1, "pooAward", 21);
            var award3 = new Award(1, "pooAward", 21);
            var award4 = new Award(1, "pooAward", 21);
            awards.Add(award1);
            awards.Add(award2);
            awards.Add(award3);
            awards.Add(award4);
            success = true;
            return awards;
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            success = true;
            var roles = new List<Role>();
            var role1 = new Role(1, "director");
            var role2 = new Role(2, "producer");
            var role3 = new Role(3, "author");
            roles.Add(role1);
            roles.Add(role2);
            roles.Add(role3);
            return roles;
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage) {
            errorMessage = "SET ME TO WHATEVER THE ERROR IS, IF NO ERROR, SET ME TO NULL";
            success = true;
            var genres = new List<Genre>();
            var genre1 = new Genre("Rap", 1);
            var genre2 = new Genre("Rock", 1);
            var genre3 = new Genre("Action", 1);
            genres.Add(genre1);
            genres.Add(genre2);
            genres.Add(genre3);
            return genres;
        }

    }
}
