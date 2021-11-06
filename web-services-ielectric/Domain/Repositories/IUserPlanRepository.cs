using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IUserPlanRepository
    {
        Task<IEnumerable<UserPlan>> ListAsync();
        Task<IEnumerable<UserPlan>> ListByUserIdAsync(int clientId);
        Task<IEnumerable<UserPlan>> ListByPlanIdAsync(int planId);
        Task<IEnumerable<UserPlan>> ListByDateAsync(DateTime date);
        Task<UserPlan> FindByUserIdDateAndPlanIdAsync(int clientId, int planId, DateTime date);
        Task AddAsync(UserPlan userPlan);
        void Remove(UserPlan userPlan);
        Task AssingUserPlan(int clientId, int planId, DateTime date);
        void UnassingUserPlan(int clientId, int planId, DateTime date);
    }
}
