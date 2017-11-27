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

        Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage);

        Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success, out string errorMessage);

        bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage);

        bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage);

        List<Customer> GetCustomer(string username, out bool success, out string errorMessage);

        bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage);

        Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage);

        bool DeleteCustomer(string username, out string errorMessage);

        bool PayFine(string username, out string errorMessage);

        Fine AddFine(string username, int amount, out bool result, out string errorMessage);
        List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage);
        bool CheckUserLoginCredentials(string username, string password, out string errorMessage);
        bool PayIndividualFine(string username, Fine fine, out string errorMessage);
        List<Person> GetAllContributors(out bool success, out string errorMessage);
        List<Award> GetAllAwards(out bool success, out string errorMessage);
        List<Role> GetAllRoles(out bool success, out string errorMessage);
        List<Genre> GetAllGenres(out bool success, out string errorMessage);

    }
}
