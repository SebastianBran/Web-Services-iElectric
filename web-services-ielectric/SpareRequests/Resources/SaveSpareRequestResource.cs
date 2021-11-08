using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SaveSpareRequestResource
    {
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImagePath { get; set; }

        [Required]
        public long TechnicianId { get; set; }

        [Required]
        public long AppointmentId { get; set; }
    }
}