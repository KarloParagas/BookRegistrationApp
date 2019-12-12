using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    static class BookDB
    {
        /// <summary>
        /// Retrieves all books from the database
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetAllBooks() 
        {
            //Establish sql connection object to DB by calling the DBHelper class and it's GetConnection method
            SqlConnection connection = DBHelper.GetConnection();

            //Setup a command object that contains the query
            SqlCommand selectCommand = new SqlCommand(); //Create a sql command object
            selectCommand.Connection = connection; //Specify where to send the query to
            selectCommand.CommandText = "SELECT ISBN, Price, Title " +
                                        "FROM Book"; //Basic select query

            //Open Connection
            connection.Open();

            //Send query to DB
            SqlDataReader reader = selectCommand.ExecuteReader(); //Bundles up the result in an object that can be iterated through

            //Do something with results
            var books = new List<Book>();
            while (reader.Read())  //While there's a row to be read, go through and read all the data from that row
            {
                //Go through each column, and wrap it up in a big book object
                //Note: Must match the select query above
                Book tempBook = new Book();
                tempBook.ISBN = (string)reader["ISBN"];
                tempBook.Price = (decimal)reader["Price"];
                tempBook.Title = (string)reader["Title"];

                //Finally, add them to the list
                books.Add(tempBook);
            }

            //Close DB connection, once there are no more rows and the customer list has been populated
            connection.Close();

            return books;
        }

        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <exception cref="SqlException"></exception>
        /// <param name="b">Book to be added</param>
        public static void Add(Book b)
        {
            SqlConnection connection = DBHelper.GetConnection();

            //Create a parameterized query
            SqlCommand addCommand = new SqlCommand();
            addCommand.Connection = connection;
            addCommand.CommandText = "INSERT INTO Book (ISBN, Price, Title) " +
                                     "VALUES (@ISBN, @Price, @Title)";

            //Populate each of the parameters with a value
            //Must match the properties in Book.cs
            //Note: ISBN isn't needed because it's a primary key
            addCommand.Parameters.AddWithValue("@ISBN", b.ISBN);
            addCommand.Parameters.AddWithValue("@Price", b.Price);
            addCommand.Parameters.AddWithValue("@Title", b.Title);

            try
            {
                connection.Open();

                //Execute the query, and get the book into the database
                addCommand.ExecuteNonQuery();
            }
            catch 
            {
                //Ensure the connection is closed and deletes the object
                connection.Dispose();
            }
        }

        /// <summary>
        /// Updates all properties for the book based on the ISBN
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when a book with that ISBN doesn't exist</exception>
        /// <param name="b">The book with updated info</param>
        public static void Update(Book b) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;

            updateCommand.CommandText = "UPDATE Book " +
                                        "SET ISBN = @ISBN, " +
                                            "Price = @Price, " +
                                            "Title = @Title " +
                                        "WHERE ISBN = @ISBN";

            updateCommand.Parameters.AddWithValue("@ISBN", b.ISBN);
            updateCommand.Parameters.AddWithValue("@Price", b.Price);
            updateCommand.Parameters.AddWithValue("@Title", b.Title);

            try
            {
                connection.Open();

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected == 0) 
                {
                    throw new ArgumentException("A book with that ISBN is not found");
                }
            }
            finally 
            {
                connection.Dispose();
            }
        }

        /// <summary>
        /// Deleted a single book from the database
        /// </summary>
        /// <exception cref="SqlException">Thrown when there's a problem with the database</exception>
        /// <exception cref="Exception">Thrown when no book is deleted</exception>
        /// <param name="ISBN">The ISBN of the book to be deleted</param>
        public static void Delete(string ISBN) 
        {
            SqlConnection connection = DBHelper.GetConnection();

            string query = "DELETE FROM Book " +
                           "WHERE ISBN = @ISBN";

            SqlCommand deleteCommand = new SqlCommand(query, connection);

            deleteCommand.Parameters.AddWithValue("@ISBN", ISBN);

            try
            {
                connection.Open();

                int rows = deleteCommand.ExecuteNonQuery();

                if (rows == 0) 
                {
                    throw new Exception("No book was deleted");
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
                //Ensure the connection is closed and the object deleted
                connection.Dispose();
            }
        }
    }
}
