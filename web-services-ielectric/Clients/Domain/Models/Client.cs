using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class Client : Person
    {
        public long PlanId { get; set; }
    }
}
