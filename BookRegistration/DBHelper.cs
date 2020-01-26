using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    static class DBHelper
    {
        /// <summary>
        /// Helper class that gets a connection to the Final_BookRegistration Database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection() 
        {
            string connection = @"Data Source=(localdb)\MSSQLLocalDB;" +
                "Initial Catalog=BookRegistration;" +
                "Integrated Security=True;";

            return new SqlConnection(connection);
        }
    }
}
