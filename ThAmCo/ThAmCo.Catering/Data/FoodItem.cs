using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }

        public string Description { get; set; }

        public float UnitPrice { get; set; }
        
    }
}
