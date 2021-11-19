using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services.Comunication
{
    public class ApplianceResponse : BaseResponse<Appliance>
    {
        public ApplianceResponse(string message) : base(message) { }
        public ApplianceResponse(Appliance appliance) : base(appliance) { }
    }
}
