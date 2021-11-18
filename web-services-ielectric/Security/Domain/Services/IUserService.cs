using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Security.Domain.Entities;
using web_services_ielectric.Security.Domain.Services.Communication;

namespace web_services_ielectric.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(long id);
        User GetById(long id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(long id, UpdateRequest request);
        Task DeleteAsync(long id);
    }
}
