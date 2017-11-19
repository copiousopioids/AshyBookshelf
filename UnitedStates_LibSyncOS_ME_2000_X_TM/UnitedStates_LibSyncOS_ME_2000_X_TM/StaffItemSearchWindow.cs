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
    public partial class StaffItemSearchWindow : Form, ILibraryForm
    {
        public StaffItemSearchWindow()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddDisplayItems()
        {
            throw new NotImplementedException();
        }

        public void DeleteDisplayItems()
        {
            throw new NotImplementedException();
        }

        public DialogReturn Diplay()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.OK: // ADD BOOK
                    return DialogReturn.AddBook;
                case DialogResult.Yes: // ADD MOVIE
                    return DialogReturn.AddMovie;
                case DialogResult.No: // DELETE GENERIC ITEM
                    return DialogReturn.Delete;
                case DialogResult.Cancel:
                    return DialogReturn.Cancel;
                case DialogResult.Ignore:
                    return DialogReturn.Search;
                default:
                    return DialogReturn.Undefined;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
