using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Persistence.Contexts;
using web_services_ielectric.Persistence.Repositories;
using web_services_ielectric.Security.Domain.Entities;
using web_services_ielectric.Security.Domain.Repositories;

namespace web_services_ielectric.Security.Persistance.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
