using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task AddAsync(Announcement announcement);
        Task<Announcement> FindByIdAsync(long id);
        void Update(Announcement announcement);
        void Remove(Announcement announcement);
    }
}
