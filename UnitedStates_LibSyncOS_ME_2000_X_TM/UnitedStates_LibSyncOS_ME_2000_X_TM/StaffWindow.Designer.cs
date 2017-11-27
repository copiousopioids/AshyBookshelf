namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class StaffWindow
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
            this.staffSearchItemsButton = new System.Windows.Forms.Button();
            this.staffSearchCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // staffSearchItemsButton
            // 
            this.staffSearchItemsButton.Location = new System.Drawing.Point(12, 12);
            this.staffSearchItemsButton.Name = "staffSearchItemsButton";
            this.staffSearchItemsButton.Size = new System.Drawing.Size(123, 43);
            this.staffSearchItemsButton.TabIndex = 0;
            this.staffSearchItemsButton.Text = "Search Items";
            this.staffSearchItemsButton.UseVisualStyleBackColor = true;
            this.staffSearchItemsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // staffSearchCustomerButton
            // 
            this.staffSearchCustomerButton.Location = new System.Drawing.Point(170, 12);
            this.staffSearchCustomerButton.Name = "staffSearchCustomerButton";
            this.staffSearchCustomerButton.Size = new System.Drawing.Size(123, 43);
            this.staffSearchCustomerButton.TabIndex = 1;
            this.staffSearchCustomerButton.Text = "Search Customer";
            this.staffSearchCustomerButton.UseVisualStyleBackColor = true;
            this.staffSearchCustomerButton.Click += new System.EventHandler(this.staffSearchCustomerButton_Click);
            // 
            // StaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 77);
            this.Controls.Add(this.staffSearchCustomerButton);
            this.Controls.Add(this.staffSearchItemsButton);
            this.Name = "StaffWindow";
            this.Text = "United States LibSyncOS ME 200 X (TM)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button staffSearchItemsButton;
        private System.Windows.Forms.Button staffSearchCustomerButton;
    }
}

