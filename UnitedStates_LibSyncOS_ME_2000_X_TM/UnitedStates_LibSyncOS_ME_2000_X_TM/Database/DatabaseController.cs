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

        public Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success)
        {
            throw new NotImplementedException();
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, out bool success)
        {
            throw new NotImplementedException();
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool AddFine(string username)
        {
            throw new NotImplementedException();
        }

        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success)
        {
            throw new NotImplementedException();
        }

        public bool CheckoutItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string username, out bool success)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(ItemTypes itemType, string searchTitle)
        {
            throw new NotImplementedException();
        }

        public bool PayFine(string username)
        {
            throw new NotImplementedException();
        }

        public bool ReturnItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomers(string searchCriteria, out bool success)
        {
            throw new NotImplementedException();
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool VerifyAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserLoginCredentials(string username, string password) {
            throw new NotImplementedException();
        }
    }
}
