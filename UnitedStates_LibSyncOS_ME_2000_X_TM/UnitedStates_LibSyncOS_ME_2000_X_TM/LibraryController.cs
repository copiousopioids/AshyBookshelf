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
            success = false;
            errorMessage = "System Error";
            return databaseController.AddBook(title, genre, isbn, publisher, numberOfPages, contributors, out success, out errorMessage);

        }

        internal List<Object> GetUserItemsCheckedOut(int customerId)
        {
            return databaseController.GetUserItemsCheckedOut(customerId);
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            errorMessage = "System Error";
            return databaseController.AddCustomer(username, password, name, address, phoneNumber, out errorMessage);
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            result = false;
            errorMessage = "System Error";
            return databaseController.AddFine(username, amount, out result, out errorMessage);
        }

        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            errorMessage = "System Error";
            success = false;
            return databaseController.AddMovie(title, description, genre, duration, barcode, contributors, out success, out errorMessage);
        }

        public bool CheckoutItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            errorMessage = "User was not logged in";
            if (loggedInCustomer == null)
                return false;

            return databaseController.CheckoutItem(itemType, loggedInCustomer, itemId, out errorMessage);
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {

            errorMessage = "System Error";
            return databaseController.DeleteCustomer(username, out errorMessage);
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            errorMessage = "System Error";
            return databaseController.DeleteItem(itemType, itemId, out errorMessage);
        }

        public List<Customer> GetCustomer(string username, out bool success, out string errorMessage)
        {
            errorMessage = "System Error";
            success = false;
            return databaseController.GetCustomer(username, out success, out errorMessage);
        }

        public bool PayFine(string username, out string errorMessage)
        {
            errorMessage = "System Error";
            return databaseController.PayFine(username, out errorMessage);
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage) {

            errorMessage = "System Error";
            return databaseController.PayIndividualFine(username, fine, out errorMessage);
        }

        public Customer CheckUserLoginCredentials(string username, string password, out string errorMessage, out bool success)
        {
            errorMessage = "System Error";
            Customer customer = databaseController.CheckUserLoginCredentials(username, password, out errorMessage, out success);
            if (success)
            {
                loggedInCustomer = customer;
                return loggedInCustomer;
            }
            else
            {
                loggedInCustomer = null;
                return loggedInCustomer ;
            }
        }

        public LoggedInInformation GetUserIfLoggedIn()
        {
            if (loggedInCustomer == null)
                return new LoggedInInformation(false, null);
            else
                return new LoggedInInformation(true,loggedInCustomer);
        }

        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            errorMessage = "System Error";
            return databaseController.ReturnItem(itemType, itemId, out errorMessage);
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage)
        {
            errorMessage = "System Error";
            return databaseController.searchItems(searchTitle, searchCriteria, out errorMessage);
        }
        public List<object> getFines(int CustomerId)
        {
            return databaseController.getFines(CustomerId);
        }

        public int getTotalAmtOwed(int CustomerId)
        {
            return databaseController.getTotalAmtOwed(CustomerId);
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, DateTime dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage) {
            errorMessage = "System Error";
            success = false;
            return databaseController.AddContributor(firstName, lastName, twitterHandle, dateOfBirth, role, awards, out success, out errorMessage);
        }

        public bool LogoutUser() {
            loggedInCustomer = null;
            return true;
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage) {

            success = false;
            errorMessage = "System Error";
            return databaseController.GetAllContributors(out success, out errorMessage);
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage) {

            success = false;
            errorMessage = "System Error";
            return databaseController.GetAllAwards(out success, out errorMessage);
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage) {

            success = false;
            errorMessage = "System Error";
            return databaseController.GetAllRoles(out success, out errorMessage);
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage) {

            success = false;
            errorMessage = "System Error";
            return databaseController.GetAllGenres(out success, out errorMessage);
        }

        public List<Customer> GetAllCustomers(out bool success, out string errorMessage)
        {
            errorMessage = "System Error";
            success = false;
            return databaseController.GetAllCustomers(out success, out errorMessage);
        }

        public List<string> GetItemDetails(Item selectedItem, ItemType itemType)
        {
            return databaseController.GetItemDetails(selectedItem, itemType);
        }
    }
}
