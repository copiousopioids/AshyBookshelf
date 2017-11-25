namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class Customer_Home
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
            this.customerFindItemButton = new System.Windows.Forms.Button();
            this.customerAccountInformationButton = new System.Windows.Forms.Button();
            this.customerExitButton = new System.Windows.Forms.Button();
            this.customerLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerFindItemButton
            // 
            this.customerFindItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerFindItemButton.Location = new System.Drawing.Point(40, 45);
            this.customerFindItemButton.Name = "customerFindItemButton";
            this.customerFindItemButton.Size = new System.Drawing.Size(188, 83);
            this.customerFindItemButton.TabIndex = 0;
            this.customerFindItemButton.Text = "Find Item";
            this.customerFindItemButton.UseVisualStyleBackColor = true;
            this.customerFindItemButton.Click += new System.EventHandler(this.customerFindItemButton_Click);
            // 
            // customerAccountInformationButton
            // 
            this.customerAccountInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAccountInformationButton.Location = new System.Drawing.Point(282, 45);
            this.customerAccountInformationButton.Name = "customerAccountInformationButton";
            this.customerAccountInformationButton.Size = new System.Drawing.Size(188, 83);
            this.customerAccountInformationButton.TabIndex = 1;
            this.customerAccountInformationButton.Text = "Account Information";
            this.customerAccountInformationButton.UseVisualStyleBackColor = true;
            this.customerAccountInformationButton.Click += new System.EventHandler(this.customerAccountInformationButton_Click);
            // 
            // customerExitButton
            // 
            this.customerExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerExitButton.Location = new System.Drawing.Point(315, 151);
            this.customerExitButton.Name = "customerExitButton";
            this.customerExitButton.Size = new System.Drawing.Size(130, 47);
            this.customerExitButton.TabIndex = 2;
            this.customerExitButton.Text = "Logout";
            this.customerExitButton.UseVisualStyleBackColor = true;
            this.customerExitButton.Click += new System.EventHandler(this.customerExitButton_Click);
            // 
            // customerLoginButton
            // 
            this.customerLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLoginButton.Location = new System.Drawing.Point(61, 151);
            this.customerLoginButton.Name = "customerLoginButton";
            this.customerLoginButton.Size = new System.Drawing.Size(130, 47);
            this.customerLoginButton.TabIndex = 3;
            this.customerLoginButton.Text = "Login";
            this.customerLoginButton.UseVisualStyleBackColor = true;
            this.customerLoginButton.Click += new System.EventHandler(this.customerLoginButton_Click);
            // 
            // Customer_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 221);
            this.Controls.Add(this.customerLoginButton);
            this.Controls.Add(this.customerExitButton);
            this.Controls.Add(this.customerAccountInformationButton);
            this.Controls.Add(this.customerFindItemButton);
            this.Name = "Customer_Home";
            this.Text = "Customer Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button customerFindItemButton;
        private System.Windows.Forms.Button customerAccountInformationButton;
        private System.Windows.Forms.Button customerExitButton;
        private System.Windows.Forms.Button customerLoginButton;
    }
}