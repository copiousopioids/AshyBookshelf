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
    public partial class Library : Form
    {
        LibraryController LibraryController;
        StaffWindow StaffWindow;
        Customer_Home CustomerWindow;

        public Library()
        {
            this.LibraryController = new LibraryController();
            this.StaffWindow = new StaffWindow(LibraryController);
            this.CustomerWindow = new Customer_Home(LibraryController);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffWindow.Show();
            CustomerWindow.Show();
            button1.Enabled = false;
        }
    }
}
