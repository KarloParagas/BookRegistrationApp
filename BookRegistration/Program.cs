using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region TestCode

            //Customer c = new Customer();
            //c.CustomerID = 1;
            //c.DateOfBirth = DateTime.Today;
            //c.FirstName = "Karlo";
            //c.LastName = "Paragas";

            //Customer c2 = new Customer();
            //c2.CustomerID = 2;
            //c2.DateOfBirth = DateTime.Today;
            //c2.FirstName = "Oliver";
            //c2.LastName = "Queen";

            //Book b = new Book();
            //b.ISBN = 1234567890987;
            //b.Price = Convert.ToDecimal(39.99);
            //b.Title = "C# Basics";

            //Book b2 = new Book();
            //b2.ISBN = 0987654321234;
            //b2.Price = Convert.ToDecimal(24.99);
            //b.Title = "Java Basics";

            ////Calls the DB static methods
            //BookDB.GetAllBooks();
            //CustomerDB.GetAllCustomers();

            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
