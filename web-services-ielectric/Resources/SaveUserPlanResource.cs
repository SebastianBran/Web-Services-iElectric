using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SaveUserPlanResource
    {
        [Required]
        public DateTime DateOfUpdate { get; set; }
    }
}
