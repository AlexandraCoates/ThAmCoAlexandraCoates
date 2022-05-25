using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class Staffing
    {

        [Display(Name = "Id")]
        public int StaffingId { get; set; }


        [Display(Name = "Staff Id")]
        [ForeignKey(nameof(StaffId))]
        public int StaffId { get; set; }


        [Display(Name = "Event Id")]
        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }

        public Staff staff { get; set; }

        public EventClass eventClass { get; set; }  

    }
}
