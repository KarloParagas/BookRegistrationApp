using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistration
{
    public partial class ShowAllRegisteredForm : Form
    {
        public ShowAllRegisteredForm()
        {
            InitializeComponent();
        }

        private void ShowAllRegisteredForm_Load(object sender, EventArgs e)
        {
            List<Registration> allRegistration = BookRegistrationDB.GetAllRegistration();

            allRegistration = allRegistration
                                .OrderBy(id => id.CustomerID)
                                .ToList();

            registrationListBox.Items.Clear();

            foreach (Registration r in allRegistration) 
            {
                registrationListBox.Items.Add(r);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DeleteRegistrationBtn_Click(object sender, EventArgs e)
        {
            if (registrationListBox.SelectedIndex < 0) 
            {
                MessageBox.Show("Please select a registration");
                return;
            }

            Registration registration = (Registration)registrationListBox.SelectedItem;

            string message = $"Are you sure you want to delete CustomerID #{registration.CustomerID}'s registration?";

            DialogResult result = MessageBox.Show(text: message,
                                                   caption: "Delete?",
                                                   buttons: MessageBoxButtons.YesNo,
                                                   icon: MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                try
                {
                    BookRegistrationDB.Delete(registration.CustomerID);
                    registrationListBox.Items.Remove(registration);
                    MessageBox.Show("Registration deleted");
                }
                catch (SqlException)
                {
                    MessageBox.Show("We are having server issues. Try again later");
                }
                catch (Exception) 
                {
                    MessageBox.Show("No registrations were deleted");
                }
            }
        }
    }
}
