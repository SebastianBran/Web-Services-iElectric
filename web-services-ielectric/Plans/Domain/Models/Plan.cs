using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class Plan
    {
        // Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}