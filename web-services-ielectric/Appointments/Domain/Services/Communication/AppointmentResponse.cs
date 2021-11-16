using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class AppointmentResponse : BaseResponse<Appointment>
    {
        public AppointmentResponse(string message) : base(message) { }

        public AppointmentResponse(Appointment resource) : base(resource) { }
    }
}
