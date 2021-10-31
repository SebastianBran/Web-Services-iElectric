using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task<AnnouncementResponse> GetByIdAsync(long id);
        Task<AnnouncementResponse> SaveAsync(Announcement announcement);
        Task<AnnouncementResponse> UpdateAsync(long id, Announcement announcement);
        Task<AnnouncementResponse> DeleteAsync(long id);
    }
}
