using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public enum Conditions
    {
        BrandNew,
        VeryGood,
        Good,
        Acceptable,
        VeryUsed,
        Deceased,
        Uknown
    }
    public class Condition
    {
        public Conditions Type;
        public int ID;

        public Condition(string condition, int conditionID) {

            if (condition == null) {
                this.Type = Conditions.Uknown;
            }

            this.ID = conditionID;

            switch (condition) {
                case "BrandNew":
                    this.Type = Conditions.BrandNew;
                    break;
                case "VeryGood":
                    this.Type = Conditions.VeryGood;
                    break;
                case "Acceptable":
                    this.Type = Conditions.Acceptable;
                    break;
                case "VeryUsed":
                    this.Type = Conditions.VeryUsed;
                    break;
                case "Deceased":
                    this.Type = Conditions.Deceased;
                    break;
                case "Good":
                    this.Type = Conditions.Good;
                    break;
                default:
                    this.Type = Conditions.Uknown;
                    break;
            }
        }
    }
}
