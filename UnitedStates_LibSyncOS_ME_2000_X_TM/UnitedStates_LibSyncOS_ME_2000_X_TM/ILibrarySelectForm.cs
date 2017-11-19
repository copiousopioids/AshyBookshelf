using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    interface ILibrarySelectForm
    {
        DialogResult Display();
        int SelectedIndex { get; set; }
        void UpdateDisplayItems(Object[] list);
        void ClearDisplayItems();
    }

    interface ILibraryEnterForm {
        DialogResult Display();
    }
}
