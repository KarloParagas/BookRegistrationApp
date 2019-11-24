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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            //Create an add customer object
            AddCustomerForm addCustomer = new AddCustomerForm();

            //When user clicks add customer button on the MainForm, AddCustomerForm pops up
            DialogResult result = addCustomer.ShowDialog();

            //If user adds a customer
            if (result == DialogResult.OK)
            {
                //Repopulate/Refresh the list from the customer database
                //Note: PopulateCustomerList method must clear the combo box before repopulating in order for the refresh to work
                PopulateCustomerList();
            }
            else 
            {
                MessageBox.Show("No customer was added");
            }
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            //Create an add book object
            AddBookForm addBook = new AddBookForm();

            //When user clicks add book button on the MainForm, AddBookForm pops up
            DialogResult result = addBook.ShowDialog();

            //If user adds a book
            if (result == DialogResult.OK) 
            {
                //Repopulate/Refresh the list from the book database
                //Note: PopulateBookList method must clear the combo box before repopulating in order for the refresh to work
                PopulateBookList();
            }
            else 
            {
                MessageBox.Show("No book was added");
            }
        }

        /// <summary>
        /// Gets the newly added registration.
        /// Create a public NewReg so it can be accessed in other forms.
        /// </summary>
        public Registration NewReg { get; set; }

        private void registerProductButton_Click(object sender, EventArgs e)
        {
            //Create a RegistrationConfirmationForm object
            RegisterConfirmationForm confirm = new RegisterConfirmationForm();

            //Gives the user an option to confirm their registration or not
            DialogResult result = confirm.ShowDialog();

            //If user clicks yes
            if (result == DialogResult.OK)
            {
                //Get the selected customer
                Customer c = (Customer)customerComboBox.SelectedItem;

                //Grab the selected book
                Book b = (Book)bookComboBox.SelectedItem;

                //Create a registration object
                Registration regBook = new Registration()
                {
                    //Get the selected customer's CustomerID
                    CustomerID = c.CustomerID,

                    //Get the selected book's ISBN
                    ISBN = b.ISBN,

                    //Get the register date
                    RegDate = dateRegisteredPicker.Value
                };

                //Once the registration object has been created
                //set the new registration into the property (Registration.cs)
                NewReg = regBook;

                //Add the registration to the database
                BookRegistrationDB.RegisterBook(regBook);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
            PopulateBookList();
        }

        private void PopulateCustomerList()
        {
            //Populate the list of customers from the database
            List<Customer> allCustomers = CustomerDB.GetAllCustomers();

            //Start with an empty list, so it doesn't re-add previous books causing duplicates
            customerComboBox.Items.Clear();

            //Adds all of the customers from the database in the customersComboBox 
            foreach (Customer c in allCustomers)
            {
                customerComboBox.Items.Add(c);
            }
        }

        private void PopulateBookList()
        {
            //Populate the list of books from the database
            List<Book> allBooks = BookDB.GetAllBooks();

            //Start with an empty list, so it doesn't re-add previous books causing duplicates
            bookComboBox.Items.Clear();

            //Adds all of the books from the database in the bookComboBox
            foreach (Book b in allBooks)
            {
                bookComboBox.Items.Add(b);
            }
        }
    }
}
