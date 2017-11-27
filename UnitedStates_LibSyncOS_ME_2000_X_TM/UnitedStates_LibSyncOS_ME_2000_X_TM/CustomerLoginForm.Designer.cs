namespace UnitedStates_LibSyncOS_ME_2000_X_TM
{
    partial class CustomerLoginForm
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
            this.uxCustomerUsernameTextBox = new System.Windows.Forms.TextBox();
            this.uxCustomerPasswordTextBox = new System.Windows.Forms.TextBox();
            this.Customer_Username_Label = new System.Windows.Forms.Label();
            this.Customer_Password_Label = new System.Windows.Forms.Label();
            this.uxCustomerSubmitButton = new System.Windows.Forms.Button();
            this.uxCustomerCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxCustomerUsernameTextBox
            // 
            this.uxCustomerUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCustomerUsernameTextBox.Location = new System.Drawing.Point(142, 56);
            this.uxCustomerUsernameTextBox.MaxLength = 16;
            this.uxCustomerUsernameTextBox.Name = "uxCustomerUsernameTextBox";
            this.uxCustomerUsernameTextBox.Size = new System.Drawing.Size(189, 29);
            this.uxCustomerUsernameTextBox.TabIndex = 0;
            // 
            // uxCustomerPasswordTextBox
            // 
            this.uxCustomerPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.uxCustomerPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCustomerPasswordTextBox.Location = new System.Drawing.Point(142, 124);
            this.uxCustomerPasswordTextBox.MaxLength = 16;
            this.uxCustomerPasswordTextBox.Name = "uxCustomerPasswordTextBox";
            this.uxCustomerPasswordTextBox.PasswordChar = '*';
            this.uxCustomerPasswordTextBox.Size = new System.Drawing.Size(189, 29);
            this.uxCustomerPasswordTextBox.TabIndex = 1;
            // 
            // Customer_Username_Label
            // 
            this.Customer_Username_Label.AutoSize = true;
            this.Customer_Username_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Username_Label.Location = new System.Drawing.Point(32, 59);
            this.Customer_Username_Label.Name = "Customer_Username_Label";
            this.Customer_Username_Label.Size = new System.Drawing.Size(102, 24);
            this.Customer_Username_Label.TabIndex = 2;
            this.Customer_Username_Label.Text = "Username:";
            // 
            // Customer_Password_Label
            // 
            this.Customer_Password_Label.AutoSize = true;
            this.Customer_Password_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Password_Label.Location = new System.Drawing.Point(37, 127);
            this.Customer_Password_Label.Name = "Customer_Password_Label";
            this.Customer_Password_Label.Size = new System.Drawing.Size(97, 24);
            this.Customer_Password_Label.TabIndex = 3;
            this.Customer_Password_Label.Text = "Password:";
            // 
            // uxCustomerSubmitButton
            // 
            this.uxCustomerSubmitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxCustomerSubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCustomerSubmitButton.Location = new System.Drawing.Point(89, 199);
            this.uxCustomerSubmitButton.Name = "uxCustomerSubmitButton";
            this.uxCustomerSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.uxCustomerSubmitButton.TabIndex = 4;
            this.uxCustomerSubmitButton.Text = "Submit";
            this.uxCustomerSubmitButton.UseVisualStyleBackColor = true;
            // 
            // uxCustomerCancelButton
            // 
            this.uxCustomerCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCustomerCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCustomerCancelButton.Location = new System.Drawing.Point(227, 199);
            this.uxCustomerCancelButton.Name = "uxCustomerCancelButton";
            this.uxCustomerCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxCustomerCancelButton.TabIndex = 5;
            this.uxCustomerCancelButton.Text = "Cancel";
            this.uxCustomerCancelButton.UseVisualStyleBackColor = true;
            // 
            // CustomerLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 260);
            this.Controls.Add(this.uxCustomerCancelButton);
            this.Controls.Add(this.uxCustomerSubmitButton);
            this.Controls.Add(this.Customer_Password_Label);
            this.Controls.Add(this.Customer_Username_Label);
            this.Controls.Add(this.uxCustomerPasswordTextBox);
            this.Controls.Add(this.uxCustomerUsernameTextBox);
            this.Name = "CustomerLoginForm";
            this.Text = "Customer Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxCustomerUsernameTextBox;
        private System.Windows.Forms.TextBox uxCustomerPasswordTextBox;
        private System.Windows.Forms.Label Customer_Username_Label;
        private System.Windows.Forms.Label Customer_Password_Label;
        private System.Windows.Forms.Button uxCustomerSubmitButton;
        private System.Windows.Forms.Button uxCustomerCancelButton;
    }
}