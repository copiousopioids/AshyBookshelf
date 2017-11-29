using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Classes
{
    public enum Roles
    {
        Director,
        Actor,
        Author,
        None
    }

    public class Role
    {
        public int RoleId { get; set; }
        public Roles Type { get; set; }

        public Role (int roleId, string role)
        {
            
            switch (role.ToLower())
            {
                case "director":
                    Type = Roles.Director;
                    break;
                case "author":
                    Type = Roles.Author;
                    break;
                case "actor":
                    Type = Roles.Actor;
                    break;
                default:
                    Type = Roles.None;
                    break;
            }
            
            RoleId = roleId;
        }

        public override string ToString()
        {
            // TODO: Create tostring how you would like element to display in listboxes
            return "Role: " + Type.ToString();
        }
    }
}
