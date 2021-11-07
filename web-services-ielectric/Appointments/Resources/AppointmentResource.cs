using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class AppointmentResource
    {
        public long Id { get; set; }
        public string DateReserve { get; set; }
        public string DateAttention { get; set; }
        public string Hour { get; set; }
        public long ClientId { get; set; }
        public long TechnicianId { get; set; }
        //public long ApplianceId { get; set; }
        public bool Done { get; set; }
    }
}
