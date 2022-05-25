using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class Customer
    {

        [Required]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; } // PK // 


        [Display(Name = "First Name")]
        public String NameFirst { get; set; }


        [Display(Name = "Last Name")]
        public String NameLast { get; set; }


        [Display(Name = "Address")]
        public String Address { get; set; }


        [Display(Name = "Postcode")]
        public String PostCode { get; set; }


        [Display(Name = "Email")]
        public String Email { get; set; }


        [Display(Name = "Phone Number")]
        public int Phone { get; set; }

        public IEnumerable<GuestBooking> Bookings { get; set; }

        // DOES NOT HAVE A FK // 
    }
}
