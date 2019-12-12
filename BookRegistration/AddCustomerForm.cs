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

        /// <summary>
        /// Gets the newly added customer.
        /// Create a public NewCustomer so it can be accessed in other forms.
        /// </summary>
        public Customer NewCustomer { get; set; }

        /// <summary>
        /// Adds a single customer to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            //If user submits a valid data
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
            if (isPresent() && isTitleValid() && isDOBValid() == true) 
            {
                return true;
            }

            return false;
        }

        private bool isPresent()
        {
            if (firstNameTxt.Text == "" || lastNameTxt.Text == "" || titleTxt.Text == "") 
            {
                MessageBox.Show("Please fill out all required fields");
                return false;
            }
            return true;
        }

        private bool isTitleValid()
        {
            string userInput = titleTxt.Text;

            if (userInput == "Mr" || userInput == "Ms" || userInput == "Mrs" ||
                userInput == "Dr" || userInput == "Sr" || userInput == "Jr")
            {
                return true;
            }
            else 
            {
                MessageBox.Show("Please provide a valid title (i.e. Mr, Ms, Mrs, Dr, Sr, Jr) ");
                return false;
            }
        }

        private bool isDOBValid()
        {
            if (dateOfBirthPicker.Value > DateTime.Today) 
            {
                MessageBox.Show("No time travelers allowed at this time");
                return false;
            }
            return true;
        }
    }
}
