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
    public partial class StaffCustomerManager : Form, ILibraryForm
    {
        private LibraryController libraryController;

        public void SetDisplay(Customer customer) {
            uxStaffNameTextBox.Text = customer.Name;
            uxStaffUsernameTextBox.Text = customer.Username;
            //this.AddDisplayItems(customer.fines.ToArray());
            this.AddDisplayItems(libraryController.getFines(customer.CustomerId).ToArray());
            //if (customer.ItemsCheckoutOut != null) 
            //    uxStaffCheckedOutItemsListBox.Items.AddRange(customer.ItemsCheckoutOut.ToArray());
            uxStaffCheckedOutItemsListBox.Items.AddRange(libraryController.GetUserItemsCheckedOut(customer.CustomerId).ToArray());
        }

        public StaffCustomerManager(LibraryController controller)
        {
            this.libraryController = controller;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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

        public void AddDisplayItems(params object[] displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects);
        }

        public bool CheckDataValidity()
        {
            return true;
        }

        public void RemoveItem(Fine fine) {
            uxStaffGenericItemsListBox.Items.Remove(fine);
        }

        public void AddItem(Fine fine) {
            uxStaffGenericItemsListBox.Items.Add(fine);
        }

        public void ClearDisplayItems()
        {
            uxStaffGenericItemsListBox.Items.Clear();
            uxStaffNameTextBox.Text = "";
            uxStaffUsernameTextBox.Text = "";
            uxStaffCheckedOutItemsListBox.Items.Clear();
        }

        public bool CheckDataValidityRemoveFine() {
            if (uxStaffGenericItemsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to remove");
                return false;
            }
            return true;
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog()) {
                    case DialogResult.OK:
                        if (CheckDataValidity()) {
                            return DialogReturn.CreateFine10;
                        }
                        break;
                    case DialogResult.Yes:
                        if (CheckDataValidityRemoveFine()) {
                            return DialogReturn.RemoveFine;
                        }
                        break;
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
                    case DialogResult.Abort: return DialogReturn.CreateFine5;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
