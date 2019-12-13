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
            this.dateRegisteredPicker = new System.Windows.Forms.DateTimePicker();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.bookComboBox = new System.Windows.Forms.ComboBox();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.registerProductButton = new System.Windows.Forms.Button();
            this.editCustomerBtn = new System.Windows.Forms.Button();
            this.editBookBtn = new System.Windows.Forms.Button();
            this.deleteCustomerBtn = new System.Windows.Forms.Button();
            this.deleteBookBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateRegisteredPicker
            // 
            this.dateRegisteredPicker.Location = new System.Drawing.Point(47, 219);
            this.dateRegisteredPicker.Name = "dateRegisteredPicker";
            this.dateRegisteredPicker.Size = new System.Drawing.Size(200, 20);
            this.dateRegisteredPicker.TabIndex = 4;
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(47, 54);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(200, 21);
            this.customerComboBox.TabIndex = 0;
            this.customerComboBox.SelectedValueChanged += new System.EventHandler(this.customerComboBox_SelectedValueChanged);
            // 
            // bookComboBox
            // 
            this.bookComboBox.FormattingEnabled = true;
            this.bookComboBox.Location = new System.Drawing.Point(47, 137);
            this.bookComboBox.Name = "bookComboBox";
            this.bookComboBox.Size = new System.Drawing.Size(200, 21);
            this.bookComboBox.TabIndex = 2;
            this.bookComboBox.SelectedIndexChanged += new System.EventHandler(this.bookComboBox_SelectedIndexChanged);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(289, 43);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(180, 32);
            this.addCustomerButton.TabIndex = 1;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(289, 128);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(180, 30);
            this.addBookButton.TabIndex = 3;
            this.addBookButton.Text = "Add Book";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // registerProductButton
            // 
            this.registerProductButton.Location = new System.Drawing.Point(289, 210);
            this.registerProductButton.Name = "registerProductButton";
            this.registerProductButton.Size = new System.Drawing.Size(180, 29);
            this.registerProductButton.TabIndex = 5;
            this.registerProductButton.Text = "Register Product";
            this.registerProductButton.UseVisualStyleBackColor = true;
            this.registerProductButton.Click += new System.EventHandler(this.registerProductButton_Click);
            // 
            // editCustomerBtn
            // 
            this.editCustomerBtn.Location = new System.Drawing.Point(289, 81);
            this.editCustomerBtn.Name = "editCustomerBtn";
            this.editCustomerBtn.Size = new System.Drawing.Size(80, 23);
            this.editCustomerBtn.TabIndex = 6;
            this.editCustomerBtn.Text = "Edit Customer";
            this.editCustomerBtn.UseVisualStyleBackColor = true;
            this.editCustomerBtn.Click += new System.EventHandler(this.EditCustomerBtn_Click);
            // 
            // editBookBtn
            // 
            this.editBookBtn.Location = new System.Drawing.Point(289, 164);
            this.editBookBtn.Name = "editBookBtn";
            this.editBookBtn.Size = new System.Drawing.Size(80, 23);
            this.editBookBtn.TabIndex = 7;
            this.editBookBtn.Text = "Edit Book";
            this.editBookBtn.UseVisualStyleBackColor = true;
            this.editBookBtn.Click += new System.EventHandler(this.EditBookBtn_Click);
            // 
            // DeleteCustomerBtn
            // 
            this.deleteCustomerBtn.Location = new System.Drawing.Point(374, 81);
            this.deleteCustomerBtn.Name = "DeleteCustomerBtn";
            this.deleteCustomerBtn.Size = new System.Drawing.Size(95, 23);
            this.deleteCustomerBtn.TabIndex = 8;
            this.deleteCustomerBtn.Text = "Delete Customer";
            this.deleteCustomerBtn.UseVisualStyleBackColor = true;
            this.deleteCustomerBtn.Click += new System.EventHandler(this.DeleteCustomerBtn_Click);
            // 
            // DeleteBookBtn
            // 
            this.deleteBookBtn.Location = new System.Drawing.Point(374, 164);
            this.deleteBookBtn.Name = "DeleteBookBtn";
            this.deleteBookBtn.Size = new System.Drawing.Size(95, 23);
            this.deleteBookBtn.TabIndex = 9;
            this.deleteBookBtn.Text = "Delete Book";
            this.deleteBookBtn.UseVisualStyleBackColor = true;
            this.deleteBookBtn.Click += new System.EventHandler(this.DeleteBookBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 273);
            this.Controls.Add(this.deleteBookBtn);
            this.Controls.Add(this.deleteCustomerBtn);
            this.Controls.Add(this.editBookBtn);
            this.Controls.Add(this.editCustomerBtn);
            this.Controls.Add(this.registerProductButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.bookComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.dateRegisteredPicker);
            this.Name = "MainForm";
            this.Text = "Book Registration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateRegisteredPicker;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox bookComboBox;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button registerProductButton;
        private System.Windows.Forms.Button editCustomerBtn;
        private System.Windows.Forms.Button editBookBtn;
        private System.Windows.Forms.Button deleteCustomerBtn;
        private System.Windows.Forms.Button deleteBookBtn;
    }
}

