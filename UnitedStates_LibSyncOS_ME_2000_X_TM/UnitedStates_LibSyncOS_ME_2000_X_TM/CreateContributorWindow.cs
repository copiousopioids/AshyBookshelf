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
        public List<Award> UXStaffGetAllRewardsContributorReceived {
            get {
                var awardList = new List<Award>();
                foreach (var award in uxStaffAwardsReceivedGenericItemsListBox.Items) {
                    var awardCasted = (Award)award;
                    awardList.Add(awardCasted);
                }
                return awardList;
            }       
        }
        public void SetDisplayItems(List<Award> availableAwards, List<Role> roles) {
            uxStaffAvailableRewardsGenericItemsListBox.Items.AddRange(availableAwards.ToArray());
            uxStaffRoleComboBox.Items.AddRange(roles.ToArray());
        }

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

        public DateTime UXStaffContributorDateOfBirth
        {
           
            get
            {
                try
                {
                    var month = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(0, 2));
                    var day = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(3, 2));
                    var year = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(6, 4));

                    var dateCreation = new DateTime(year, month, day);
                    return dateCreation;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Please enter a date of birth in the format MM/DD/YYYY");
                    throw;
                }
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

        public void AddDisplayItems(params object[] displayObjects)
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
            uxStaffDOBTextBox.Text = "MM/DD/YYYY";  
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK:
                        var isAllInformationFilled = CheckDataValidity();
                        if (isAllInformationFilled)
                            return DialogReturn.Create;
                        else
                            MessageBox.Show("Please make sure all fields are filled out before continuing");
                        break;
                    case DialogResult.Yes:
                        AddRewardToContributorAwardsListBox();
                        break;
                    case DialogResult.Cancel: return DialogReturn.Cancel;
                    default: return DialogReturn.Undefined;
                }
            }
        }

        public bool CheckDataValidity()
        {
            if (string.IsNullOrEmpty(uxStaffDOBTextBox.Text)) {
                MessageBox.Show("Please enter a date of birth in the format MM/DD/YYYY");
                return false;
            }
            if (uxStaffDOBTextBox.Text.Length != 10) {
                MessageBox.Show("Please enter a date of birth in the format MM/DD/YYYY");
            }
            if (string.IsNullOrEmpty(uxStaffFirstNameTextBox.Text)) {
                return false;
            }

            if (string.IsNullOrEmpty(uxStaffLastNameTextBox.Text)) {
                return false;
            }

            if (string.IsNullOrEmpty(uxStaffTwitterHandleTextBox.Text)) {
                return false;
            }              
            if (uxStaffRoleComboBox.SelectedItem == null) {
                MessageBox.Show("Enter a role");

                return false;
            }
            

            // CHECK FOR Date in proper format
            try {
                var month = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(0, 2));
                var day = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(3, 2));
                var year = Convert.ToInt32(uxStaffDOBTextBox.Text.Substring(6, 4));

                var dateCreation = new DateTime(year, month, day);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Please enter a date of birth in the format MM/DD/YYYY");
                return false;
            }
                       
            return true;
        }

        private void AddRewardToContributorAwardsListBox() {

            var awardToAdd = uxStaffAvailableRewardsGenericItemsListBox.SelectedItem;
            if (awardToAdd == null)
            {
                MessageBox.Show("No award was selected");
                return;
            }              
            uxStaffAwardsReceivedGenericItemsListBox.Items.Add(awardToAdd);
            uxStaffAvailableRewardsGenericItemsListBox.Items.Remove(awardToAdd);
        }
    }
}
