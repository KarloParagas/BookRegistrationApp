using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    static class CustomerDB
    {
        public static List<Customer> GetAllCustomers()
        {
            //Establish sql connection object to DB by calling the DBHelper class and it's GetConnection method
            SqlConnection connection = DBHelper.GetConnection();

            //Setup a command object that contains the query
            SqlCommand selectCommand = new SqlCommand(); //Create a sql command object
            selectCommand.Connection = connection; //Specify where to send the query to
            selectCommand.CommandText = "SELECT CustomerID, DateOfBirth, FirstName, LastName, Title " +
                                 "FROM Customer"; //Basic select query

            //Open Connection
            connection.Open();

            //Send query to DB
            SqlDataReader reader = selectCommand.ExecuteReader(); //Bundles up the result in an object that can be iterated through

            //Do something with results
            var customers = new List<Customer>();
            while (reader.Read()) //While there's a row to be read, go through and read all the data from that row
            {
                //Go through each column, and wrap it up in a big customer object
                //Note: Must match the select query above
                Customer tempCustomer = new Customer();
                tempCustomer.CustomerID = (int)reader["CustomerID"];
                tempCustomer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                tempCustomer.FirstName = (string)reader["FirstName"];
                tempCustomer.LastName = (string)reader["LastName"];
                tempCustomer.Title = (string)reader["Title"];

                //Finally, add them to the list
                customers.Add(tempCustomer);
            }

            //Close DB connection, once there are no more rows and the customer list has been populated
            connection.Close();

            return customers;
        }

        /// <summary>
        /// Deletes a single customer from the database
        /// </summary>
        /// <exception cref="SqlException">There was an issue with the database</exception>
        /// <exception cref="Exception">Thrown when no customer is deleted</exception>
        /// <param name="id">The CustomerID of the customer to be deleted</param>
        public static void Delete(int id) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            //Create a parameterized query
            string query = "DELETE FROM Customer " +
                           "WHERE CustomerID = @CustomerID";
            SqlCommand deleteCommand = new SqlCommand(query, connection);
            deleteCommand.Parameters.AddWithValue("@CustomerID", id);

            try
            {
                connection.Open();

                //If the connection opens successfully, execute query below
                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected == 0) //If nothing was deleted 
                {
                    throw new Exception("There is no customer with that ID");
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
                //Since finally always runs, it's good to always to clean up the connection object
                //Ensures connection and deletes object
                connection.Dispose();
            }
        }

        public static void Update(Customer c) 
        {
            throw new NotImplementedException();
        }

        public static void Add(Customer c) 
        {
            throw new NotImplementedException();
        }
    }
}
