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

        public Customer (int customerId, string username, string password, string name, string address, string phoneNumber)
        {
            CustomerId = customerId;
            Username = username;
            Password = password;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
