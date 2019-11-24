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

        //Properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the newly added book.
        /// Create a public NewBook so it can be accessed in other forms.
        /// </summary>
        public Book NewBook { get; set; }

        private void AddBookBtn_Click(object sender, EventArgs e)
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
                BookDB.Add(b);
                DialogResult = DialogResult.OK;

                //TODO: Refresh the list when a new book is added to the database
            }
            catch 
            {
                MessageBox.Show("We're having server issues");
            }
        }
    }
}
