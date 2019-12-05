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
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the newly added book.
        /// Create a public NewBook so it can be accessed in other forms.
        /// </summary>
        public Book NewBook { get; set; }

        /// <summary>
        /// Adds a single book to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBookBtn_Click(object sender, EventArgs e)
        {
            //If user submits empty fields
            if (isDataValid() == true) 
            {
                MessageBox.Show("Saved the book to the database");

                //Creates a single book object
                Book b = new Book()
                {
                    ISBN = isbnTxt.Text,
                    Title = titleTxt.Text,
                    Price = Convert.ToDecimal(priceTxt.Text)
                };

                //Once a book object has been created, 
                //set the new book into that property (Book.cs)
                NewBook = b;

                try
                {
                    //Add the book to the database
                    BookDB.Add(b); //This .add is from BookDB's add method
                    DialogResult = DialogResult.OK;
                }
                catch 
                {
                    MessageBox.Show("We're having server issues");
                }           
            }
        }

        /// <summary>
        /// Checks if user submits an empty form, and gives an error if so
        /// </summary>
        /// <returns></returns>
        private bool isDataValid()
        {
            if (isbnTxt.Text == "" || titleTxt.Text == "" || priceTxt.Text == "") 
            {
                MessageBox.Show("Please fill out all required fields");
                return false;
            }
            return true;
        }
    }
}
