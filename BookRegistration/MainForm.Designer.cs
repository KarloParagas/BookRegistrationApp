namespace BookRegistration
{
    partial class MainForm
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
            this.dateRegisteredComboBox = new System.Windows.Forms.DateTimePicker();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.bookComboBox = new System.Windows.Forms.ComboBox();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.registerBookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateRegisteredComboBox
            // 
            this.dateRegisteredComboBox.Location = new System.Drawing.Point(47, 219);
            this.dateRegisteredComboBox.Name = "dateRegisteredComboBox";
            this.dateRegisteredComboBox.Size = new System.Drawing.Size(200, 20);
            this.dateRegisteredComboBox.TabIndex = 0;
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(47, 54);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(200, 21);
            this.customerComboBox.TabIndex = 1;
            // 
            // bookComboBox
            // 
            this.bookComboBox.FormattingEnabled = true;
            this.bookComboBox.Location = new System.Drawing.Point(47, 137);
            this.bookComboBox.Name = "bookComboBox";
            this.bookComboBox.Size = new System.Drawing.Size(200, 21);
            this.bookComboBox.TabIndex = 2;
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(289, 43);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(165, 32);
            this.addCustomerButton.TabIndex = 3;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(289, 128);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(165, 30);
            this.addBookButton.TabIndex = 4;
            this.addBookButton.Text = "Add Book";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // registerBookButton
            // 
            this.registerBookButton.Location = new System.Drawing.Point(289, 210);
            this.registerBookButton.Name = "registerBookButton";
            this.registerBookButton.Size = new System.Drawing.Size(165, 29);
            this.registerBookButton.TabIndex = 5;
            this.registerBookButton.Text = "Register Book";
            this.registerBookButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 278);
            this.Controls.Add(this.registerBookButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.bookComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.dateRegisteredComboBox);
            this.Name = "MainForm";
            this.Text = "Book Registration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateRegisteredComboBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox bookComboBox;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button registerBookButton;
    }
}

