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
        public static List<Registration> GetAllRegistration() 
        {
            SqlConnection connection = DBHelper.GetConnection();

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT CustomerID, ISBN, RegDate " +
                                        "FROM Registration";

            connection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var registrations = new List<Registration>();
            while (reader.Read()) 
            {
                Registration tempRegistration = new Registration();

                tempRegistration.CustomerID = (int)reader["CustomerID"];
                tempRegistration.ISBN = (string)reader["ISBN"];
                tempRegistration.RegDate = (DateTime)reader["RegDate"];

                registrations.Add(tempRegistration);
            }

            connection.Close();

            return registrations;
        }

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

        /// <summary>
        /// Deletes a single registration
        /// </summary>
        /// <param name="r"></param>
        public static void Delete(Registration r) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            string query = "DELETE FROM Registration " +
                           "WHERE CustomerID = @CustomerID";

            SqlCommand deleteCommand = new SqlCommand(query, connection);

            deleteCommand.Parameters.AddWithValue("@CustomerID", r);

            try
            {
                connection.Open();

                int rows = deleteCommand.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new Exception("No registration was deleted");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
            finally
            {
                //Ensure the connection is closed and the object is deleted
                connection.Dispose();
            }
        }
    }
}
