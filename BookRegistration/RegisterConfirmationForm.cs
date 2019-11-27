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
    public partial class RegisterConfirmationForm : Form
    {
        public RegisterConfirmationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Confirms with the user, if they're sure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yesBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Doesn't register the customer and/or book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing was registered");
            Close();
        }
    }
}
