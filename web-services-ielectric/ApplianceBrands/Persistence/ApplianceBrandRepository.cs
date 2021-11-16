using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class ApplianceBrandRepository:BaseRepository,IApplianceBrandRepository
    {
        public ApplianceBrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApplianceBrand>> ListAsync()
        {
            return await _context.ApplianceBrands.ToListAsync();
        }

        public async Task AddAsync(ApplianceBrand applianceBrand)
        {
            await _context.ApplianceBrands.AddAsync(applianceBrand);
        }

        public async Task<ApplianceBrand> FindByIdAsync(long id)
        {
            return await _context.ApplianceBrands.FindAsync(id);
        }

        public void Update(ApplianceBrand applianceBrand)
        {
            _context.ApplianceBrands.Update(applianceBrand);
        }

        public void Remove(ApplianceBrand applianceBrand)
        {
            _context.ApplianceBrands.Remove(applianceBrand);
        }
    }
}