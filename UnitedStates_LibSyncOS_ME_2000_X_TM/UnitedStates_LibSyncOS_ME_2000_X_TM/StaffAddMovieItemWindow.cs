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
    public partial class StaffAddMovieItemWindow : Form, ILibraryForm
    {
        public void SetGenreItems(List<Genre> genres)
        {
            uxStaffGenreComboBox.Items.AddRange(genres.ToArray());
        }

        public StaffAddMovieItemWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public string UXStaffMovieTitle {
            get {
                return uxStaffMovieTitleTextBox.Text.ToString();
            }
        }

        public string UXStaffMovieStudio
        {
            get
            {
                return uxStaffStudioNameTextBox.Text.ToString();
            }
        }

        public string UXStaffMovieBarcode
        {
            get
            {
                return uxStaffBarcodeTextBox.Text.ToString();
            }
        }

        public int UXStaffMovieDuration
        {
            get
            {
                try {
                    return Convert.ToInt32(uxStaffDurationTextBox.Text.ToString());
                } catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                    return 0;
                }
            }
        }

        public Genre UXStaffMovieGenre
        {
            get
            {
                if (uxStaffGenreComboBox.SelectedItem == null) throw new Exception("select a line");
                return (Genre)uxStaffGenreComboBox.SelectedItem;
            }
        }

        public string UXStaffMovieDescription
        {
            get
            {
                return uxStaffDescriptionTextBox.Text.ToString();
            }
        }
        public List<Person> GetAllItems()
        {
            var contributors = new List<Person>();
            foreach (var item in uxStaffGenericItemsListBox.Items)
            {
                contributors.Add((Person)item);
            }
            return contributors;
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

        public void AddItem(object displayObject) {
            uxStaffGenericItemsListBox.Items.Add(displayObject);
        }

        public bool CheckDataValidity()
        {
            if (string.IsNullOrEmpty(uxStaffMovieTitleTextBox.Text)) {
                MessageBox.Show("Please enter a title and try again");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffDescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a description and try again");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffDurationTextBox.Text))
            {
                MessageBox.Show("Please enter a duration and try again");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffStudioNameTextBox.Text))
            {
                MessageBox.Show("Please enter a studio and try again");
                return false;
            }
            if (uxStaffGenreComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please enter a genre and try again");
                return false;
            }
            if (uxStaffGenericItemsListBox.Items.Count <= 0)
            {
                MessageBox.Show("Please enter at least one contributor");
                return false;
            }
            if (string.IsNullOrEmpty(uxStaffBarcodeTextBox.Text))
                return false;
            return true;
        }

        public void ClearDisplayItems()
        {
            uxStaffGenericItemsListBox.Items.Clear();
        }

        public DialogReturn Display()
        {
            while (true)
            {
                switch (this.ShowDialog())
                {
                    case DialogResult.OK:
                        if (CheckDataValidity())
                            return DialogReturn.AddMovie;
                        else
                            break;
                    case DialogResult.Yes:
                        return DialogReturn.AddContributor;
                    case DialogResult.Cancel: return DialogReturn.Cancel;
                    default: return DialogReturn.Undefined;
                }
            }
        }
    }
}
