using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class GuestBooking
    {

        [Display(Name = "Booking Id")]
        public int GuestBookingId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Display(Name = "Event Id")]
        public int EventId { get; set; }

        public Customer Customer { get; set; }

        public EventClass eventClass { get; set; }


        [Display(Name = "Attendence")]
        public Boolean attended { get; set; } = false;
    }
}
