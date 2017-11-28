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
                if (uxStaffCustomerSearchListView.SelectedIndices == -1) throw new Exception("Select a Line");
                return uxStaffCustomerSearchListView.SelectedIndices;
            }

            set
            {
                uxStaffCustomerSearchListView.Sele = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffCustomerSearchListView.SelectedItem == null) throw new Exception("Select a line");
                return uxStaffCustomerSearchListView.SelectedItem;
            }
        }

        public void AddDisplayItems(params object [] displayObjects)
        {
            uxStaffCustomerSearchListView.Items.AddRange(displayObjects.ToArray());
        }

        public bool CheckDataValidity()
        {
            if (uxStaffCustomerSearchListView.SelectedItems == null)
            {
                MessageBox.Show("Please select an item");
                return false;
            }
            
            return true;
        }

        public void ClearDisplayItems()
        {
            uxStaffCustomerSearchListView.Items.Clear();
        }

        public bool CheckSearchValidity() {
            if (string.IsNullOrEmpty(uxStaffCustomerSearchTextBox.Text))
            {
                MessageBox.Show("Please enter a customer username to search");
                return false;
            }
            return true;
        }

        public bool CheckSelectCustomerValidity () {
            if (uxStaffCustomerSearchListView.SelectedItem == null) {
                MessageBox.Show("Please select a customer to continue with this action");
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
                    case DialogResult.Ignore:
                        if (CheckSelectCustomerValidity()) {
                            return DialogReturn.Select;
                        }
                        break;
                    case DialogResult.Yes:
                        return DialogReturn.ListCustomers;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }
    }
}
