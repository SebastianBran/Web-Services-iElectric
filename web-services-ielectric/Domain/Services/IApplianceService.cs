using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IApplianceService
    {
        Task<IEnumerable<Appliance>> ListAsync();
        Task<ApplianceResponse> GetByIdAsync(long id);
        Task<ApplianceResponse> SaveAsync(Appliance appliance);
        Task<ApplianceResponse> UpdateAsync(long id, Appliance appliance);
        Task<ApplianceResponse> DeleteAsync(long id);
    }
}