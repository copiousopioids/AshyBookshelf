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
    public partial class Customer_Home : Form
    {
        LibraryController libraryController;
        CustomerAccountForm customerAccountForm;
        CustomerLoginForm customerLoginForm;
        CustomerItemSearchWindow customerItemSearchWindow;

        public Customer_Home()
        {
            InitializeComponent();
        }

        public Customer_Home(LibraryController controller) : this() {
            this.customerAccountForm = new CustomerAccountForm();
            this.customerLoginForm = new CustomerLoginForm();
            this.customerItemSearchWindow = new CustomerItemSearchWindow();
            this.libraryController = controller;
        }

        //////////////////////////// CLICK FUNCTIONS //////////////////////////

        private void customerFindItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                while (true)
                {
                    var success = false;
                    var dialogReturn = customerItemSearchWindow.Display();
                    switch (dialogReturn)
                    {
                        case DialogReturn.CheckOut:

                            break;
                        case DialogReturn.Cancel:
                            return;
                        case DialogReturn.Search:
                            SearchItemsButtonPressedInCustomerSearchItemWindow();
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void customerAccountInformationButton_Click(object sender, EventArgs e)
        {

        }

        private void customerLoginButton_Click(object sender, EventArgs e)
        {

        }

        private void customerExitButton_Click(object sender, EventArgs e)
        {

        }

        //////////////////////////// HELPER FUNCTIONS //////////////////////////
        public void SearchItemsButtonPressedInCustomerSearchItemWindow()
        {
            var searchString = customerItemSearchWindow.UXCustomerSearchText;

            var isBookCheckBoxChecked = customerItemSearchWindow.UXCustomerIsSearchBookCheckBoxSelected;
            var isMovieCheckBoxChecked = customerItemSearchWindow.UXCustomerIsSearchMovieCheckBoxSelected;
            var bookAndMovieDisplayObjects = new List<object>();

            if (isBookCheckBoxChecked && isMovieCheckBoxChecked)
            {
                bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.BookAndMovie);
            }
            else if (isBookCheckBoxChecked)
            {
                bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.Book);
            }
            else if (isMovieCheckBoxChecked)
            {
                bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.Movie);
            }
            else
            {
                MessageBox.Show("Check one or both of the following checkboxes: Movies, Books");
                return;
            }
            if (bookAndMovieDisplayObjects.Count == 0 || bookAndMovieDisplayObjects == null) {
                MessageBox.Show("No objects were found");
                return;
            }
            customerItemSearchWindow.ClearDisplayItems();
            customerItemSearchWindow.AddDisplayItems(bookAndMovieDisplayObjects);
        }
    }
}
