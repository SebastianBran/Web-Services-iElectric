using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class TechnicianResponse : BaseResponse<Technician>
    {
        public TechnicianResponse(string message) : base(message) { }
        public TechnicianResponse(Technician resource) : base(resource) { }
    }
}
