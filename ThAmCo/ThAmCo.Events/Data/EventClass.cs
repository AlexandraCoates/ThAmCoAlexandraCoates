using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class EventClass
    {


        [Display(Name = "Id")] 
        public int EventId { get; set; }


        [Display(Name = "Type")]
        public string EventType { get; set; }


        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        public IEnumerable<GuestBooking> Bookings { get; set; }

        public IEnumerable<Staffing> Staffing { get; set; }


    }
}
