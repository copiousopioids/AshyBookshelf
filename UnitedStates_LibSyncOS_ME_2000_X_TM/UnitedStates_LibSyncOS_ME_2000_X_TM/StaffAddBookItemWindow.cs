using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    public partial class StaffAddBookItemWindow : Form, ILibraryForm 
    {
        public StaffAddBookItemWindow()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                if (uxStaffGenericItemsListBox.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxStaffGenericItemsListBox.SelectedIndex;
            }

            set
            {
                uxStaffGenericItemsListBox.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffGenericItemsListBox.SelectedItem == null) throw new Exception("Select a line");
                return uxStaffGenericItemsListBox.SelectedItem;
            }
        }

        public void AddDisplayItems(List<object> displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
        }

        public void ClearDisplayItems()
        {
            uxStaffBookPublisherTextBox.Clear();
            uxStaffBookTitleTextBox.Clear();
            uxStaffGenericItemsListBox.Items.Clear();
            uxStaffBookNumberOfPagesTextBox.Clear();

        }

        public DialogReturn Diplay()
        {
            switch (this.ShowDialog()) {
                case DialogResult.OK: return DialogReturn.Create;
                case DialogResult.Yes: return DialogReturn.AddContributor;
                case DialogResult.Cancel: return DialogReturn.Cancel;
                default: return DialogReturn.Undefined;
            }
        }
    }
}
