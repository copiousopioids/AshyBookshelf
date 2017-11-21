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
    public partial class StaffCustomerSearchWindow : Form, ILibraryForm
    {
        public StaffCustomerSearchWindow()
        {
            InitializeComponent();
        }

        public String UXStaffCustomerSearchIdString {
            get {
                return uxStaffCustomerSearchTextBox.Text.ToString();
            }
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

        public void AddDisplayItems(params object [] displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
        }

        public bool CheckDataValidity()
        {
            if (uxStaffGenericItemsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                return false;
            }
            
            return true;
        }

        public void ClearDisplayItems()
        {
            uxStaffGenericItemsListBox.Items.Clear();
        }

        public bool CheckSearchValidity() {
            if (string.IsNullOrEmpty(uxStaffCustomerSearchTextBox.Text))
            {
                MessageBox.Show("Please enter a customer username to search");
                return false;
            }
            return true;
        }

        public DialogReturn Display()
        {
            while (true)
            {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK: 
                        return DialogReturn.AddCustomer;
                    case DialogResult.No: 
                        if (CheckDataValidity())
                            return DialogReturn.Delete;
                        break;
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
                    case DialogResult.Retry:
                        if (CheckSearchValidity())
                        {
                            return DialogReturn.Search;
                        }
                        else
                            break;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }
    }
}
