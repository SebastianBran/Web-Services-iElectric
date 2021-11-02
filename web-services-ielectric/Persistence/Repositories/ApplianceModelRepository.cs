using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class ApplianceModelRepository:BaseRepository,IApplianceModelRepository
    {
        public ApplianceModelRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ApplianceModel>> ListAsync()
        {
           return await _context.ApplianceModels.ToListAsync();
        }

        public async Task AddAsync(ApplianceModel applianceModel)
        {
            await _context.ApplianceModels.AddAsync(applianceModel);
        }

        public async Task<ApplianceModel> FindByIdAsync(long id)
        {
            return await _context.ApplianceModels.FindAsync(id);
        }

        public void Update(ApplianceModel applianceModel)
        {
            _context.ApplianceModels.Update(applianceModel);
        }

        public void Remove(ApplianceModel applianceModel)
        {
            _context.ApplianceModels.Remove(applianceModel);
        }
    }
}