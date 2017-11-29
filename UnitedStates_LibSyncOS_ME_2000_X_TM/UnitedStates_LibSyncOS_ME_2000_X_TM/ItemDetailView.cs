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
    public partial class ItemDetailView : Form, ILibraryForm
    {
        public ItemDetailView()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                if (uxStaffGenericItemsList.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxStaffGenericItemsList.SelectedIndex;
            }

            set
            {
                uxStaffGenericItemsList.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffGenericItemsList.SelectedItem == null)
                {
                    throw new Exception("Select a line");
                }
                return uxStaffGenericItemsList.SelectedItem;
            }
        }

        public void AddDisplayItems(params object[] displayObjects)
        {
            uxStaffGenericItemsList.Items.AddRange(displayObjects);
        }

        public bool CheckDataValidity()
        {
            return true;
        }

        public void ClearDisplayItems()
        {
            uxStaffGenericItemsList.Items.Clear();
        }

        public DialogReturn Display()
        {
            switch (this.ShowDialog()) {
                case DialogResult.Cancel: return DialogReturn.Cancel;
                default: return DialogReturn.Cancel;
            }
        }
    }
}
