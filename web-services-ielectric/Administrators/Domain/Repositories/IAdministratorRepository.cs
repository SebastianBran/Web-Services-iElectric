using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<Administrator>> ListAsync();
        Task AddAsync(Administrator administrator);
        Task<Administrator> FindByIdAsync(long id);
        Task<Administrator> FindByUserIdAsync(long userId);
        void Update(Administrator administrator);
        void Remove(Administrator administrator);
    }
}