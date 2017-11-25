namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class StaffAddContributorWindow
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
            this.uxStaffAddContributorButton = new System.Windows.Forms.Button();
            this.uxStaffCancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uxStaffCreateContributorButton = new System.Windows.Forms.Button();
            this.uxStaffGenericItemsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxStaffAddContributorButton
            // 
            this.uxStaffAddContributorButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxStaffAddContributorButton.Location = new System.Drawing.Point(18, 328);
            this.uxStaffAddContributorButton.Name = "uxStaffAddContributorButton";
            this.uxStaffAddContributorButton.Size = new System.Drawing.Size(121, 23);
            this.uxStaffAddContributorButton.TabIndex = 3;
            this.uxStaffAddContributorButton.Text = "Add Contributor";
            this.uxStaffAddContributorButton.UseVisualStyleBackColor = true;
            // 
            // uxStaffCancelButton
            // 
            this.uxStaffCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxStaffCancelButton.Location = new System.Drawing.Point(333, 328);
            this.uxStaffCancelButton.Name = "uxStaffCancelButton";
            this.uxStaffCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxStaffCancelButton.TabIndex = 4;
            this.uxStaffCancelButton.Text = "Cancel";
            this.uxStaffCancelButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Existing Contributors:";
            // 
            // uxStaffCreateContributorButton
            // 
            this.uxStaffCreateContributorButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.uxStaffCreateContributorButton.Location = new System.Drawing.Point(145, 328);
            this.uxStaffCreateContributorButton.Name = "uxStaffCreateContributorButton";
            this.uxStaffCreateContributorButton.Size = new System.Drawing.Size(148, 23);
            this.uxStaffCreateContributorButton.TabIndex = 16;
            this.uxStaffCreateContributorButton.Text = "Create New Contributor";
            this.uxStaffCreateContributorButton.UseVisualStyleBackColor = true;
            // 
            // uxStaffGenericItemsListBox
            // 
            this.uxStaffGenericItemsListBox.FormattingEnabled = true;
            this.uxStaffGenericItemsListBox.Location = new System.Drawing.Point(18, 25);
            this.uxStaffGenericItemsListBox.Name = "uxStaffGenericItemsListBox";
            this.uxStaffGenericItemsListBox.Size = new System.Drawing.Size(390, 290);
            this.uxStaffGenericItemsListBox.TabIndex = 17;
            // 
            // StaffAddContributorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 360);
            this.Controls.Add(this.uxStaffGenericItemsListBox);
            this.Controls.Add(this.uxStaffCreateContributorButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxStaffCancelButton);
            this.Controls.Add(this.uxStaffAddContributorButton);
            this.Name = "StaffAddContributorWindow";
            this.Text = "StaffAddContributorWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button uxStaffAddContributorButton;
        private System.Windows.Forms.Button uxStaffCancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button uxStaffCreateContributorButton;
        private System.Windows.Forms.ListBox uxStaffGenericItemsListBox;
    }
}