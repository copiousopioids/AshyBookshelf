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
        private StaffCreateCustomerWindow staffCreateCustomerWindow;
        private StaffCustomerManager staffCustomerManager;

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
            this.staffCreateCustomerWindow = new StaffCreateCustomerWindow();
            this.staffCustomerManager = new StaffCustomerManager();
            
            this.libraryController = controller;
        }

        private void button1_Click(object sender, EventArgs e) // SEARCH ITEMS BUTTON CLICKED
        {
            while (true) {
                try
                {
                    var success = false;
                    var dialogReturn = staffItemSearchWindow.Display();
                    switch (dialogReturn) {
                        case DialogReturn.Search:
                            SearchItemsButtonPressed();
                            break;
                        case DialogReturn.AddBook:                           
                            var book = AddAndGetBookThroughAddBookWindow(out success);
                            if (success)
                                staffItemSearchWindow.AddItem(book);
                            break;
                        case DialogReturn.AddMovie:
                            var movie = AddAndGetMovieThroughAddMoviekWindow(out success);
                            if (success)
                                staffItemSearchWindow.AddItem(movie);
                            break;
                        case DialogReturn.Cancel:
                            return;
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

        public Movie AddAndGetMovieThroughAddMoviekWindow(out bool success) {
            staffAddMovieItemWindow.ClearDisplayItems();
            try
            {
                while (true)
                {
                    var addMovieWindowDialogReturn = staffAddMovieItemWindow.Display();
                    switch (addMovieWindowDialogReturn)
                    {
                        case DialogReturn.AddContributor:
                            var contributor = PickContributorForItem();
                            if (contributor != null)
                                staffAddMovieItemWindow.AddItem(contributor);
                            break;
                        case DialogReturn.Create:
                            success = false;
                            var title = staffAddMovieItemWindow.UXStaffMovieTitle;
                            var duration = staffAddMovieItemWindow.UXStaffMovieDuration;
                            var description = staffAddMovieItemWindow.UXStaffMovieDescription;
                            var studio = staffAddMovieItemWindow.UXStaffMovieStudio;
                            var genre = staffAddMovieItemWindow.UXStaffMovieGenre;
                            var contributors = staffAddMovieItemWindow.GetAllItems();
                            var barcode = staffAddMovieItemWindow.UXStaffMovieBarcode;
                            var movie = libraryController.AddMovie(title, description, genre, duration, barcode, contributors, out success);
                            if (!success)
                                MessageBox.Show("Movie could not be addede");
                            return movie;
                        case DialogReturn.Cancel:
                            success = false;
                            return null;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                success = false;
                return null;
            }
            
        }

        public Book AddAndGetBookThroughAddBookWindow(out bool success) {

            staffAddBookItemWindow.ClearDisplayItems();
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
            try
            {

                var success = false;
                var existingContributors = libraryController.GetAllContributors(out success);
                if (!success) {
                    MessageBox.Show("Contributors could not be retrieved");
                    return null;
                }

                staffAddContributorWindow.ClearDisplayItems();
                staffAddContributorWindow.AddDisplayItems(existingContributors);

                var addContributorDialogReturn = staffAddContributorWindow.Display();
                switch (addContributorDialogReturn)
                {
                    case DialogReturn.AddContributor:
                        var contributor = staffAddContributorWindow.SelectedItem;
                        if (contributor is Person)
                            return (Person)contributor;
                        else
                        {
                            MessageBox.Show("A contributor was not selected");
                            return null;
                        }
                        break;
                    case DialogReturn.Create:
                        var newContributor = LaunchCreateContributorWindowAndCreateContributor();
                        return newContributor;
                    case DialogReturn.Cancel:
                        return null;
                    default:
                        return null;
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public Person LaunchCreateContributorWindowAndCreateContributor() {

            staffCreateContributorWindow.ClearDisplayItems();
            var success = false;
            var existingAwards = libraryController.GetAllAwards(out success);
            if (!success) {
                MessageBox.Show("Awards could not be retrieved");
                return null;
            }
            staffCreateContributorWindow.SetDisplayItems(existingAwards);

            while (true) {
                var createContributorDialogReturn = staffCreateContributorWindow.Display();
                switch (createContributorDialogReturn)
                {
                    case DialogReturn.Create:
                        var firstName = staffCreateContributorWindow.UXStaffContributorFirstName;
                        var lastName = staffCreateContributorWindow.UXStaffContributorLastName;
                        var twitterHandle = staffCreateContributorWindow.UXStaffContributorTwitterHandle;
                        var dateOfBirth = staffCreateContributorWindow.UXStaffContributorDateOfBirth;
                        var role = staffCreateContributorWindow.UXStaffRoleSelected;
                        var contributor = libraryController.AddContributor(firstName, lastName, twitterHandle, dateOfBirth, role, out success);
                        if (!success)
                            MessageBox.Show("Contributor could not be created");
                        return contributor;
                    case DialogReturn.Cancel:
                        return null;
                    default:
                        throw new Exception("An unregistered Dialog Return was created");
                }
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
            while (true)
            {
                try
                {
                    var success = false;
                    var dialogReturn = staffCustomerSearchWindow.Display();
                    switch (dialogReturn)
                    {
                        case DialogReturn.Search:
                            SearchByCustomerIDButtonPressedInStaffCustomerSearchWindow();
                            break;
                        case DialogReturn.AddCustomer:
                            AddCustomerThroughStaffCreateCusomterWindow();
                            break;
                        case DialogReturn.Cancel:
                            return;
                        case DialogReturn.Delete:
                            var customer = (Customer)staffCustomerSearchWindow.SelectedItem;
                            if (libraryController.DeleteCustomer(customer.Username))
                            {
                                staffCustomerSearchWindow.ClearDisplayItems();
                            }
                            else {
                                MessageBox.Show("Customer could not be deleted.");
                            }
                            return;
                        case DialogReturn.Select:
                            var customerToEdit = (Customer)staffCustomerSearchWindow.SelectedItem;
                            LaunchAndDisplayCustomerManager(customerToEdit);
                            break;
                        case DialogReturn.Undefined:
                            throw new Exception("Dialog did not return properly");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        public void LaunchAndDisplayCustomerManager(Customer customer) {
            staffCustomerManager.ClearDisplayItems();
            staffCustomerManager.AddDisplayItems(customer);

            while (true) {
                var dialogResult = staffCustomerManager.Display();
                switch (dialogResult) {
                    case DialogReturn.CreateFine:
                        var fineAmount = staffCustomerManager.NewFineAmount;
                        var success = false;
                        var fine = libraryController.AddFine(customer.Username, fineAmount, out success);
                        if (success)
                        {
                            MessageBox.Show("Fine Added");
                            staffCustomerManager.AddItem(fine);
                        }
                        else {
                            MessageBox.Show("Fine could not be added");
                        }
                        break;
                    case DialogReturn.RemoveFine:
                        var fineToRemove = (Fine)staffCustomerManager.SelectedItem;
                        var result = libraryController.PayIndividualFine(customer.Username, fineToRemove);
                        if (result)
                        {
                            MessageBox.Show("Fine removed");
                            staffCustomerManager.RemoveItem(fineToRemove);
                        }
                        else {
                            MessageBox.Show("Fine could not be removed");
                        }
                        break;
                    case DialogReturn.Cancel:
                        return;
                    default:
                        return;
                }
            }
        }
        public void AddCustomerThroughStaffCreateCusomterWindow() {

            staffCreateCustomerWindow.ClearDisplayItems();
            var addCustomerDialogReturn = staffCreateCustomerWindow.Display();

            switch (addCustomerDialogReturn) {
                case DialogReturn.Create:
                    var username = staffCreateCustomerWindow.UXStaffUsername;
                    var password = staffCreateCustomerWindow.UXStaffPassword;
                    var name = staffCreateCustomerWindow.UXStaffPassword;
                    var address = staffCreateCustomerWindow.UXStaffAddress;
                    var phoneNumber = staffCreateCustomerWindow.UXStaffPhoneNumber;
                    var success = libraryController.AddCustomer(username, password, name, address, phoneNumber);
                    if (!success)
                        MessageBox.Show("User could not be added");
                    else
                        MessageBox.Show("User created");
                    break;
                case DialogReturn.Cancel:
                    return;
                default:
                    break;
            }
        }

        public void SearchByCustomerIDButtonPressedInStaffCustomerSearchWindow() {

            var searchString = staffCustomerSearchWindow.UXStaffCustomerSearchIdString;
            staffCustomerSearchWindow.ClearDisplayItems();
            var success = false;
            var customerDisplayObjects = libraryController.GetCustomer(searchString, out success);
            if (!success)
            {
                MessageBox.Show("No Customers could be found");
            }
            staffItemSearchWindow.AddDisplayItems(customerDisplayObjects);
        }
    }
}
