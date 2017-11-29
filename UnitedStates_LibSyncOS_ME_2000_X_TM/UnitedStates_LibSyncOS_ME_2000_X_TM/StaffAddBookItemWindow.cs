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
    public partial class StaffAddBookItemWindow : Form, ILibraryForm 
    {
        public void SetGenreItems(List<Genre> genres) {
            uxStaffGenreComboBox.Items.AddRange(genres.ToArray());
        }

        public string UXStaffBookPublisherText {
            get {
                return uxStaffBookPublisherTextBox.Text.ToString();
            }
        }

        public object UXStaffBookGenre {
            get {
                if (uxStaffGenreComboBox.SelectedItem == null)
                    return null;
                return uxStaffGenreComboBox.SelectedItem;
            }
        }

        public string UXStaffBookISBN {
            get {
                return uxStaffISBNTextBox.Text.ToString();
            }
        }

        public string UXStaffBookTitleText {
            get {
                return uxStaffBookTitleTextBox.Text.ToString();
            }
        }

        public string UXStaffBookNumberOfPagesText {
            get {
                return uxStaffBookNumberOfPagesTextBox.Text.ToString();
            }
        }

        public StaffAddBookItemWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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

        public void ClearDisplayItems()
        {
            uxStaffBookPublisherTextBox.Clear();
            uxStaffBookTitleTextBox.Clear();
            uxStaffGenericItemsListBox.Items.Clear();
            uxStaffBookNumberOfPagesTextBox.Clear();
            uxStaffISBNTextBox.Text = "";

        }

        public void AddItem(object displayItem) {
            uxStaffGenericItemsListBox.Items.Add(displayItem);
        }

        public List<Person> GetAllItems() {
            var contributors = new List<Person>();
            foreach (var item in uxStaffGenericItemsListBox.Items) {
                contributors.Add((Person)item);
            }
            return contributors;
        }

        public DialogReturn Display()
        {
            while (true) {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK: 
                        if (CheckDataValidity())
                        {
                            return DialogReturn.Create;
                        }
                        break;
                    case DialogResult.Yes:
                        return DialogReturn.AddContributor;
                    case DialogResult.Cancel: return DialogReturn.Cancel;
                    default: return DialogReturn.Undefined;
                }
            }          
        }

        public bool CheckDataValidity()
        {
            if (string.IsNullOrEmpty(uxStaffBookTitleTextBox.Text)) {
                MessageBox.Show("Enter a valid title");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffBookNumberOfPagesTextBox.Text)) {
                MessageBox.Show("Enter how many pages are in the book");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffBookPublisherTextBox.Text)) {
                MessageBox.Show("Enter the publisher for the text");
                return false;
            }
            if (uxStaffGenericItemsListBox.Items.Count <= 0) {
                MessageBox.Show("Enter a contributor for the text");
                return false;
            }
            if (uxStaffGenreComboBox.SelectedItem == null) {
                MessageBox.Show("Select an Item");
                return false;
            }
            if (uxStaffGenreComboBox.SelectedItem == null) {
                MessageBox.Show("Enter a genre and try again");
                return false;
            }
            return true;               
        }
    }
}
