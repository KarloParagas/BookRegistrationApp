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
    public partial class EditBookForm : Form
    {
        public EditBookForm(Book b)
        {
            InitializeComponent();
            existingBook = b;
        }

        private Book existingBook;

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            isbnTxt.Enabled = false;

            //Populate existing customer data on the edit customer form
            isbnTxt.Text = existingBook.ISBN;
            priceTxt.Text = existingBook.Price.ToString();
            titleTxt.Text = existingBook.Title;
        }

        private void EditBookBtn_Click(object sender, EventArgs e)
        {
            //Grab the newly edited book's information
            Book book = new Book() 
            {
                ISBN = isbnTxt.Text,
                Title = titleTxt.Text,
                Price = Convert.ToDecimal(priceTxt.Text)
            };

            try
            {
                BookDB.Update(book);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException) 
            {
                MessageBox.Show("Book no longer exists");
            }
        }
    }
}
