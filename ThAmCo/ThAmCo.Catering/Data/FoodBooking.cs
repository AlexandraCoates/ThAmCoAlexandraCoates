using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        public int FoodBookingId { get; set; }

        public  int ClientReferenceId { get; set; } // WONT WORK - MIGHT HAVE TO CHANGE TO CUSTOMER //

        
        public int NumberOfGuests { get; set; }

        [ForeignKey(nameof(MenuId))]
        public int MenuId { get; set; }

        public Menu menu { get; set; }
    }
}
