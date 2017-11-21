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

        Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success);

        Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success);

        Item GetItem(ItemTypes itemType, string searchTitle);

        bool DeleteItem(ItemTypes itemType, int itemId);

        bool CheckoutItem(ItemTypes itemType, int itemId);

        bool ReturnItem(ItemTypes itemType, int itemId);

        Customer GetCustomer(string username, out bool success);

        bool AddCustomer(string username, string password, string name, string address, string phoneNumber);

        Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, out bool success);

        bool DeleteCustomer(string username);

        bool PayFine(string username);

        Fine AddFine(string username, int amount, out bool result);
        List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria);
        bool CheckUserLoginCredentials(string username, string password);
        bool PayIndividualFine(string username, Fine fine);
        List<Person> GetAllContributors(out bool success);
        List<Award> GetAllAwards(out bool success);
        List<Role> GetAllRoles(out bool success);
        List<Genre> GetAllGenres(out bool success);

    }
}
