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
        private ItemDetailView itemDetailView;
        private string errorMessage = "";

        public StaffWindow()
        {
                        
            InitializeComponent();
            Screen s = Screen.FromControl(this);
            Point center = new Point(s.Bounds.Width/2,
                                     s.Bounds.Height/2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(center.X + (this.Width/2),
                                        center.Y - this.Height);
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
            this.staffCustomerManager = new StaffCustomerManager(controller);
            this.itemDetailView = new ItemDetailView();
            
            this.libraryController = controller;
        }

        private void button1_Click(object sender, EventArgs e) // SEARCH ITEMS BUTTON CLICKED IN STAFF WINDOW
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
                            var movie = AddAndGetMovieThroughAddMovieWindow(out success);
                            if (success)
                                staffItemSearchWindow.AddItem(movie);
                            break;
                        case DialogReturn.Cancel:
                            return;
                        case DialogReturn.Delete:
                            DeleteItemFromLibrary();
                            break;
                        case DialogReturn.Select:
                            ShowItemDetailViewWindow((Item)staffItemSearchWindow.SelectedItem);
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

        public void ShowItemDetailViewWindow(Item selectedItem) {
            List<string> itemDisplayContents = null;
            if (selectedItem is Movie) {
                itemDisplayContents = libraryController.GetItemDetails(selectedItem, ItemType.Movie);
            } else if (selectedItem is Book) {
                itemDisplayContents = libraryController.GetItemDetails(selectedItem, ItemType.Book);
            } else {
                MessageBox.Show("Error with selected item, sorry");
            }

            if (itemDisplayContents == null)
                return;
            itemDetailView.ClearDisplayItems();
            itemDetailView.AddDisplayItems(itemDisplayContents.ToArray());
            var dialogResult = itemDetailView.Display();
            // do more things if needed



        }
        public void DeleteItemFromLibrary()
        {
            var selectedItem = staffItemSearchWindow.SelectedItem;
            if (selectedItem is Book)
            {

                var bookItem = (Book)selectedItem;
                if (libraryController.DeleteItem(ItemTypes.Movie, bookItem.ID, out errorMessage))
                {
                    MessageBox.Show("Book Deleted");
                    staffItemSearchWindow.ClearDisplayItems();
                }
                else
                {
                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                    MessageBox.Show("Could not delete item from the library catalog " + errorMessage);
                }
            }
            else if (selectedItem is Movie)
            {

                var movieItem = (Movie)selectedItem;
                if (libraryController.DeleteItem(ItemTypes.Movie, movieItem.ID, out errorMessage))
                {
                    MessageBox.Show("Movie Deleted");
                    staffItemSearchWindow.ClearDisplayItems();
                }
                else
                {
                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                    MessageBox.Show("Could not delete item from the library catalog " + errorMessage);
                }
            }
        }

        public Movie AddAndGetMovieThroughAddMovieWindow(out bool success) {
            staffAddMovieItemWindow.ClearDisplayItems();

            success = false;
            var genres = libraryController.GetAllGenres(out success, out errorMessage);
            if (!success)
            {
                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                MessageBox.Show("Genres could not be retrieved " + errorMessage);
                success = false;
                return null;
            }

            staffAddMovieItemWindow.SetGenreItems(genres);
            try
            {
                while (true)
                {
                    var addMovieWindowDialogReturn = staffAddMovieItemWindow.Display();
                    switch (addMovieWindowDialogReturn)
                    {
                        case DialogReturn.AddContributor:
                            var contributor = PickContributorForItem(ItemType.Movie);
                            if (contributor != null)
                                staffAddMovieItemWindow.AddItem(contributor);
                            break;
                        case DialogReturn.AddMovie:
                            success = false;
                            var title = staffAddMovieItemWindow.UXStaffMovieTitle;
                            var duration = staffAddMovieItemWindow.UXStaffMovieDuration;
                            var description = staffAddMovieItemWindow.UXStaffMovieDescription;
                            var studio = staffAddMovieItemWindow.UXStaffMovieStudio;
                            var genre = staffAddMovieItemWindow.UXStaffMovieGenre;
                            var contributors = staffAddMovieItemWindow.GetAllItems();
                            var barcode = staffAddMovieItemWindow.UXStaffMovieBarcode;
                            var movie = libraryController.AddMovie(title, description, genre, duration, barcode, contributors, out success, out errorMessage);
                            if (!success) {
                                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                MessageBox.Show("Movie could not be added " + errorMessage);
                                return null;
                            }

                            MessageBox.Show("Movie Added");
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
            success = false;
            var genres = libraryController.GetAllGenres(out success, out errorMessage);
            if (!success) {
                MessageBox.Show("Genres could not be retrieved " + errorMessage);
                success = false;
                return null;
            }

            staffAddBookItemWindow.SetGenreItems(genres);

            while (true) {
                var addBookWindowDialogReturn = staffAddBookItemWindow.Display();
                switch (addBookWindowDialogReturn)
                {
                    case DialogReturn.AddContributor:
                        var contributor = PickContributorForItem(ItemType.Book);
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
                        var book = libraryController.AddBook(title, genre, isbn, publisher, numberOfPages, contributors, out success, out errorMessage);
                        if (success == false)
                        {
                            // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                            MessageBox.Show("The book could not be added. We're sorry " + errorMessage);
                        }

                        success = true;
                        MessageBox.Show("Book added");
                        return book;
                    case DialogReturn.Cancel:
                        success = false;
                        return null;
                    default:
                        break;
                }
            }           
        }

        public Person PickContributorForItem(ItemType type) {
            try
            {
                var success = false;
                var existingContributors = libraryController.GetAllContributors(out success, out errorMessage);
                if (!success) {
                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                    MessageBox.Show("Contributors could not be retrieved " + errorMessage);
                    return null;
                }

                List<Role> rawRoles = libraryController.GetAllRoles(out success, out errorMessage);
                List<Role> roles =new List<Role>();
                
                if (type.Equals(ItemType.Book))
                {
                    foreach (Role iRole in rawRoles)
                    {
                        if(iRole.Type.Equals(Roles.Author))
                        {
                            roles.Add(iRole);
                        }
                    }
                }
                else
                {
                    foreach (Role iRole in rawRoles)
                    {
                        if (iRole.Type.Equals(Roles.Director) || iRole.Type.Equals(Roles.Actor))
                        {
                            roles.Add(iRole);
                        }
                    }
                }

                staffAddContributorWindow.ClearDisplayItems();
                staffAddContributorWindow.SetDisplayItems(roles, existingContributors.ToArray());

                var addContributorDialogReturn = staffAddContributorWindow.Display();
                switch (addContributorDialogReturn)
                {
                    case DialogReturn.AddContributor:
                        Person contributor =(Person)staffAddContributorWindow.SelectedItem;
                        Role role = staffAddContributorWindow.UXStaffRoleSelected;
                        
                        if (contributor is Person)
                        {
                            contributor.Role = role;
                            return contributor;
                        }                            
                        else
                        {
                            MessageBox.Show("A contributor was not selected");
                            return null;
                        }
                        //break;
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
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Person LaunchCreateContributorWindowAndCreateContributor() {

            staffCreateContributorWindow.ClearDisplayItems();

            var success = false;
            var existingAwards = libraryController.GetAllAwards(out success, out errorMessage);
            if (!success) {
                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                MessageBox.Show("Awards could not be retrieved " + errorMessage);
                return null;
            }

            var roles = libraryController.GetAllRoles(out success, out errorMessage);
            if (!success) {
                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                MessageBox.Show("Roles could not be retrieved " + errorMessage);
                return null;
            }

            staffCreateContributorWindow.AddDisplayItems(existingAwards.ToArray());

            while (true) {
                var createContributorDialogReturn = staffCreateContributorWindow.Display();
                switch (createContributorDialogReturn)
                {
                    case DialogReturn.Create:
                        var firstName = staffCreateContributorWindow.UXStaffContributorFirstName;
                        var lastName = staffCreateContributorWindow.UXStaffContributorLastName;
                        var twitterHandle = staffCreateContributorWindow.UXStaffContributorTwitterHandle;
                        var dateOfBirth = staffCreateContributorWindow.UXStaffContributorDateOfBirth;
                        
                        var awards = staffCreateContributorWindow.UXStaffGetAllRewardsContributorReceived;
                        var contributor = libraryController.AddContributor(firstName, lastName, twitterHandle, dateOfBirth, awards, out success, out errorMessage);
                        if (!success)
                        {
                            // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                            MessageBox.Show("Contributor could not be created " + errorMessage);
                        }
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

            if (!searchString.Equals(""))
            {
                var isBookCheckBoxChecked = staffItemSearchWindow.staffIsSearchBookCheckBoxSelected;
                var isMovieCheckBoxChecked = staffItemSearchWindow.staffIsSearchMovieCheckBoxSelected;
                ItemSearchOptions searchAttribute = staffItemSearchWindow.staffSearchCriteria;
                var bookAndMovieDisplayObjects = new List<object>();

                if (isBookCheckBoxChecked && isMovieCheckBoxChecked) {
                    if (searchAttribute == ItemSearchOptions.Person)
                    {
                        bookAndMovieDisplayObjects = libraryController.searchItems(searchString, ItemSearchOptions.PersonAndBookAndMovie, out errorMessage);
                    }
                    else if(searchAttribute == ItemSearchOptions.Genre)
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
                staffItemSearchWindow.ClearDisplayItems();
                if (bookAndMovieDisplayObjects == null || bookAndMovieDisplayObjects.Count <= 0) {
                    // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                    MessageBox.Show("The list of items could not be retrieved or was not found " + errorMessage);
                }
                staffItemSearchWindow.AddDisplayItems(bookAndMovieDisplayObjects.ToArray());
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
                    //var success = false;
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
                            Customer customer = (Customer)staffCustomerSearchWindow.SelectedItem;
                            if (libraryController.DeleteCustomer(customer.Username, out errorMessage))
                            {
                                MessageBox.Show("Customer Deleted");
                                staffCustomerSearchWindow.ClearDisplayItems();
                            }
                            else {
                                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                                MessageBox.Show("Customer could not be deleted. " + errorMessage);
                            }
                            return;
                        case DialogReturn.Select:
                            var customerToEdit = (Customer)staffCustomerSearchWindow.SelectedItem;
                            LaunchAndDisplayCustomerManager(customerToEdit);
                            break;
                        case DialogReturn.ListCustomers:
                            // List and display all the customers.
                            ListCustomersButtonPressedInStaffCustomerSearchWindow();
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
            staffCustomerManager.SetDisplay(customer);

            while (true) {
                var dialogResult = staffCustomerManager.Display();
                switch (dialogResult) {
                    case DialogReturn.CreateFine10:
                        var success = false;
                        var fine = libraryController.AddFine(customer.Username, 10, out success, out errorMessage);
                        if (success)
                        {
                            MessageBox.Show("Fine Added");
                            staffCustomerManager.AddItem(fine);
                        }
                        else {
                            // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                            MessageBox.Show("Fine could not be added " + errorMessage);
                        }
                        break;
                    case DialogReturn.CreateFine5:
                        var success2 = false;
                        var fine2 = libraryController.AddFine(customer.Username, 5, out success2, out errorMessage);
                        if (success2)
                        {
                            MessageBox.Show("Fine Added");
                            staffCustomerManager.AddItem(fine2);
                        }
                        else
                        {
                            // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                            MessageBox.Show("Fine could not be added " + errorMessage);
                        }
                        break;
                    case DialogReturn.RemoveFine:
                        var fineToRemove = (Fine)staffCustomerManager.SelectedItem;
                        var result = libraryController.PayIndividualFine(customer.Username, fineToRemove, out errorMessage);
                        if (result)
                        {
                            MessageBox.Show("Fine removed");
                            staffCustomerManager.RemoveItem(fineToRemove);
                        }
                        else {
                            // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                            MessageBox.Show("Fine could not be removed " + errorMessage);
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
                    var name = staffCreateCustomerWindow.UXStaffName;
                    var address = staffCreateCustomerWindow.UXStaffAddress;
                    var phoneNumber = staffCreateCustomerWindow.UXStaffPhoneNumber;
                    var success = libraryController.AddCustomer(username, password, name, address, phoneNumber, out errorMessage);
                    if (!success) {
                        // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                        MessageBox.Show("User could not be added " + errorMessage);
                    }                  
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
            var customerDisplayObjects = (List<Customer>)libraryController.GetCustomer(searchString, out success, out errorMessage);
            if (!success)
            {
                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                MessageBox.Show("No Customers could be found " + errorMessage);
            }
            staffCustomerSearchWindow.AddDisplayItems(customerDisplayObjects.ToArray());
        }

        public void ListCustomersButtonPressedInStaffCustomerSearchWindow()
        {
            staffCustomerSearchWindow.ClearDisplayItems();
            var success = false;
            var customerDisplayObjects = (List<Customer>)libraryController.GetAllCustomers(out success, out errorMessage);
            if (!success)
            {
                // TODO: REMOVE CUSTOM MESSAGE ALL-TOGETHER WHEN ERROR MESSAGE IS IMPLEMENTED
                MessageBox.Show("No Customers could be found " + errorMessage);
            }
            staffCustomerSearchWindow.AddDisplayItems(customerDisplayObjects.ToArray());
        }
    }
}
