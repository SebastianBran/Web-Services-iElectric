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
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
