using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class UserPlanResource
    {
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public PlanResource Plan { get; set; }
        public DateTime DateOfUpdate { get; set; }
    }
}
