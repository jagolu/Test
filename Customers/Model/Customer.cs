using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Customers.Model
{
    public class Customer
    {
        [Key]
        public string Id { get;set; }

        [Required]
        public string Name { get;set; } 

        [Required]
        public string Address { get;set; } 

        [Required]
        public string City { get;set; }

        [Required]
        public string Country { get;set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
