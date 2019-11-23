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
                //Using the addCustomer object above from AddCustomerForm,
                //grab the NewCustomer that was created
                Customer c = addCustomer.NewCustomer;

                //Adds the customer to the customerComboBox
                customerComboBox.Items.Add(c);
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
                //Using the addBook object above from AddBookForm,
                //grab the newBook that was created
                Book b = addBook.NewBook;

                //Adds the book to the bookComboBox
                bookComboBox.Items.Add(b);
            }
            else 
            {
                MessageBox.Show("No book was added");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
        }

        private void PopulateCustomerList()
        {
            //Populate the list of customers from the database
            List<Customer> allCustomers = CustomerDB.GetAllCustomers();

            //Adds all of the customers from the database in the customersComboBox 
            foreach (Customer c in allCustomers)
            {
                customerComboBox.Items.Add(c);
            }

            //Populate the list of books from the database
            List<Book> allBooks = BookDB.GetAllBooks();

            //Adds all of the books from the database in the bookComboBox
            foreach (Book b in allBooks)
            {
                bookComboBox.Items.Add(b);
            }
        }
    }
}
