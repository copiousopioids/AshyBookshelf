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
        Producer,
        Author,
        Editor,
        None
    }

    public class Role
    {
        public int RoleId { get; set; }
        public Roles Type { get; set; }

        public Role (int roleId, string role)
        {
            switch (role)
            {
                case "director":
                    Type = Roles.Director;
                    break;
                case "producer":
                    Type = Roles.Producer;
                    break;
                case "author":
                    Type = Roles.Author;
                    break;
                case "editor":
                    Type = Roles.Editor;
                    break;
                default:
                    Type = Roles.None;
                    break;
            }
            
            RoleId = roleId;
        }

        public override string ToString()
        {
            return "Role: " + Type.ToString();
        }
    }
}
