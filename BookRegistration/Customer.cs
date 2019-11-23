using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    /// <summary>
    /// Represents a single customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// No arguments. It initializes everything to default value without having explicitly.
        /// </summary>
        public Customer() 
        {
        
        }

        //Properties
        /// <summary>
        /// Unique numerical identification of a customer
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// The date the customer is born. Time is ignored.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The customer's legal first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The customer's legal last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The customer's title (ex: Mr., Dr., Ms.,)
        /// </summary>
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
