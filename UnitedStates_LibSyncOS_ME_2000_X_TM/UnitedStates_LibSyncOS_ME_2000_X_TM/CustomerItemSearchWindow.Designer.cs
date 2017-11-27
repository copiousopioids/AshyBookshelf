﻿namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class CustomerItemSearchWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxCustomerSearchButton = new System.Windows.Forms.Button();
            this.uxCustomerGenericItemsList = new System.Windows.Forms.ListBox();
            this.uxCustomerSearchMovieCheckBox = new System.Windows.Forms.CheckBox();
            this.uxCustomerSearchBooksCheckBox = new System.Windows.Forms.CheckBox();
            this.uxCustomerCancelButton = new System.Windows.Forms.Button();
            this.uxCustomerSearchItemsTextBox = new System.Windows.Forms.TextBox();
            this.uxCustomerCheckoutItemButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxCustomerSearchButton
            // 
            this.uxCustomerSearchButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.uxCustomerSearchButton.Location = new System.Drawing.Point(403, 17);
            this.uxCustomerSearchButton.Name = "uxCustomerSearchButton";
            this.uxCustomerSearchButton.Size = new System.Drawing.Size(91, 23);
            this.uxCustomerSearchButton.TabIndex = 16;
            this.uxCustomerSearchButton.Text = "Search";
            this.uxCustomerSearchButton.UseVisualStyleBackColor = true;
            // 
            // uxCustomerGenericItemsList
            // 
            this.uxCustomerGenericItemsList.FormattingEnabled = true;
            this.uxCustomerGenericItemsList.Location = new System.Drawing.Point(22, 75);
            this.uxCustomerGenericItemsList.Name = "uxCustomerGenericItemsList";
            this.uxCustomerGenericItemsList.Size = new System.Drawing.Size(464, 173);
            this.uxCustomerGenericItemsList.TabIndex = 15;
            // 
            // uxCustomerSearchMovieCheckBox
            // 
            this.uxCustomerSearchMovieCheckBox.AutoSize = true;
            this.uxCustomerSearchMovieCheckBox.Location = new System.Drawing.Point(149, 43);
            this.uxCustomerSearchMovieCheckBox.Name = "uxCustomerSearchMovieCheckBox";
            this.uxCustomerSearchMovieCheckBox.Size = new System.Drawing.Size(97, 17);
            this.uxCustomerSearchMovieCheckBox.TabIndex = 14;
            this.uxCustomerSearchMovieCheckBox.Text = "Search Movies";
            this.uxCustomerSearchMovieCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxCustomerSearchBooksCheckBox
            // 
            this.uxCustomerSearchBooksCheckBox.AutoSize = true;
            this.uxCustomerSearchBooksCheckBox.Location = new System.Drawing.Point(252, 43);
            this.uxCustomerSearchBooksCheckBox.Name = "uxCustomerSearchBooksCheckBox";
            this.uxCustomerSearchBooksCheckBox.Size = new System.Drawing.Size(93, 17);
            this.uxCustomerSearchBooksCheckBox.TabIndex = 13;
            this.uxCustomerSearchBooksCheckBox.Text = "Search Books";
            this.uxCustomerSearchBooksCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxCustomerCancelButton
            // 
            this.uxCustomerCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCustomerCancelButton.Location = new System.Drawing.Point(395, 252);
            this.uxCustomerCancelButton.Name = "uxCustomerCancelButton";
            this.uxCustomerCancelButton.Size = new System.Drawing.Size(91, 23);
            this.uxCustomerCancelButton.TabIndex = 12;
            this.uxCustomerCancelButton.Text = "Return";
            this.uxCustomerCancelButton.UseVisualStyleBackColor = true;
            // 
            // uxCustomerSearchItemsTextBox
            // 
            this.uxCustomerSearchItemsTextBox.Location = new System.Drawing.Point(149, 17);
            this.uxCustomerSearchItemsTextBox.Name = "uxCustomerSearchItemsTextBox";
            this.uxCustomerSearchItemsTextBox.Size = new System.Drawing.Size(238, 20);
            this.uxCustomerSearchItemsTextBox.TabIndex = 11;
            // 
            // uxCustomerCheckoutItemButton
            // 
            this.uxCustomerCheckoutItemButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxCustomerCheckoutItemButton.Location = new System.Drawing.Point(22, 255);
            this.uxCustomerCheckoutItemButton.Name = "uxCustomerCheckoutItemButton";
            this.uxCustomerCheckoutItemButton.Size = new System.Drawing.Size(91, 23);
            this.uxCustomerCheckoutItemButton.TabIndex = 17;
            this.uxCustomerCheckoutItemButton.Text = "Checkout Item";
            this.uxCustomerCheckoutItemButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Title",
            "Genre",
            "Person"});
            this.comboBox1.Location = new System.Drawing.Point(22, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // CustomerItemSearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 287);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.uxCustomerCheckoutItemButton);
            this.Controls.Add(this.uxCustomerSearchButton);
            this.Controls.Add(this.uxCustomerGenericItemsList);
            this.Controls.Add(this.uxCustomerSearchMovieCheckBox);
            this.Controls.Add(this.uxCustomerSearchBooksCheckBox);
            this.Controls.Add(this.uxCustomerCancelButton);
            this.Controls.Add(this.uxCustomerSearchItemsTextBox);
            this.Name = "CustomerItemSearchWindow";
            this.Text = "CustomerItemSearchWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxCustomerSearchButton;
        private System.Windows.Forms.ListBox uxCustomerGenericItemsList;
        private System.Windows.Forms.CheckBox uxCustomerSearchMovieCheckBox;
        private System.Windows.Forms.CheckBox uxCustomerSearchBooksCheckBox;
        private System.Windows.Forms.Button uxCustomerCancelButton;
        private System.Windows.Forms.TextBox uxCustomerSearchItemsTextBox;
        private System.Windows.Forms.Button uxCustomerCheckoutItemButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}