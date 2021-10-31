using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IApplianceRepository
    {
        Task<IEnumerable<Appliance>> ListAsync();
        Task AddAsync(Appliance appliance);
        Task<Appliance> FindByIdAsync(long id);
        void Update(Appliance appliance);
        void Remove(Appliance appliance);
    }
}