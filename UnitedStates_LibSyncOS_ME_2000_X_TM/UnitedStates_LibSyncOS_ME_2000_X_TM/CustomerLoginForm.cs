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
    public partial class CustomerLoginForm : Form, ILibraryNoListBoxForm
    {

        public string UXCustomerUsername {
            get {
                return uxCustomerUsernameTextBox.Text.ToString();
            }
        }

        public string UXCustomerPassword {
            get {
                return uxCustomerPasswordTextBox.Text.ToString();
            }
        }

        public CustomerLoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

        }

        public bool CheckDataValidity()
        {
            if (string.IsNullOrEmpty(uxCustomerUsernameTextBox.Text)) {
                MessageBox.Show("Enter a username");
                return false;
            }
            if (string.IsNullOrEmpty(uxCustomerPasswordTextBox.Text)) {
                MessageBox.Show("Enter a password");
                return false;
            }
            return true;
        }

        public void ClearDisplayItems()
        {
            uxCustomerPasswordTextBox.Text = "";
            uxCustomerUsernameTextBox.Text = "";
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK:
                        if (CheckDataValidity()) {
                            return DialogReturn.Login;
                        }
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
