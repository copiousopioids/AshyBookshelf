using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Classes
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Fine> Fines { get; set; }
        public List<Item> ItemsCheckoutOut { get; set; }

        public Customer(int customerId, string username, string password, string name, string address, string phoneNumber, List<Fine> fines, List<Item> itemsCheckedOut)
        {
            CustomerId = customerId;
            Username = username;
            Password = password;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Fines = fines;
            ItemsCheckoutOut = itemsCheckedOut;
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Username: " + Username + ", Name: " + Name + ", Phone: " + PhoneNumber.ToString() + ", Address: " + Address;
        }
    }
}
