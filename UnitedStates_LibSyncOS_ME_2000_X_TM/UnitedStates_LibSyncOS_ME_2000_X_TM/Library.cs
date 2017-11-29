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

        private void Library_Load(object sender, EventArgs e)
        {
            Screen s = Screen.FromControl(this);
            int x = s.Bounds.Width;
            int y = s.Bounds.Height;
            this.Location = new System.Drawing.Point((x / 2) - (this.Width / 2), (y / 2) - (this.Height / 2));
        }
    }
}
