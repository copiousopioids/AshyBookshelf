namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class StaffItemSearchWindow
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
            this.staffSearchItemsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.staffSearchBooksCheckBox = new System.Windows.Forms.CheckBox();
            this.staffSearchMovieCheckBox = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.genericItemsList = new System.Windows.Forms.ListBox();
            this.staffSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // staffSearchItemsTextBox
            // 
            this.staffSearchItemsTextBox.Location = new System.Drawing.Point(126, 9);
            this.staffSearchItemsTextBox.Name = "staffSearchItemsTextBox";
            this.staffSearchItemsTextBox.Size = new System.Drawing.Size(151, 20);
            this.staffSearchItemsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Book";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button2.Location = new System.Drawing.Point(282, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete Item";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(388, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Return";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // staffSearchBooksCheckBox
            // 
            this.staffSearchBooksCheckBox.AutoSize = true;
            this.staffSearchBooksCheckBox.Location = new System.Drawing.Point(386, 12);
            this.staffSearchBooksCheckBox.Name = "staffSearchBooksCheckBox";
            this.staffSearchBooksCheckBox.Size = new System.Drawing.Size(93, 17);
            this.staffSearchBooksCheckBox.TabIndex = 6;
            this.staffSearchBooksCheckBox.Text = "Search Books";
            this.staffSearchBooksCheckBox.UseVisualStyleBackColor = true;
            // 
            // staffSearchMovieCheckBox
            // 
            this.staffSearchMovieCheckBox.AutoSize = true;
            this.staffSearchMovieCheckBox.Location = new System.Drawing.Point(283, 12);
            this.staffSearchMovieCheckBox.Name = "staffSearchMovieCheckBox";
            this.staffSearchMovieCheckBox.Size = new System.Drawing.Size(97, 17);
            this.staffSearchMovieCheckBox.TabIndex = 7;
            this.staffSearchMovieCheckBox.Text = "Search Movies";
            this.staffSearchMovieCheckBox.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button4.Location = new System.Drawing.Point(112, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Add Movie";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // genericItemsList
            // 
            this.genericItemsList.FormattingEnabled = true;
            this.genericItemsList.Location = new System.Drawing.Point(15, 38);
            this.genericItemsList.Name = "genericItemsList";
            this.genericItemsList.Size = new System.Drawing.Size(464, 173);
            this.genericItemsList.TabIndex = 9;
            // 
            // staffSearchButton
            // 
            this.staffSearchButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.staffSearchButton.Location = new System.Drawing.Point(15, 7);
            this.staffSearchButton.Name = "staffSearchButton";
            this.staffSearchButton.Size = new System.Drawing.Size(91, 23);
            this.staffSearchButton.TabIndex = 10;
            this.staffSearchButton.Text = "Press to Search";
            this.staffSearchButton.UseVisualStyleBackColor = true;
            // 
            // StaffItemSearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 261);
            this.Controls.Add(this.staffSearchButton);
            this.Controls.Add(this.genericItemsList);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.staffSearchMovieCheckBox);
            this.Controls.Add(this.staffSearchBooksCheckBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.staffSearchItemsTextBox);
            this.Name = "StaffItemSearchWindow";
            this.Text = "StaffItemSearchWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox staffSearchItemsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox staffSearchBooksCheckBox;
        private System.Windows.Forms.CheckBox staffSearchMovieCheckBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox genericItemsList;
        private System.Windows.Forms.Button staffSearchButton;
    }
}