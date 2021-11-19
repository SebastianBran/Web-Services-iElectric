using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IApplianceRepository
    {
        Task AddAsync(Appliance appliance);
        Task<Appliance> FindByIdAsync(long id);
        Task<IEnumerable<Appliance>> FindByClientIdAsync(long clientId);
        void Update(Appliance appliance);
        void Remove(Appliance appliance);
    }
}
