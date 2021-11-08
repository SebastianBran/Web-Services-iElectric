using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<Plan> FindById(long planId);
        Task AddAsync(Plan plan);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
