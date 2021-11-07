using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class UserPlanResponse : BaseResponse<UserPlan>
    {
        public UserPlanResponse(UserPlan resource) : base(resource)
        {
        }

        public UserPlanResponse(string message) : base(message)
        {
        }
    }
}