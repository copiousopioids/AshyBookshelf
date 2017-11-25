using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Classes
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TwitterHandle { get; set; }
        public DateTime DeathDate { get; set; }
        public List<Award> Award { get; set; }
        public Role Role { get; set; }

        public Person(
            int personId, 
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            string twitterHandle, 
            DateTime deathDate,
            List<Award> award,
            Role role)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TwitterHandle = twitterHandle;
            DeathDate = deathDate;
            Award = award;
            Role = role;
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Person: Name: " + FirstName + " " + LastName;
        }
    }
}
