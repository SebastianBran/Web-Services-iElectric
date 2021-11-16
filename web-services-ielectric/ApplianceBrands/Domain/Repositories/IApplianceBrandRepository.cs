using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IApplianceBrandRepository
    {
        Task<IEnumerable<ApplianceBrand>> ListAsync();
        Task AddAsync(ApplianceBrand applianceBrand);
        Task<ApplianceBrand> FindByIdAsync(long id);
        void Update(ApplianceBrand applianceBrand);
        void Remove(ApplianceBrand applianceBrand);
    }
}