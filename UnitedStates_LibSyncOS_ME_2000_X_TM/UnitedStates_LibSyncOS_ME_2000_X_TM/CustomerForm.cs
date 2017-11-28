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
        string errorMessage = "";
        public Customer_Home()
        {
            InitializeComponent();
        }

        public Customer_Home(LibraryController controller) : this() {
            this.customerAccountForm = new CustomerAccountForm(controller);
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
                            var checkoutItem = customerItemSearchWindow.SelectedItem;
                            var type = checkoutItem.GetType();
                            if (checkoutItem is Book) {
                                var bookToCheckout = (Book)checkoutItem;
                                success = libraryController.DeleteItem(ItemTypes.Book, bookToCheckout.ID, out errorMessage);
                                if (success)
                                {
                                    MessageBox.Show("Item Checked out");
                                    customerItemSearchWindow.ClearDisplayItems();
                                }
                                else {
                                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                    MessageBox.Show("Item could not be checked out " + errorMessage);
                                }
                            }
                            if (checkoutItem is Movie)
                            {
                                var bookToCheckout = (Movie)checkoutItem;
                                success = libraryController.DeleteItem(ItemTypes.Movie, bookToCheckout.ID, out errorMessage);
                                if (success)
                                {
                                    MessageBox.Show("Movie Checked out");
                                    customerItemSearchWindow.ClearDisplayItems();
                                }
                                else
                                {
                                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                    MessageBox.Show("Item could not be checked out " + errorMessage);
                                }
                            }
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
            try
            {
                customerAccountForm.ClearDisplayItems();
                var loggedInUser = libraryController.GetUserIfLoggedIn();
                if (!loggedInUser.isLoggedIn) {
                    MessageBox.Show("User is not logged in");
                    return;
                }
                customerAccountForm.SetDisplayItems(loggedInUser.loggedInCustomer);

                while (true)
                {
                    var dialogResult = customerAccountForm.Display();
                    switch (dialogResult)
                    {
                        case DialogReturn.Return:
                            var itemToReturn = customerAccountForm.SelectedItem;
                            if (itemToReturn is Book)
                            {
                                var bookItemToReturn = (Book)itemToReturn;
                                var result = libraryController.ReturnItem(ItemTypes.Book, bookItemToReturn.ID, out errorMessage);
                                if (result)
                                {
                                    MessageBox.Show("Item returned");
                                    customerAccountForm.RemoveItem(bookItemToReturn);
                                }
                                else
                                {
                                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                    MessageBox.Show("Item could not be returned " + errorMessage);
                                }
                            }
                            else if (itemToReturn is Movie)
                            {
                                var movieItemToReturn = (Movie)itemToReturn;
                                var result = libraryController.ReturnItem(ItemTypes.Movie, movieItemToReturn.ID, out errorMessage);
                                if (result)
                                {
                                    MessageBox.Show("Item Returned");
                                    customerAccountForm.RemoveItem(movieItemToReturn);
                                }
                                else
                                {
                                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                    MessageBox.Show("Item could not be returned " + errorMessage);
                                }
                            }
                            else
                            {
                                throw new Exception("Item type could not be located");
                            }
                            break;
                        case DialogReturn.PayFine:
                            var userLoggedIn = libraryController.GetUserIfLoggedIn();
                            if (userLoggedIn.isLoggedIn)
                            {
                                var result = libraryController.PayFine(userLoggedIn.loggedInCustomer.Username, out errorMessage);
                                if (result)
                                {
                                    MessageBox.Show("Fine has been payed");
                                    customerAccountForm.uxCustomerFine = "0";
                                }
                                else
                                {
                                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                    MessageBox.Show("User fine could not be payed " + errorMessage);
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("User is not logged in");
                                break;
                            }
                        case DialogReturn.Cancel:
                            return;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }          
        }

        private void customerLoginButton_Click(object sender, EventArgs e)
        {
            try {
                customerLoginForm.ClearDisplayItems();
                while (true)
                {
                    var dialogResult = customerLoginForm.Display();
                    switch (dialogResult)
                    {
                        case DialogReturn.Login:
                            var username = customerLoginForm.UXCustomerUsername;
                            var password = customerLoginForm.UXCustomerPassword;
                            var isLoginASuccess = libraryController.CheckUserLoginCredentials(username, password, out errorMessage);
                            if (isLoginASuccess)
                            {
                                MessageBox.Show("User logged in");
                                return;
                            }
                            else
                            {
                                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                MessageBox.Show("User could not be logged in " + errorMessage);
                                break;
                            }
                        case DialogReturn.Cancel:
                            return;
                        default:
                            return;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void customerExitButton_Click(object sender, EventArgs e) // LOGOUT
        {
            try
            {
                var logoutResult = libraryController.LogoutUser();
                if (logoutResult)
                {
                    MessageBox.Show("User logged out.");
                }
                else {
                    MessageBox.Show("User could not be logged out.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        //////////////////////////// HELPER FUNCTIONS //////////////////////////
        public void SearchItemsButtonPressedInCustomerSearchItemWindow()
        {
            var searchString = customerItemSearchWindow.UXCustomerSearchText;

            // TODO > check to see if the string is null...

            var isBookCheckBoxChecked = customerItemSearchWindow.UXCustomerIsSearchBookCheckBoxSelected;
            var isMovieCheckBoxChecked = customerItemSearchWindow.UXCustomerIsSearchMovieCheckBoxSelected;
            ItemSearchOptions searchAttribute = customerItemSearchWindow.customerSearchCriteria;
            var bookAndMovieDisplayObjects = new List<object>();

            if (isBookCheckBoxChecked && isMovieCheckBoxChecked)
            {
                if (searchAttribute == ItemSearchOptions.Person)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.PersonAndBookAndMovie, out errorMessage);
                }
                else if (searchAttribute == ItemSearchOptions.Genre)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.GenreAndBookAndMovie, out errorMessage);
                }
                else
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.TitleAndBookAndMovie, out errorMessage);
                }
            }
            else if (isBookCheckBoxChecked)
            {
                if (searchAttribute == ItemSearchOptions.Person)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.PersonAndBook, out errorMessage);
                }
                else if (searchAttribute == ItemSearchOptions.Genre)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.GenreAndBook, out errorMessage);
                }
                else
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.TitleAndBook, out errorMessage);
                }
            }
            else if (isMovieCheckBoxChecked)
            {
                if (searchAttribute == ItemSearchOptions.Person)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.PersonAndMovie, out errorMessage);
                }
                else if (searchAttribute == ItemSearchOptions.Genre)
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.GenreAndMovie, out errorMessage);
                }
                else
                {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.TitleAndMovie, out errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Check one or both of the following checkboxes: Movies, Books");
                return;
            }
            if (bookAndMovieDisplayObjects.Count == 0 || bookAndMovieDisplayObjects == null) {
                MessageBox.Show("No objects were found " + errorMessage);
                return;
            }
            customerItemSearchWindow.ClearDisplayItems();
            customerItemSearchWindow.AddDisplayItems(bookAndMovieDisplayObjects.ToArray());
        }
    }
}
