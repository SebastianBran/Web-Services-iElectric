using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> ListAsync();
        Task AddAsync(Report report);
        Task<Report> FindByIdAsync(long id);
        void Update(Report report);
        void Remove(Report report);

    }
}
