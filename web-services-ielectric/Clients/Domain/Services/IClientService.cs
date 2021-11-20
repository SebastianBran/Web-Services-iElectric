using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> GetByIdAsync(long id);
        Task<ClientResponse> GetByUserIdAsync(long userId);
        Task<ClientResponse> SaveAsync(Client client);
        Task<ClientResponse> UpdateAsync(long id, Client client);
        Task<ClientResponse> DeleteAsync(long id);
        Task<ClientResponse> UpdateUserPlanAsync(long clientId, long planId);
    }
}