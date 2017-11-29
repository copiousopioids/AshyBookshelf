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
    public partial class StaffCreateCustomerWindow : Form, ILibraryNoListBoxForm
    {
        LibraryController libraryControl = new LibraryController();
        public StaffCreateCustomerWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public string UXStaffUsername {
            get {
                return uxStaffUsernameTextBox.Text.ToString();
            }
        }

        public string UXStaffPassword
        {
            get
            {
                return uxStaffPasswordTextBox.Text.ToString();
            }
        }

        public string UXStaffName
        {
            get
            {
                return uxStaffNameTextBox.Text.ToString();
            }
        }

        public string UXStaffAddress
        {
            get
            {
                return uxStaffAddressTextBox.Text.ToString();
            }
        }

        public string UXStaffPhoneNumber
        {
            get
            {
                return uxStaffPhoneNumberTextBox.Text.ToString();
            }
        }

        public bool CheckDataValidity()
        {
            if (string.IsNullOrEmpty(uxStaffUsernameTextBox.Text)) {
                MessageBox.Show("Please enter a username");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffPasswordTextBox.Text))
            {
                MessageBox.Show("Please enter a password");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffNameTextBox.Text))
            {
                MessageBox.Show("Please enter a name");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffAddressTextBox.Text))
            {
                MessageBox.Show("Please enter an address");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffPhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a phone number");
                return false;
            }
            return true;
        }

        public void ClearDisplayItems()
        {
            uxStaffUsernameTextBox.Text = "";
            uxStaffPasswordTextBox.Text = "";
            uxStaffPhoneNumberTextBox.Text = "";
            uxStaffNameTextBox.Text = "";
            uxStaffAddressTextBox.Text = "";
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog()) {
                    case DialogResult.OK:
                        if (CheckDataValidity())
                        {
                            return DialogReturn.Create;
                        }
                        else
                            break;
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }
    }
}
