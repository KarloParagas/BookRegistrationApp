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

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            //If user submits an empty field
            if (isDataValid() == true) 
            {
                MessageBox.Show("Customer has been saved to the database");

                //Creates a single customer object
                Customer c = new Customer()
                {
                    FirstName = firstNameTxt.Text,
                    LastName = lastNameTxt.Text,
                    DateOfBirth = dateOfBirthPicker.Value,
                    Title = titleTxt.Text
                };

                //Once a customer object has been created, 
                //set the new customer into that property (Customer.cs)
                NewCustomer = c;

                try
                {
                    //Add the customer to the database
                    CustomerDB.Add(c); //This .add is from CustomerDB's add method
                    DialogResult = DialogResult.OK;             
                }
                catch (SqlException) 
                {
                    MessageBox.Show("We're having server issues.");
                }            
            }
        }

        private bool isDataValid()
        {
            if (firstNameTxt.Text == "" || lastNameTxt.Text == "" || titleTxt.Text == "") 
            {
                MessageBox.Show("Please fill out all required fields");
                return false;
            }

            return true;
        }
    }
}
