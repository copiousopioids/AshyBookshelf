using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    interface ILibraryForm
    {
        DialogReturn Display();
        void AddDisplayItems(params object [] displayObjects);
        void ClearDisplayItems();
        int SelectedIndex { get; set; }
        object SelectedItem { get; }
        bool CheckDataValidity();
    }
}
