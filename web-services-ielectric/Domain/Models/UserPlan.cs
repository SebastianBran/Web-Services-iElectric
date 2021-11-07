using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class UserPlan
    {
        // Properties
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public DateTime DateOfUpdate { get; set; }
    }
}