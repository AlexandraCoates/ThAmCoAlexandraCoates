using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class Staff
    {

        [Display(Name = "Id")]
        public int StaffId { get; set; }

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


        [Display(Name = "First Aid Trained")]
        public bool FirstAider { get; set; }

        public IEnumerable<Staffing> staffing { get; set; }

        // NO FK //

    }
}
