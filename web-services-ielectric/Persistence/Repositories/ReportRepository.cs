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
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Report report)
        {
            await _context.Reports.AddAsync(report);
        }

        public async Task<Report> FindByIdAsync(long id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<Report>> ListAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public void Remove(Report report)
        {
            _context.Reports.Remove(report);
        }

        public void Update(Report report)
        {
            _context.Reports.Update(report);
        }
    }
}
