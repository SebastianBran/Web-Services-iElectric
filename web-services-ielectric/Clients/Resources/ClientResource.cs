using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Resources
{
    public class ClientResource : PersonResource
    {
        public long PlanId { get; set; }
    }
}
