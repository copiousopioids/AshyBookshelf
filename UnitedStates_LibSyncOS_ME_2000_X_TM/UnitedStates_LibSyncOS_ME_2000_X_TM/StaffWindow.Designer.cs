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
            this.staffSearchItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffSearchItemsButton.Location = new System.Drawing.Point(21, 35);
            this.staffSearchItemsButton.Name = "staffSearchItemsButton";
            this.staffSearchItemsButton.Size = new System.Drawing.Size(141, 43);
            this.staffSearchItemsButton.TabIndex = 0;
            this.staffSearchItemsButton.Text = "Search Items";
            this.staffSearchItemsButton.UseVisualStyleBackColor = true;
            this.staffSearchItemsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // staffSearchCustomerButton
            // 
            this.staffSearchCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffSearchCustomerButton.Location = new System.Drawing.Point(193, 35);
            this.staffSearchCustomerButton.Name = "staffSearchCustomerButton";
            this.staffSearchCustomerButton.Size = new System.Drawing.Size(141, 43);
            this.staffSearchCustomerButton.TabIndex = 1;
            this.staffSearchCustomerButton.Text = "Search Customer";
            this.staffSearchCustomerButton.UseVisualStyleBackColor = true;
            this.staffSearchCustomerButton.Click += new System.EventHandler(this.staffSearchCustomerButton_Click);
            // 
            // StaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 111);
            this.Controls.Add(this.staffSearchCustomerButton);
            this.Controls.Add(this.staffSearchItemsButton);
            this.Name = "StaffWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "United States LibSyncOS ME 2000 X (TM)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button staffSearchItemsButton;
        private System.Windows.Forms.Button staffSearchCustomerButton;
    }
}

