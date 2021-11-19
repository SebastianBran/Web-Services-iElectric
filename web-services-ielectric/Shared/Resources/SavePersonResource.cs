using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SavePersonResource
    {
        [Required]
        [MaxLength(30)]
        public string Names { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastNames { get; set; }

        [Required]
        public long CellphoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}