﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class TechnicianRepository : BaseRepository, ITechnicianRepository
    {
        public TechnicianRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Technician technician)
        {
            await _context.Technicians.AddAsync(technician);
        }

        public async Task<Technician> FindByIdAsync(long id)
        {
            return await _context.Technicians.FindAsync(id);
        }

        public async Task<Technician> FindByUserIdAsync(long userId)
        {
            return await _context.Technicians
                .Where(p => p.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Technician>> ListAsync()
        {
            return await _context.Technicians.ToListAsync();
        }
        
        public async Task<IEnumerable<Report>> FindByTechnicianId(int technicianId)
        {
            return await _context.Reports
                .Where(p => p.TechnicianId == technicianId)
                .Include(p => p.Technician)
                .ToListAsync();
        }

        public void Remove(Technician technician)
        {
            _context.Technicians.Remove(technician);
        }

        public void Update(Technician technician)
        {
            _context.Technicians.Update(technician);
        }
    }
}
