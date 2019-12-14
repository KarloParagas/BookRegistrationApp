namespace BookRegistration
{
    partial class ShowAllRegisteredForm
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
            this.registrationListBox = new System.Windows.Forms.ListBox();
            this.deleteRegistrationBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registrationListBox
            // 
            this.registrationListBox.FormattingEnabled = true;
            this.registrationListBox.Location = new System.Drawing.Point(12, 12);
            this.registrationListBox.Name = "registrationListBox";
            this.registrationListBox.Size = new System.Drawing.Size(501, 420);
            this.registrationListBox.TabIndex = 0;
            // 
            // deleteRegistrationBtn
            // 
            this.deleteRegistrationBtn.Location = new System.Drawing.Point(520, 13);
            this.deleteRegistrationBtn.Name = "deleteRegistrationBtn";
            this.deleteRegistrationBtn.Size = new System.Drawing.Size(137, 23);
            this.deleteRegistrationBtn.TabIndex = 1;
            this.deleteRegistrationBtn.Text = "Delete Registration";
            this.deleteRegistrationBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(520, 407);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(140, 23);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Back to main page";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ShowAllRegisteredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 442);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.deleteRegistrationBtn);
            this.Controls.Add(this.registrationListBox);
            this.Name = "ShowAllRegisteredForm";
            this.Text = "All Registration";
            this.Load += new System.EventHandler(this.ShowAllRegisteredForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox registrationListBox;
        private System.Windows.Forms.Button deleteRegistrationBtn;
        private System.Windows.Forms.Button backBtn;
    }
}