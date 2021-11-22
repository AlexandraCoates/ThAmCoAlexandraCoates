using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }

    }
}
