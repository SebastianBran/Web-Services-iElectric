using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Security.Domain.Services.Communication
{
    public class UpdateRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
