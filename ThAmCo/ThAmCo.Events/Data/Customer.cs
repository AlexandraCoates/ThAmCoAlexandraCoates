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

        public int CustomerId { get; set; } // PK // 

        public String NameFirst { get; set; }

        public String NameLast { get; set; }

        public String Address { get; set; }

        public String PostCode { get; set; }

        public String Email { get; set; }

        public int Phone { get; set; }

        public bool Attendance { get; set; }

        // DOES NOT HAVE A FK // 
    }
}
