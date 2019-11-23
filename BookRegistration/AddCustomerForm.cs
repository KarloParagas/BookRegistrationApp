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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets the newly added customer.
        /// Create a public NewCustomer so it can be accessed in other forms.
        /// </summary>
        public Customer NewCustomer { get; set; }

        private void RegCustomerBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customer has been saved to the database");

            //Creates a single customer object
            Customer c = new Customer()
            {
                FirstName = firstNameTxt.Text,
                LastName = lastNameTxt.Text,
                DateOfBirth = dateOfBirthPicker.Value
            };

            //Once a customer object has been created, 
            //set the new customer into that property
            NewCustomer = c;

            DialogResult = DialogResult.OK;
        }
    }
}
