using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRespository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IReportRepository reportRespository, IUnitOfWork unitOfWork)
        {
            _reportRespository = reportRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse> DeleteAsync(long id)
        {
            var existingReport = await _reportRespository.FindByIdAsync(id);

            if (existingReport == null)
                return new ReportResponse("Report not found.");

            try
            {
                _reportRespository.Remove(existingReport);
                await _unitOfWork.CompleteAsync();

                return new ReportResponse(existingReport);
            }
            catch (Exception e)
            {
                return new ReportResponse($"An error occurred while deleting the report: {e.Message}");
            }
        }

        public async Task<ReportResponse> GetByIdAsync(long id)
        {
            var existingReport = await _reportRespository.FindByIdAsync(id);

            if (existingReport == null)
                return new ReportResponse("Report not found.");

            return new ReportResponse(existingReport);
        }

        public async Task<IEnumerable<Report>> ListAsync()
        {
            return await _reportRespository.ListAsync();

        }

        public async Task<ReportResponse> SaveAsync(Report report)
        {
            try
            {
                await _reportRespository.AddAsync(report);
                await _unitOfWork.CompleteAsync();

                return new ReportResponse(report);
            }
            catch (Exception e)
            {
                return new ReportResponse($"An error occurred while saving the report: {e.Message}");
            }
        }

        public async Task<ReportResponse> UpdateAsync(long id, Report report)
        {
            var existingReport = await _reportRespository.FindByIdAsync(id);

            if (existingReport == null)
                return new ReportResponse("Report not found.");

            existingReport.Observation = report.Observation;
            existingReport.Diagnosis = report.Diagnosis;
            existingReport.RepairDescription = report.RepairDescription;
            existingReport.Date = report.Date;
            existingReport.ImagePath = report.ImagePath;

            try
            {
                _reportRespository.Update(existingReport);
                await _unitOfWork.CompleteAsync();

                return new ReportResponse(existingReport);
            }
            catch (Exception e)
            {
                return new ReportResponse($"An error occurred while updating the report: {e.Message}");
            }
        }
    }
}
