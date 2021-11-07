using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SaveAppointmentResource
    {
        [Required]
        public string DateReserve { get; set; }
        
        public string DateAttention { get; set; }

        [Required]
        public string Hour { get; set; }
        
        [Required]
        public bool Done { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public long TechnicianId { get; set; }

        //[Required]
        //public string ApplianceId { get; set; }

    }
}
