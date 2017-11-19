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
    public partial class StaffAddBookItemWindow : Form, ILibraryForm 
    {
        public StaffAddBookItemWindow()
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
            switch (this.ShowDialog()) {
                default:
                    return DialogReturn.Undefined;
            }
        }
    }
}
