using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Database
{
    interface IControllerFunctions
    {
        bool VerifyAccount(string username, string password);

        bool AddMovie(string title, string description, string genre, 
            string condition, int duration, string barcode, List<Person> contributors);

        Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success);

        Item GetItem(ItemTypes itemType, string searchTitle);

        bool DeleteItem(ItemTypes itemType, int itemId);

        bool CheckoutItem(ItemTypes itemType, int itemId);

        bool ReturnItem(ItemTypes itemType, int itemId);

        Customer GetCustomer(string username);

        bool AddCustomer(string username, string password, string name, string address, string phoneNumber);

        Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, out bool success);

        bool DeleteCustomer(string username);

        bool PayFine(string username);

        bool AddFine(string username);
        List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria);

    }
}
