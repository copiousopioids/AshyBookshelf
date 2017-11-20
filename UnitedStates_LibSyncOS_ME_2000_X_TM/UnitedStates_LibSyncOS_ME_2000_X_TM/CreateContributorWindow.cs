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
    public partial class CreateContributorWindow : Form, ILibraryForm
    {
        public string UXStaffContributorTwitterHandle
        {
            get
            {
                return uxStaffTwitterHandleTextBox.Text.ToString();
            }
        }

        public string UXStaffContributorFirstName
        {
            get
            {
                return uxStaffFirstNameTextBox.Text.ToString();
            }
        }

        public string UXStaffContributorLastName
        {
            get
            {
                return uxStaffLastNameTextBox.Text.ToString();
            }
        }

        public Role UXStaffRoleSelected
        {
            get
            {
                if (uxStaffRoleComboBox.SelectedItem == null)
                    throw new Exception("Please selected a role for the contributor");
                return (Role)uxStaffRoleComboBox.SelectedItem;
            }
        }

        public string UXStaffContributorDateOfBirth
        {
            get
            {
                return uxStaffDOBTextBox.Text.ToString();
            }
        }

        public Role UXStaffAvailableAwardsListBoxSelectedItem
        {
            get
            {
                if (uxStaffAvailableRewardsGenericItemsListBox.SelectedItem == null) throw new Exception("Select a Line");
                return (Role) uxStaffAvailableRewardsGenericItemsListBox.SelectedItem;
            }
        }

        public int UXStaffAvailableAwardsListBoxSelectedIndex
        {
            get
            {
                if (uxStaffAvailableRewardsGenericItemsListBox.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxStaffAvailableRewardsGenericItemsListBox.SelectedIndex;
            }

            set
            {
                uxStaffAvailableRewardsGenericItemsListBox.SelectedIndex = value;
            }
        }

        public CreateContributorWindow()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                if (uxStaffAwardsReceivedGenericItemsListBox.SelectedIndex == -1) throw new Exception("Select a Line");
                return uxStaffAwardsReceivedGenericItemsListBox.SelectedIndex;
            }

            set
            {
                uxStaffAwardsReceivedGenericItemsListBox.SelectedIndex = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                if (uxStaffAwardsReceivedGenericItemsListBox.SelectedItem == null) throw new Exception("Select a line");
                return uxStaffAwardsReceivedGenericItemsListBox.SelectedItem;
            }
        }

        public void AddDisplayItems(List<object> displayObjects)
        {
            uxStaffAwardsReceivedGenericItemsListBox.Items.AddRange(displayObjects.ToArray());
        }

        public void ClearDisplayItems()
        {
            uxStaffAwardsReceivedGenericItemsListBox.Items.Clear();
            uxStaffAvailableRewardsGenericItemsListBox.Items.Clear();
            uxStaffDOBTextBox.Clear();
            uxStaffFirstNameTextBox.Clear();
            uxStaffLastNameTextBox.Clear();
            uxStaffRoleComboBox.Items.Clear();
            uxStaffTwitterHandleTextBox.Clear();       
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK: return DialogReturn.Create;
                    case DialogResult.Yes:
                        AddRewardToContributorAwardsListBox();
                        break;
                    case DialogResult.Cancel: return DialogReturn.Cancel;
                    default: return DialogReturn.Undefined;
                }
            }
        }

        private void AddRewardToContributorAwardsListBox() {

            var awardToAdd = uxStaffAvailableRewardsGenericItemsListBox.SelectedItem;
            uxStaffAwardsReceivedGenericItemsListBox.Items.Add(awardToAdd);
            uxStaffAvailableRewardsGenericItemsListBox.Items.Remove(awardToAdd);
        }
    }
}
