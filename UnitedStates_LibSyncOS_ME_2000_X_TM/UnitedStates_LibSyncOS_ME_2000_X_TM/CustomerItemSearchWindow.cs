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
    public partial class CustomerItemSearchWindow : Form, ILibraryForm
    {
        public CustomerItemSearchWindow()
        {
            InitializeComponent();
        }

        public bool UXCustomerIsSearchBookCheckBoxSelected
        {
            get
            {
                return uxCustomerSearchBooksCheckBox.Checked;
            }
        }

        public bool UXCustomerIsSearchMovieCheckBoxSelected
        {
            get
            {
                return uxCustomerSearchMovieCheckBox.Checked;
            }
        }

        public string UXCustomerSearchText
        {
            get
            {
                return uxCustomerSearchItemsTextBox.Text.ToString();
            }
        }

        public int SelectedIndex
        {
            get
            {
                if (uxCustomerGenericItemsList.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxCustomerGenericItemsList.SelectedIndex;
            }

            set
            {
                uxCustomerGenericItemsList.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxCustomerGenericItemsList.SelectedItem == null) throw new Exception("Select a line");
                return uxCustomerGenericItemsList.SelectedItem;
            }
        }

        public void AddDisplayItems(params object[] displayObjects)
        {
            uxCustomerGenericItemsList.Items.AddRange(displayObjects.ToArray());
        }

        public bool CheckDataValidity()
        {
            if (uxCustomerGenericItemsList.SelectedItem == null)
            {
                MessageBox.Show("Select an item to continue");
                return false;
            }
            return true;
        }

        public bool CheckSearchValidity() {
            if (uxCustomerSearchItemsTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please enter an item to search for");
                return false;
            }
            return true;
        }

        public void ClearDisplayItems()
        {
            uxCustomerSearchItemsTextBox.Text = "";
            uxCustomerSearchMovieCheckBox.Checked = false;
            uxCustomerSearchBooksCheckBox.Checked = false;
            uxCustomerGenericItemsList.Items.Clear();
        }

        public DialogReturn Display()
        {
            while (true)
            {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK: 
                        if (CheckDataValidity()) {
                            return DialogReturn.CheckOut;
                        }
                        break;
                    case DialogResult.Cancel:
                        return DialogReturn.Cancel;
                    case DialogResult.Retry:
                        if (CheckSearchValidity())
                        {
                            return DialogReturn.Search;
                        }
                        break;
                    default:
                        return DialogReturn.Undefined;
                }
            }
        }
    }
}
