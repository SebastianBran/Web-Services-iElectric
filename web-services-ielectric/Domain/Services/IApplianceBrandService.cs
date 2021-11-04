using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IApplianceBrandService
    {
        Task<IEnumerable<ApplianceBrand>> ListAsync();
        Task<ApplianceBrandResponse> GetByIdAsync(long id);
        Task<ApplianceBrandResponse> SaveAsync(ApplianceBrand applianceBrand);
        Task<ApplianceBrandResponse> UpdateAsync(long id, ApplianceBrand applianceBrand);
        Task<ApplianceBrandResponse> DeleteAsync(long id);
    }
}