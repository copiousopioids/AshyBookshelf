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
    public partial class StaffWindow : Form
    {
        private StaffAddBookItemWindow staffAddBookItemWindow;
        private StaffAddContributorWindow staffAddContributorWindow;
        private StaffAddMovieItemWindow staffAddMovieItemWindow;
        private StaffCustomerSearchWindow staffCustomerSearchWindow;
        private StaffItemSearchWindow staffItemSearchWindow;
        private LibraryController libraryController;

        public StaffWindow()
        {
            InitializeComponent();
        }

        public StaffWindow(LibraryController controller) : this()
        {
            this.staffAddBookItemWindow = new StaffAddBookItemWindow();
            this.staffAddContributorWindow = new StaffAddContributorWindow();
            this.staffAddMovieItemWindow = new StaffAddMovieItemWindow();
            this.staffCustomerSearchWindow = new StaffCustomerSearchWindow();
            this.staffItemSearchWindow = new StaffItemSearchWindow();
            this.libraryController = controller;
        }

        private void button1_Click(object sender, EventArgs e) // SEARCH ITEMS BUTTON CLICKED
        {
            while (true) {
                try
                {
                    var dialogReturn = staffItemSearchWindow.Diplay();
                    switch (dialogReturn) {
                        case DialogReturn.Search:
                            SearchItemsButtonPressed();
                            break;
                        case DialogReturn.AddBook:
                            AddBookThroughAddBookWindow();
                            break;
                        case DialogReturn.AddMovie:
                            break;
                        case DialogReturn.Cancel:
                            this.Hide();
                            break;
                        case DialogReturn.Delete:
                            DeleteItemFromLibrary();
                            return;
                            break;
                        case DialogReturn.Undefined:
                            throw new Exception("Dialog did not return properly");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void DeleteItemFromLibrary()
        {
            try
            {
                var selectedItem = staffItemSearchWindow.SelectedItem;
                if (selectedItem is Movie) {

                    var bookItem = (Book)selectedItem;
                    if (libraryController.DeleteItem(ItemTypes.Movie, bookItem.ID))
                    {
                        MessageBox.Show("Book Deleted");
                        staffItemSearchWindow.ClearDisplayItems();
                    }
                    else
                    {
                        MessageBox.Show("Could not delete item from the library catalog");
                    }
                } else if (selectedItem is Movie) {

                    var movieItem = (Movie)selectedItem;
                    if (libraryController.DeleteItem(ItemTypes.Movie, movieItem.ID)) {
                        MessageBox.Show("Movie Deleted");
                        staffItemSearchWindow.ClearDisplayItems();
                    } else {
                        MessageBox.Show("Could not delete item from the library catalog");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AddBookThroughAddBookWindow() {
            try
            {
                
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SearchItemsButtonPressed()
        {  
            var searchString = staffItemSearchWindow.staffSearchString;
            staffItemSearchWindow.ClearDisplayItems();

            if (!searchString.Equals(""))
            {
                var isBookCheckBoxChecked = staffItemSearchWindow.staffIsSearchBookCheckBoxSelected;
                var isMovieCheckBoxChecked = staffItemSearchWindow.staffIsSearchMovieCheckBoxSelected;
                var bookAndMovieDisplayObjects = new List<object>();

                if (isBookCheckBoxChecked && isMovieCheckBoxChecked) {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.BookAndMovie);
                } else if (isBookCheckBoxChecked) {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.Book);
                } else if (isMovieCheckBoxChecked) {
                    bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.Movie);
                } else {
                    MessageBox.Show("Check one or both of the following checkboxes: Movies, Books");
                    return;
                }
                staffItemSearchWindow.AddDisplayItems(bookAndMovieDisplayObjects);
            }
            else
            {
                MessageBox.Show("Please enter something into the search box before searching");
            }
        }

        private void staffSearchCustomerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
