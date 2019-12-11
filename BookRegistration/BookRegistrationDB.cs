using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    static class BookRegistrationDB
    {
        /// <summary>
        /// Registers a book and indicates if the operation was or was not successful
        /// </summary>
        /// <param name="regBook">Customer and book to be registered</param>
        /// <returns></returns>
        public static bool RegisterBook(Registration regBook) 
        {
            if (Add(regBook) == true)
            {
                System.Windows.Forms.MessageBox.Show("The operation was successful");
                return true;
            }
            else 
            {
                System.Windows.Forms.MessageBox.Show("The operation was NOT successful");
                return false;
            }
        }

        /// <summary>
        /// Adds a registration to the database
        /// </summary>
        /// <exception cref="SqlException"></exception>
        /// <param name="r">Registration to be added</param>
        public static bool Add(Registration r) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            //Create a parameterized query
            SqlCommand addCommand = new SqlCommand();
            addCommand.Connection = connection;
            addCommand.CommandText = "INSERT INTO Registration (CustomerID, ISBN, RegDate) " +
                                     "VALUES (@CustomerID, @ISBN, @RegDate)";

            //Populate each of the parameters with a value
            //Must match the properties in Registration.cs
            addCommand.Parameters.AddWithValue("@CustomerID", r.CustomerID);
            addCommand.Parameters.AddWithValue("@ISBN", r.ISBN);
            addCommand.Parameters.AddWithValue("@RegDate", r.RegDate);

            try
            {
                connection.Open();

                //Execute the query, and get the registration into the database
                addCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException) 
            {
                return false;
            }
            finally
            {
                //Ensure the connection is closed and deletes the object
                connection.Dispose();
            }
        }

        //TODO: Add update method

        //TODO: Add delete method
    }
}
