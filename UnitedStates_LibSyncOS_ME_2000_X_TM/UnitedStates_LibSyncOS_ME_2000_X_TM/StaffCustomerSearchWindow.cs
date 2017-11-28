using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;

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
                if (uxStaffCustomerSearchListView.SelectedIndices.Count > 0)
                {
                    
                    return uxStaffCustomerSearchListView.SelectedIndices[0];
                }
                throw new Exception("Select a Line");
            }
            set
            {
                // why are you using this.
                uxStaffCustomerSearchListView.SelectedIndices.Add(value);
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffCustomerSearchListView.SelectedItems.Count > 0)
                {
                    return uxStaffCustomerSearchListView.SelectedItems[0];
                }
                throw new Exception("Select a line");
            }            
    }

        public void AddDisplayItems(params object [] customers)
        {
            ListViewItem viewItem;
            List<ListViewItem> viewItems = new List<ListViewItem>();
            foreach(Customer customer in customers)
            {
                viewItem = new ListViewItem(customer.Username);
                viewItem.SubItems.Add(customer.Name);
                viewItem.SubItems.Add(customer.Address);
                viewItem.SubItems.Add(customer.PhoneNumber);
                viewItems.Add(viewItem);                
            }
            uxStaffCustomerSearchListView.Items.AddRange(viewItems.ToArray<ListViewItem>());
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
            if (uxStaffCustomerSearchListView.SelectedItems.Count <= 0) {
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
