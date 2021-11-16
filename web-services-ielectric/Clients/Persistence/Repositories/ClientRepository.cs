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
        public async Task<Client> FindByPlanIdAsync(long clientId, long planId)
        {
            return await _context.Clients.FindAsync(planId);
        }
        public async Task AssingUserPlan(long clientId, long planId)
        {
            Client client = await FindByPlanIdAsync(clientId, planId);
            if (client==null)
            {
                client = new Client { Id = clientId, PlanId = planId };
                await AddAsync(client);
            }
        }
        public async void UnassingUserPlan(long clientId, long planId)
        {
            Client client = await FindByPlanIdAsync(clientId, planId);
            if (client != null)
            {
                Remove(client);
            }
        }
    }
}
