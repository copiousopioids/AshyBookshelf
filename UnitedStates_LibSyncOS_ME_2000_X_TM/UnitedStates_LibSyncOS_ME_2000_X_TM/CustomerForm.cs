﻿using System;
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
    public partial class Customer_Home : Form
    {
        LibraryController LibraryController;

        public Customer_Home()
        {
            InitializeComponent();
        }

        public Customer_Home(LibraryController controller) : this() {
            this.LibraryController = controller;
        }
    }
}
