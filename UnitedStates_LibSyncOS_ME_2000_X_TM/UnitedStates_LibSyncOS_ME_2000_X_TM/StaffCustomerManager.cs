﻿using System;
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
        public void SetDisplay(Customer customer) {
            uxStaffNameTextBox.Text = customer.Name;
            uxStaffUsernameTextBox.Text = customer.Username;
            this.AddDisplayItems(customer.fines.ToArray());
        }

        public int NewFineAmount {
            get {
                try
                {
                    return Convert.ToInt32(uxStaffNewFineAmount.Text);
                }
                catch (Exception ex) {
                    MessageBox.Show("Amount was not an integer" + ex.ToString());
                    return 0;
                }
            }
        }
        public StaffCustomerManager()
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

        public void AddDisplayItems(params object[] displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects);
        }

        public bool CheckDataValidity()
        {
            if (uxStaffNewFineAmount.Text.Equals("")) {
                MessageBox.Show("Please enter a fine amount");
                return false;
            }
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
            uxStaffNewFineAmount.Text = "";
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
                            return DialogReturn.CreateFine;
                        }
                        break;
                    case DialogResult.Yes:
                        if (CheckDataValidityRemoveFine()) {
                            return DialogReturn.RemoveFine;
                        }
                        break;
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
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