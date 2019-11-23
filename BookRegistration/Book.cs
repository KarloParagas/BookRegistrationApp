using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    /// <summary>
    /// Represents a single book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// No arguments. It initializes everything to default value without having explicitly.
        /// </summary>
        public Book() 
        {
        
        }

        //Properties
        /// <summary>
        /// The book's serial number
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// The cost of the book
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The book's title
        /// </summary>
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
