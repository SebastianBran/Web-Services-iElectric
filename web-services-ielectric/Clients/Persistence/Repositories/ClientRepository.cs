using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<Client> FindByIdAsync(long id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> FindByUserIdAsync(long userId)
        {
            return await _context.Clients
                .Where(p => p.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public void Remove(Client client)
        {
            _context.Clients.Remove(client);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}
