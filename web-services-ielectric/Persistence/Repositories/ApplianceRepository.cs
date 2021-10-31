using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class ApplianceRepository:BaseRepository,IApplianceRepository
    {
        public ApplianceRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Appliance>> ListAsync()
        {
           return await _context.Appliances.ToListAsync();
        }

        public async Task AddAsync(Appliance appliance)
        {
            await _context.Appliances.AddAsync(appliance);
        }

        public async Task<Appliance> FindByIdAsync(long id)
        {
            return await _context.Appliances.FindAsync(id);
        }

        public void Update(Appliance appliance)
        {
            _context.Appliances.Update(appliance);
        }

        public void Remove(Appliance appliance)
        {
            _context.Appliances.Remove(appliance);
        }
    }
}