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
        /// <summary>
        /// Retrieves all customers from the database
        /// </summary>
        /// <returns></returns>
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
        /// Adds a customer to the database
        /// </summary>
        /// <exception cref="SqlException"></exception>
        /// <param name="c">Customer to be added</param>
        public static void Add(Customer c) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            //Create a parametarized query
            SqlCommand addCommand = new SqlCommand();
            addCommand.Connection = connection;
            addCommand.CommandText = "INSERT INTO Customer (DateOfBirth, FirstName, LastName, Title) " +
                                     "VALUES (@DateOfBirth, @FirstName, @LastName, @Title)";

            //Populate each of the parameters with a value
            //Must match the properties in Customer.cs
            //Note: CustomerID isn't needed because it's a primary key, it does it automatically
            addCommand.Parameters.AddWithValue("@DateOfBirth", c.DateOfBirth);
            addCommand.Parameters.AddWithValue("@FirstName", c.FirstName);
            addCommand.Parameters.AddWithValue("@LastName", c.LastName);
            addCommand.Parameters.AddWithValue("@Title", c.Title);

            try
            {
                connection.Open();

                //Execute the query, and get the customer into the database
                addCommand.ExecuteNonQuery();
            }
            finally 
            {
                //Ensure the connection is closed and deletes the object
                connection.Dispose();
            }
        }

        /// <summary>
        /// Updates all properties for a customer based on their customer ID
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the ID doesn't exist</exception>
        /// <param name="c">Customer with updated info</param>
        public static void Update(Customer c) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandText = "UPDATE Customer " +
                                        "SET DateOfBirth = @DateOfBirth, " +
                                            "FirstName = @FirstName, " +
                                            "LastName = @LastName, " +
                                            "Title = @Title " +
                                        "WHERE CustomerID = @CustomerID";

            updateCommand.Parameters.AddWithValue("@DateOfBirth", c.DateOfBirth);
            updateCommand.Parameters.AddWithValue("@FirstName", c.FirstName);
            updateCommand.Parameters.AddWithValue("@LastName", c.LastName);
            updateCommand.Parameters.AddWithValue("@Title", c.Title);
            updateCommand.Parameters.AddWithValue("@CustomerID", c.CustomerID);

            try
            {
                connection.Open();

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected == 0) 
                {
                    throw new ArgumentException("A customer with that ID is not found");
                }
            }
            finally 
            {
                connection.Dispose();
            }
        }

        /// <summary>
        /// Deletes a single customer from the database
        /// </summary>
        /// <exception cref="SqlException">There was a problem with the database</exception>
        /// <exception cref="Exception">Thrown when no student is deleted</exception>
        /// <param name="id">The CustomerID of the customer to be deleted</param>
        public static void Delete(int id) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            string query = "DELETE FROM Customer " +
                           "WHERE CustomerID = @CustomerID";

            SqlCommand deleteCommand = new SqlCommand(query, connection);

            deleteCommand.Parameters.AddWithValue("@CustomerID", id);

            try
            {
                connection.Open();

                int rows = deleteCommand.ExecuteNonQuery();

                if (rows == 0) 
                {
                    throw new Exception("No customer was deleted");
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
