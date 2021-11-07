﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IUserPlanService
    {
        Task<IEnumerable<UserPlan>> ListAsync();
        Task<IEnumerable<UserPlan>> ListByUserIdAsync(int clientId);
        Task<IEnumerable<UserPlan>> ListByPlanIdAsync(int planId);
        Task<IEnumerable<UserPlan>> ListByDateAsync(DateTime date);
        Task<UserPlanResponse> AssignUserPlanAsync(int clientId, int planId, DateTime date);
        Task<UserPlanResponse> UnassignUserPlanAsync(int clientId, int planId, DateTime date);
    }
}
