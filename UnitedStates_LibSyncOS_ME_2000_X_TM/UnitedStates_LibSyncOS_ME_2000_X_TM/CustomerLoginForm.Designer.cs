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
            this.Customer_Username_Textbox = new System.Windows.Forms.TextBox();
            this.Customer_Password_Textbox = new System.Windows.Forms.TextBox();
            this.Customer_Username_Label = new System.Windows.Forms.Label();
            this.Customer_Password_Label = new System.Windows.Forms.Label();
            this.Customer_Login_Submit_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Customer_Username_Textbox
            // 
            this.Customer_Username_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Username_Textbox.Location = new System.Drawing.Point(142, 56);
            this.Customer_Username_Textbox.Name = "Customer_Username_Textbox";
            this.Customer_Username_Textbox.Size = new System.Drawing.Size(189, 29);
            this.Customer_Username_Textbox.TabIndex = 0;
            // 
            // Customer_Password_Textbox
            // 
            this.Customer_Password_Textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.Customer_Password_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Password_Textbox.Location = new System.Drawing.Point(142, 124);
            this.Customer_Password_Textbox.MaxLength = 16;
            this.Customer_Password_Textbox.Name = "Customer_Password_Textbox";
            this.Customer_Password_Textbox.PasswordChar = '*';
            this.Customer_Password_Textbox.Size = new System.Drawing.Size(189, 29);
            this.Customer_Password_Textbox.TabIndex = 1;
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
            this.Customer_Password_Label.Location = new System.Drawing.Point(32, 127);
            this.Customer_Password_Label.Name = "Customer_Password_Label";
            this.Customer_Password_Label.Size = new System.Drawing.Size(97, 24);
            this.Customer_Password_Label.TabIndex = 3;
            this.Customer_Password_Label.Text = "Password:";
            // 
            // Customer_Login_Submit_Button
            // 
            this.Customer_Login_Submit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Login_Submit_Button.Location = new System.Drawing.Point(119, 188);
            this.Customer_Login_Submit_Button.Name = "Customer_Login_Submit_Button";
            this.Customer_Login_Submit_Button.Size = new System.Drawing.Size(146, 46);
            this.Customer_Login_Submit_Button.TabIndex = 4;
            this.Customer_Login_Submit_Button.Text = "Submit";
            this.Customer_Login_Submit_Button.UseVisualStyleBackColor = true;
            // 
            // CustomerLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 260);
            this.Controls.Add(this.Customer_Login_Submit_Button);
            this.Controls.Add(this.Customer_Password_Label);
            this.Controls.Add(this.Customer_Username_Label);
            this.Controls.Add(this.Customer_Password_Textbox);
            this.Controls.Add(this.Customer_Username_Textbox);
            this.Name = "CustomerLoginForm";
            this.Text = "Customer Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Customer_Username_Textbox;
        private System.Windows.Forms.TextBox Customer_Password_Textbox;
        private System.Windows.Forms.Label Customer_Username_Label;
        private System.Windows.Forms.Label Customer_Password_Label;
        private System.Windows.Forms.Button Customer_Login_Submit_Button;
    }
}