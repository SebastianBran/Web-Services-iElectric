using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Security.Domain.Entities;

namespace web_services_ielectric.Security.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(long id);
        Task<User> FindByEmailAsync(string email);
        public bool ExistsByEmail(string email);
        User FindById(long id);
        void Update(User user);
        void Remove(User user);
    }
}
