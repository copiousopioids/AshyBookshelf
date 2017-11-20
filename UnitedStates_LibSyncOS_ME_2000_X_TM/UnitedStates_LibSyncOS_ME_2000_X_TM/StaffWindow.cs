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
    public partial class StaffWindow : Form
    {
        private StaffAddBookItemWindow staffAddBookItemWindow;
        private StaffAddContributorWindow staffAddContributorWindow;
        private StaffAddMovieItemWindow staffAddMovieItemWindow;
        private StaffCustomerSearchWindow staffCustomerSearchWindow;
        private StaffItemSearchWindow staffItemSearchWindow;
        private LibraryController libraryController;
        private CreateContributorWindow staffCreateContributorWindow;

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
            this.staffCreateContributorWindow = new CreateContributorWindow();
            
            this.libraryController = controller;
        }

        private void button1_Click(object sender, EventArgs e) // SEARCH ITEMS BUTTON CLICKED
        {
            while (true) {
                try
                {
                    var dialogReturn = staffItemSearchWindow.Display();
                    switch (dialogReturn) {
                        case DialogReturn.Search:
                            SearchItemsButtonPressed();
                            break;
                        case DialogReturn.AddBook:
                            var success = false;
                            var book = AddAndGetBookThroughAddBookWindow(out success);
                            if (success)
                                staffItemSearchWindow.AddItem(book);
                            break;
                        case DialogReturn.AddMovie:
                            break;
                        case DialogReturn.Cancel:
                            this.Hide();
                            break;
                        case DialogReturn.Delete:
                            DeleteItemFromLibrary();
                            return;
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
            var selectedItem = staffItemSearchWindow.SelectedItem;
            if (selectedItem is Movie)
            {

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
            }
            else if (selectedItem is Movie)
            {

                var movieItem = (Movie)selectedItem;
                if (libraryController.DeleteItem(ItemTypes.Movie, movieItem.ID))
                {
                    MessageBox.Show("Movie Deleted");
                    staffItemSearchWindow.ClearDisplayItems();
                }
                else
                {
                    MessageBox.Show("Could not delete item from the library catalog");
                }
            }
        }

        public Book AddAndGetBookThroughAddBookWindow(out bool success) {
            while (true) {
                var addBookWindowDialogReturn = staffAddBookItemWindow.Display();
                switch (addBookWindowDialogReturn)
                {
                    case DialogReturn.AddContributor:
                        var contributor = PickContributorForItem();
                        if (contributor != null)
                            staffAddBookItemWindow.AddItem(contributor);
                        break;
                    case DialogReturn.Create:
                        var title = staffAddBookItemWindow.UXStaffBookTitleText;
                        var numberOfPages = Convert.ToInt32(staffAddBookItemWindow.UXStaffBookNumberOfPagesText);
                        var publisher = staffAddBookItemWindow.UXStaffBookPublisherText;
                        var contributors = staffAddBookItemWindow.GetAllItems();
                        var genre = (Genre)staffAddBookItemWindow.UXStaffBookGenre;
                        var isbn = staffAddBookItemWindow.UXStaffBookISBN;
                        success = false;
                        var book = libraryController.AddBook(title, genre, isbn, publisher, numberOfPages, contributors, out success);
                        if (success == false)
                        {
                            MessageBox.Show("The book could not be added. We're sorry");
                        }
                        else
                            success = true;
                        return book;
                    case DialogReturn.Cancel:
                        success = false;
                        return null;
                    default:
                        break;
                }
            }           
        }

        public Person PickContributorForItem() {

            var addContributorDialogReturn = staffAddContributorWindow.Display();
            switch (addContributorDialogReturn) {
                case DialogReturn.AddContributor:
                    var contributor = staffAddContributorWindow.SelectedItem;
                    if (contributor is Person)
                        return (Person)contributor;
                    else
                    {
                        MessageBox.Show("A contributor was not selected");
                    }
                    break;
                case DialogReturn.Create:
                    var newContributor = LaunchCreateContributorWindowAndCreateContributor();
                    return newContributor;
                case DialogReturn.Cancel:
                    break;
                default:
                    break;
            }
            return null;
        }

        public Person LaunchCreateContributorWindowAndCreateContributor() {

            var createContributorDialogReturn = staffCreateContributorWindow.Display();
            switch (createContributorDialogReturn) {
                case DialogReturn.Create:
                    var firstName = staffCreateContributorWindow.UXStaffContributorFirstName;
                    var lastName = staffCreateContributorWindow.UXStaffContributorLastName;
                    var twitterHandle = staffCreateContributorWindow.UXStaffContributorTwitterHandle;
                    var dateOfBirth = staffCreateContributorWindow.UXStaffContributorDateOfBirth;
                    var role = staffCreateContributorWindow.UXStaffRoleSelected;
                    var success = false;
                    var contributor = libraryController.AddContributor(firstName, lastName, twitterHandle, dateOfBirth, role, out success);
                    if (!success)
                        MessageBox.Show("Contributor could not be created");
                    return contributor;
                case DialogReturn.Cancel:
                    break;
                default:
                    throw new Exception("An unregistered Dialog Return was created");
            }
            return null;
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
