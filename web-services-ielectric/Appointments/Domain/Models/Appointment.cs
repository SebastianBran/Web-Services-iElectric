using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class Appointment
    {
        //Properties
        public long Id { get; set; }
        public string DateReserve { get; set; }
        public string DateAttention { get; set; }
        public string Hour { get; set; }
        public bool Done { get; set; }


        //Relationships
        public long ClientId { get; set; }
        public long TechnicianId { get; set; }
        //public long ApplianceId { get; set; }
        public Client Client { get; set; } // -- Relación de muchos a uno
        public Technician Technician { get; set; } 

    }
}
