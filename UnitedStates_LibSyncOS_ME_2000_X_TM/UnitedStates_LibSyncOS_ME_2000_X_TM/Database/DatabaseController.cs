using System;
using System.Collections.Generic;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Database
{
    public class DatabaseController : IControllerFunctions
    {
        public DatabaseController()
        {
        }

        public Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool CheckoutItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserLoginCredentials(string username, string password, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string username, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(ItemTypes itemType, string searchTitle)
        {
            throw new NotImplementedException();
        }

        public bool PayFine(string username, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool VerifyAccount(string username, string password, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
