namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class ItemDetailView
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
            this.lable1 = new System.Windows.Forms.Label();
            this.uxStaffGenericItemsList = new System.Windows.Forms.ListBox();
            this.uxStaffCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(13, 13);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(85, 13);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Item Information:";
            // 
            // uxStaffGenericItemsList
            // 
            this.uxStaffGenericItemsList.FormattingEnabled = true;
            this.uxStaffGenericItemsList.Location = new System.Drawing.Point(16, 30);
            this.uxStaffGenericItemsList.Name = "uxStaffGenericItemsList";
            this.uxStaffGenericItemsList.Size = new System.Drawing.Size(748, 277);
            this.uxStaffGenericItemsList.TabIndex = 1;
            // 
            // uxStaffCloseButton
            // 
            this.uxStaffCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxStaffCloseButton.Location = new System.Drawing.Point(368, 314);
            this.uxStaffCloseButton.Name = "uxStaffCloseButton";
            this.uxStaffCloseButton.Size = new System.Drawing.Size(75, 23);
            this.uxStaffCloseButton.TabIndex = 2;
            this.uxStaffCloseButton.Text = "Close";
            this.uxStaffCloseButton.UseVisualStyleBackColor = true;
            // 
            // ItemDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 344);
            this.Controls.Add(this.uxStaffCloseButton);
            this.Controls.Add(this.uxStaffGenericItemsList);
            this.Controls.Add(this.lable1);
            this.Name = "ItemDetailView";
            this.Text = "ItemDetailView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.ListBox uxStaffGenericItemsList;
        private System.Windows.Forms.Button uxStaffCloseButton;
    }
}