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
    public class AnnouncementRepository : BaseRepository, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcements.AddAsync(announcement);
        }

        public async Task<Announcement> FindByIdAsync(long id)
        {
            return await _context.Announcements.FindAsync(id);
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public void Remove(Announcement announcement)
        {
            _context.Announcements.Remove(announcement);
        }

        public void Update(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
        }
    }
}
