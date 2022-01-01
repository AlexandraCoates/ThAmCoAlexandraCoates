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

        public int GuestBookingId { get; set; }

        [ForeignKey(nameof(CustomerId))]

        public int CustomerId { get; set; }

        public Customer customer { get; set; }
    }
}
