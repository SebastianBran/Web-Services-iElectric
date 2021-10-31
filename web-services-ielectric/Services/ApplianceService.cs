using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Services
{
    public class ApplianceService:IApplianceService
    {
        private readonly IApplianceRepository _applianceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplianceService(IApplianceRepository applianceRepository, IUnitOfWork unitOfWork)
        {
            _applianceRepository = applianceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appliance>> ListAsync()
        {
            return await _applianceRepository.ListAsync();
        }

        public async Task<ApplianceResponse> GetByIdAsync(long id)
        {
            var existingAppliance = await _applianceRepository.FindByIdAsync(id);
            return existingAppliance == null ? new ApplianceResponse("Appliance not found.") : new ApplianceResponse(existingAppliance);
        }

        public async Task<ApplianceResponse> SaveAsync(Appliance appliance)
        {
            try
            {
                await _applianceRepository.AddAsync(appliance);
                await _unitOfWork.CompleteAsync();
                return new ApplianceResponse(appliance);
            }
            catch (Exception e)
            {
                return new ApplianceResponse($"An error occurred while saving appliance: {e.Message}.");
            }
        }

        public async Task<ApplianceResponse> UpdateAsync(long id, Appliance appliance)
        {
            var existingAppliance = await _applianceRepository.FindByIdAsync(id);
            if (existingAppliance == null)
                return new ApplianceResponse("Appliance not found.");
            existingAppliance.ClientId = appliance.ClientId;
            existingAppliance.ApplianceModelId = appliance.ApplianceModelId;
            existingAppliance.PurchaseDate = appliance.PurchaseDate;
            try
            {
                _applianceRepository.Update(existingAppliance);
                await _unitOfWork.CompleteAsync();
                return new ApplianceResponse(existingAppliance);
            }
            catch (Exception e)
            {
                return new ApplianceResponse($"An error occurred while updating the appliance:{e.Message}");
            }
        }

        public async Task<ApplianceResponse> DeleteAsync(long id)
        {
            var existingAppliance = await _applianceRepository.FindByIdAsync(id);
            if (existingAppliance == null)
                return new ApplianceResponse("Appliance not found.");
            try
            {
                _applianceRepository.Remove(existingAppliance);
                await _unitOfWork.CompleteAsync();
                return new ApplianceResponse(existingAppliance);
            }
            catch(Exception e)
            {
                return new ApplianceResponse($"An error occurred while deleting the appliance: {e.Message}.");
            }
        }
    }
}