using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class ClientResource : PersonResource
    {
        public long ClientId { get; set; }
        public long PlanId { get; set; }
        public List<PlanResource> Plans { get; set; }
    }
}
