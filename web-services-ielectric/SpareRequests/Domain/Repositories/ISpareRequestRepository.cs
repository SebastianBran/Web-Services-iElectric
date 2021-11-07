using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface ISpareRequestRepository
    {
        Task<IEnumerable<SpareRequest>> ListAsync();
        Task AddAsync(SpareRequest spareRequest);
        Task<SpareRequest> FindByIdAsync(long id);
        void Update(SpareRequest spareRequest);
        void Remove(SpareRequest spareRequest);
    }
}
