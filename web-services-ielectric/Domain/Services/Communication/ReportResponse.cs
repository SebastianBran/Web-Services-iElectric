using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class ReportResponse : BaseResponse<Report>
    {
        public ReportResponse(string message) : base(message)
        {
        }

        public ReportResponse(Report resource) : base(resource)
        {
        }
    }
}
