using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IApplianceModelRepository
    {
        Task<IEnumerable<ApplianceModel>> ListAsync();
        Task AddAsync(ApplianceModel appliance);
        Task<ApplianceModel> FindByIdAsync(long id);
        Task<IEnumerable<ApplianceModel>> FindByApplianceBrandId(long applianceBrandId);
        void Update(ApplianceModel appliance);
        void Remove(ApplianceModel appliance);
    }
}