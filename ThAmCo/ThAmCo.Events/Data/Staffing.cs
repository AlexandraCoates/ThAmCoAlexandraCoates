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

        public int StaffingId { get; set; }

        [ForeignKey(nameof(StaffId))]
        public int StaffId { get; set; }

        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }

        public Staff staff { get; set; }

        public EventClass eventClass { get; set; } // Does not exist yet // 

    }
}
