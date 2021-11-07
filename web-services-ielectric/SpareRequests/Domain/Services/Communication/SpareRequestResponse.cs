using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class SpareRequestResponse : BaseResponse<SpareRequest>
    {
        public SpareRequestResponse(string message) : base(message)
        {
        }

        public SpareRequestResponse(SpareRequest resource) : base(resource)
        {
        }
    }
}
