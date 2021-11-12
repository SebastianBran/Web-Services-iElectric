using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class AdministratorResponse : BaseResponse<Administrator>
    {
        public AdministratorResponse(string message) : base(message) { }
        public AdministratorResponse(Administrator resource) : base(resource) { }
    }
}