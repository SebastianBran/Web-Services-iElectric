using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class PersonResource
    {
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public long CellphoneNumber { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }
    }
}
