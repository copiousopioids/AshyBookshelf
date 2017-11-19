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
        DialogResult Diplay();
        void AddDisplayItems();
        void DeleteDisplayItems();
        int SelectedIndex { get; set; }
    }
}
