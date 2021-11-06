using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface ISpareRequestService
    {
        Task<IEnumerable<SpareRequest>> ListAsync();
        Task<SpareRequestResponse> GetByIdAsync(long id);
        Task<SpareRequestResponse> SaveAsync(SpareRequest spareRequest);
        Task<SpareRequestResponse> UpdateAsync(long id, SpareRequest spareRequest);
        Task<SpareRequestResponse> DeleteAsync(long id);
    }
}
