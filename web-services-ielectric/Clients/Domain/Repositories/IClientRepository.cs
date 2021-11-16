using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task<Client> FindByIdAsync(long id);
        Task<Client> FindByPlanIdAsync(long clientId, long planId);
        void Update(Client client);
        void Remove(Client client);
        Task AssingUserPlan(long clientId, long planId);
        void UnassingUserPlan(long clientId, long planId);
    }
}
