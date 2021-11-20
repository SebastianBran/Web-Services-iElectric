using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task<Client> FindByIdAsync(long id);
        Task<Client> FindByUserIdAsync(long userId);
        void Update(Client client);
        void Remove(Client client);
    }
}
