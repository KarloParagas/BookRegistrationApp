using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    public class Registration
    {
        //Properties
        /// <summary>
        /// Unique numerical identification of a customer
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// The book's serial number
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Date of the book's registration
        /// </summary>
        public DateTime RegDate { get; set; }
    }
}
