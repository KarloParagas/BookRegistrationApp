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
        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
            PopulateBookList();

            editCustomerBtn.Enabled = false;
            editBookBtn.Enabled = false;
            deleteCustomerBtn.Enabled = false;
            deleteBookBtn.Enabled = false;
        }

        /// <summary>
        /// Pops up an add customer dialog box so user can add a customer to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Pops up an add book dialog box so the user can add a book to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Registers a single selected customer and book 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerProductButton_Click(object sender, EventArgs e)
        {
            if (isSelectionValid() == true) 
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
        }

        /// <summary>
        /// Checks if user selects a valid customer and book
        /// </summary>
        /// <returns></returns>
        private bool isSelectionValid()
        {
            //If user doesn't select anything
            if (customerComboBox.Text == "" || bookComboBox.Text == "" ) 
            {
                MessageBox.Show("Please make sure you select a customer and/or book before registering");
                return false;
            }
            return true;
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

        /// <summary>
        /// Enables the edit customer button, if user selects a customer from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            editCustomerBtn.Enabled = true;
            deleteCustomerBtn.Enabled = true;
        }

        /// <summary>
        /// Enables the edit book button, if user selects a book from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editBookBtn.Enabled = true;
            deleteBookBtn.Enabled = true;
        }

        private void EditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerComboBox.Text)) 
            {
                MessageBox.Show("Please select a customer");
                return;
            }

            Customer customer = (Customer)customerComboBox.SelectedItem;

            EditCustomerForm editForm = new EditCustomerForm(customer);
            DialogResult result = editForm.ShowDialog();

            //If customer was successfully updated, pop up a message box the edit was successful
            //and refresh the customer combo box
            if (result == DialogResult.OK)
            {
                customerComboBox.Text = "";

                MessageBox.Show("Customer was successfully updated");

                PopulateCustomerList();
            }
            else 
            {
                MessageBox.Show("Nothing was edited");
            }
        }

        private void DeleteCustomerBtn_Click(object sender, EventArgs e)
        {
            //Get the selected customer
            Customer selectedCustomer = (Customer)customerComboBox.SelectedItem;

            string message = $"Are you sure you want to delete {selectedCustomer.FirstName} {selectedCustomer.LastName}?";

            DialogResult result = MessageBox.Show(text: message, 
                                                  caption: "Delete?",
                                                  buttons: MessageBoxButtons.YesNo,
                                                  icon: MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                try
                {
                    //Remove in database
                    CustomerDB.Delete(selectedCustomer.CustomerID);

                    //Remove from the list
                    customerComboBox.Items.Remove(selectedCustomer);

                    MessageBox.Show("Customer deleted");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Delete unsuccessful. The customer you are trying to delete is currently registered.");
                }
                catch (Exception) 
                {
                    MessageBox.Show("No customers deleted");
                }
            }

            //TODO: If the customer to be deleted currently has a registration in the database, delete their registration as well
        }

        private void EditBookBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bookComboBox.Text)) 
            {
                MessageBox.Show("Please select a book");
                return;
            }

            Book book = (Book)bookComboBox.SelectedItem;

            EditBookForm editForm = new EditBookForm(book);
            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                bookComboBox.Text = "";

                MessageBox.Show("Book was successfully updated");

                PopulateBookList();
            }
            else 
            {
                MessageBox.Show("Nothing was edited");
            }
        }

        private void DeleteBookBtn_Click(object sender, EventArgs e)
        {
            //Get the selected book
            Book selectedBook = (Book)bookComboBox.SelectedItem;

            string message = $"Are you sure you want to delete {selectedBook.Title} {selectedBook.ISBN}?";

            DialogResult result = MessageBox.Show(text: message,
                                                  caption: "Delete?",
                                                  buttons: MessageBoxButtons.YesNo,
                                                  icon: MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //Remove in database
                    BookDB.Delete(selectedBook.ISBN);

                    //Remove from the list
                    customerComboBox.Items.Remove(selectedBook);

                    MessageBox.Show("Book deleted");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Delete unsuccessful. The book you are trying to delete is currently registered to a customer.");
                }
                catch (Exception)
                {
                    MessageBox.Show("No books deleted");
                }
            }

            //TODO: If the book to be deleted currently has a registration in the database, delete its registration as well
        }

        private void DeleteRegistrationBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
