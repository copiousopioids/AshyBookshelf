using System;
using System.Collections.Generic;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Database;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    internal class LibraryController : IControllerFunctions
    {
        // Initialize a new DB class that implements the IDB interface.
        private DatabaseController databaseController;

        public LibraryController()
        {
            databaseController = new DatabaseController();
        }

        public bool AddBook(string title, string genre, string isbn, string publisher, int numberOfPages, List<Person> contributors)
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

        public bool AddMovie(string title, string description, string genre, string condition, int duration, string barcode, List<Person> contributors)
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

        public Customer GetCustomer(string username)
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

        public bool VerifyAccount(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
