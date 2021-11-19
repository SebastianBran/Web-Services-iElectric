using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Comunication;

namespace web_services_ielectric.Domain.Services
{
    public interface IApplianceService
    {
        Task<IEnumerable<Appliance>> ListByClientIdAsync(long clientId);
        Task<ApplianceResponse> GetByIdAsync(long id);
        Task<ApplianceResponse> SaveAsync(Appliance appliance);
        Task<ApplianceResponse> UpdateAsync(long id, Appliance appliance);
        Task<ApplianceResponse> DeleteAsync(long id);
    }
}
