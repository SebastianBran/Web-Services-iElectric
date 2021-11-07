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
    public class SpareRequestRepository : BaseRepository, ISpareRequestRepository
    {
        public SpareRequestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(SpareRequest spareRequest)
        {
            await _context.SpareRequests.AddAsync(spareRequest);
        }

        public async Task<SpareRequest> FindByIdAsync(long id)
        {
            return await _context.SpareRequests.FindAsync(id);
        }

        public async Task<IEnumerable<SpareRequest>> ListAsync()
        {
            return await _context.SpareRequests.ToListAsync();
        }

        public void Remove(SpareRequest spareRequest)
        {
            _context.SpareRequests.Remove(spareRequest);
        }

        public void Update(SpareRequest spareRequest)
        {
            _context.SpareRequests.Update(spareRequest);
        }
    }
}
