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
    public partial class StaffAddContributorWindow : Form, ILibraryForm
    {
        public Role UXStaffRoleSelected
        {
            get
            {
                if (uxStaffRoleComboBox.SelectedItem == null)
                {
                    throw new Exception("Please selected a role for the contributor");
                }
                return (Role)uxStaffRoleComboBox.SelectedItem;
            }
        }

        public StaffAddContributorWindow()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                if (uxStaffGenericItemsListBox.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxStaffGenericItemsListBox.SelectedIndex;
            }

            set
            {
                uxStaffGenericItemsListBox.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffGenericItemsListBox.SelectedItem == null) throw new Exception("Select a line");
                return uxStaffGenericItemsListBox.SelectedItem;
            }
        }

        public void AddDisplayItems(params object [] displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
        }

        public void SetDisplayItems(List<Role> roles, params object[] displayObjects)
        {
            uxStaffGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
            uxStaffRoleComboBox.Items.AddRange(roles.ToArray());
        }

        public void ClearDisplayItems()
        {
            uxStaffRoleComboBox.Items.Clear();
            uxStaffGenericItemsListBox.Items.Clear();
        }

        public void AddItem(object displayItem) {
            uxStaffGenericItemsListBox.Items.Add(displayItem);
        }

        public bool CheckDataValidity() {
            if (uxStaffGenericItemsListBox.SelectedItem == null) {
                MessageBox.Show("Please selet a contributor to add");
                return false;
            }             
            return true;
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK:
                        if (CheckDataValidity())
                            return DialogReturn.AddContributor;
                        break;
                    case DialogResult.Yes:
                        return DialogReturn.Create;
                    case DialogResult.Cancel: return DialogReturn.Cancel;
                    default: return DialogReturn.Undefined;
                }
            }          
        }
    }
}
