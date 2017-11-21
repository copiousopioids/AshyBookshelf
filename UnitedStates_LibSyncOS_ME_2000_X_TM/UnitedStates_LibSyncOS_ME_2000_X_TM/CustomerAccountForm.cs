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
    public partial class CustomerAccountForm : Form, ILibraryForm
    {
        public void SetDisplayItems(Customer customerLoggedIn) {
            var balance = 0;
            foreach (var fine in customerLoggedIn.fines)
            {
                balance += fine.Amount;
            }
            uxCustomerBalanceTextBox.Text = balance.ToString();
            uxCustomerAddressTextBox.Text = customerLoggedIn.Address;
            uxCustomerNameTextBox.Text = customerLoggedIn.Name;
            uxCustomerPasswordTextBox.Text = customerLoggedIn.Password;
            uxCustomerPhoneNumberTextBox.Text = customerLoggedIn.PhoneNumber;
            uxCustomerUsernameTextBox.Text = customerLoggedIn.Username;
        }

        public CustomerAccountForm()
        {
            InitializeComponent();
        }

        public string uxCustomerFine {
            set {
                uxCustomerBalanceTextBox.Text = value;
            }    
        }

        public int SelectedIndex
        {
            get
            {
                if (uxCustomerGenericItemsListBox.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxCustomerGenericItemsListBox.SelectedIndex;
            }

            set
            {
                uxCustomerGenericItemsListBox.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxCustomerGenericItemsListBox.SelectedItem == null) throw new Exception("Select a line");
                return uxCustomerGenericItemsListBox.SelectedItem;
            }
        }

        public void AddDisplayItems(params object[] displayObjects)
        {
            uxCustomerGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
        }

        public bool CheckDataValidity()
        {
            if (uxCustomerGenericItemsListBox.SelectedItem == null) {
                MessageBox.Show("Please select an item to return and try again");
                return false;
            }
            return false;
        }

        public void RemoveItem(object objectToRemove) {
            uxCustomerGenericItemsListBox.Items.Remove(objectToRemove);
        }

        public void ClearDisplayItems()
        {
            uxCustomerAddressTextBox.Text = "";
            uxCustomerBalanceTextBox.Text = "";
            uxCustomerGenericItemsListBox.Items.Clear();
            uxCustomerNameTextBox.Text = "";
            uxCustomerPasswordTextBox.Text = "";
            uxCustomerPhoneNumberTextBox.Text = "";
            uxCustomerPhoneNumberTextBox.Text = "";
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog()) {
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
                    case DialogResult.Yes:
                        return DialogReturn.PayFine;
                    case DialogResult.OK:
                        if (CheckDataValidity()) {
                            return DialogReturn.Return;
                        }
                        break;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }
    }
}
