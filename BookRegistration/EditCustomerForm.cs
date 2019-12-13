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
    public partial class EditCustomerForm : Form
    {
        public EditCustomerForm(Customer c)
        {
            InitializeComponent();
            existingCustomer = c;
        }

        private Customer existingCustomer;

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            //Populate existing customer data on the edit customer form
            firstNameTxt.Text = existingCustomer.FirstName;
            lastNameTxt.Text = existingCustomer.LastName;
            titleTxt.Text = existingCustomer.Title;
            dateOfBirthPicker.Value = existingCustomer.DateOfBirth;
        }

        private void EditCustomerBtn_Click(object sender, EventArgs e)
        {
            //Grab the newly edited customer's information
            Customer customer = new Customer()
            {
                FirstName = firstNameTxt.Text,
                LastName = lastNameTxt.Text,
                Title = titleTxt.Text,
                DateOfBirth = dateOfBirthPicker.Value,
                CustomerID = existingCustomer.CustomerID
            };

            try 
            {
                CustomerDB.Update(customer);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException) 
            {
                MessageBox.Show("Customer no longer exists");
            }
        }
    }
}
