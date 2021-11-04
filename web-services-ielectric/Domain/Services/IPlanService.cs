using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<IEnumerable<Plan>> ListByUserIdAsync(int userId);
        Task<PlanResponse> GetByIdAsync(int id);
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
        Task<PlanResponse> DeleteAsync(int id);

    }
}
