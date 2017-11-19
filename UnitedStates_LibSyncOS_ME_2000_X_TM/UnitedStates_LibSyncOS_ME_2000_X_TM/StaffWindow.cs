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
                            var searchString = staffItemSearchWindow.staffSearchString;
                            if (!searchString.Equals(""))
                            {
                                
                            }
                            else {
                                MessageBox.Show("Please enter something into the search box before searching");
                            }
                            break;
                        case DialogReturn.AddBook:
                            break;
                        case DialogReturn.AddMovie:
                            break;
                        case DialogReturn.Cancel:
                            break;
                        case DialogReturn.Delete:
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

        private void staffSearchCustomerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
