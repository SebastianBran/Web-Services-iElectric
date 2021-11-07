using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class SpareRequest
    {
        //Properties
        public long Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }

        //Relationships -- Relación de muchos a uno
        public long TechnicianId { get; set; }
        public long AppointmentId { get; set; }
        public Technician Technician { get; set; }
        public Appointment Appointment { get; set; }

    }
}
