using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            deleteRegistrationBtn.Enabled = false;

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
    }
}
