using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SpareRequestResource
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
        public long TechnicianId { get; set; }
        public long AppointmentId { get; set; }
    }
}
