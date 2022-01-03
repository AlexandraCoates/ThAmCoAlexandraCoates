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

        public int EventId { get; set; }

        public string EventType { get; set; }

    }
}
