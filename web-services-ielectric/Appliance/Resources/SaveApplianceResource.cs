using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SaveApplianceResource
    {
        public long ClientId { get; set; }
        public long ApplianceModelId { get; set; }
        public string PurchaseDate { get; set; }
    }
}
