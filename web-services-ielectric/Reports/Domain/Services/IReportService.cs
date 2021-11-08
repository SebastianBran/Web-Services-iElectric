using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<ReportResponse> GetByIdAsync(long id);
        Task<ReportResponse> SaveAsync(Report report);
        Task<ReportResponse> UpdateAsync(long id, Report report);
        Task<ReportResponse> DeleteAsync(long id);

    }
}
