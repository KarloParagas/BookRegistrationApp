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
        public static List<Book> GetAllBooks() 
        {
            //Establish connection to DB
            SqlConnection connection = DBHelper.GetConnection();

            //Setup Query
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT ISBN, Price, Title " +
                                        "FROM Book";

            //Open Connection
            connection.Open();

            //Send query to DB
            SqlDataReader reader = selectCommand.ExecuteReader();

            //Do something with results
            var books = new List<Book>();
            while (reader.Read()) 
            {
                //Must match the select query above
                Book tempBook = new Book();
                tempBook.ISBN = (string)reader["ISBN"];
                tempBook.Price = (decimal)reader["Price"];
                tempBook.Title = (string)reader["Title"];

                //Finally, add them to the list
                books.Add(tempBook);
            }

            //Close DB connection
            connection.Close();

            return books;
        }

        public static void Delete(string isbn)
        {
            throw new NotImplementedException();
        }

        public static void Update(Book b)
        {
            throw new NotImplementedException();
        }

        public static void Add(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
