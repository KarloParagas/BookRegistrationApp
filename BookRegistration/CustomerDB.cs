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
            //Establish connection to DB
            SqlConnection connection = DBHelper.GetConnection();

            //Setup Query
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT CustomerID, DateOfBirth, FirstName, LastName, Title " +
                                 "FROM Customer";

            //Open Connection
            connection.Open();

            //Send query to DB
            SqlDataReader reader = selectCommand.ExecuteReader();

            //Do something with results
            var customers = new List<Customer>();
            while (reader.Read()) 
            {
                //Must match the select query above
                Customer tempCustomer = new Customer();
                tempCustomer.CustomerID = (int)reader["CustomerID"];
                tempCustomer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                tempCustomer.FirstName = (string)reader["FirstName"];
                tempCustomer.LastName = (string)reader["LastName"];
                tempCustomer.Title = (string)reader["Title"];

                //Finally, add them to the list
                customers.Add(tempCustomer);
            }

            //Close DB connection
            connection.Close();

            return customers;
        }

        public static void Delete(int id) 
        {
            throw new NotImplementedException();
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
