using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Services
{
    public class ApplianceModelService:IApplianceModelService
    {
        private readonly IApplianceModelRepository _applianceModelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplianceModelService(IApplianceModelRepository applianceModelRepository, IUnitOfWork unitOfWork)
        {
            _applianceModelRepository = applianceModelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ApplianceModel>> ListAsync()
        {
            return await _applianceModelRepository.ListAsync();
        }

        public async Task<ApplianceModelResponse> GetByIdAsync(long id)
        {
            var existingApplianceModel = await _applianceModelRepository.FindByIdAsync(id);
            return existingApplianceModel == null ? new ApplianceModelResponse("ApplianceModel not found.") : new ApplianceModelResponse(existingApplianceModel);
        }

        public async Task<ApplianceModelResponse> SaveAsync(ApplianceModel applianceModel)
        {
            try
            {
                await _applianceModelRepository.AddAsync(applianceModel);
                await _unitOfWork.CompleteAsync();
                return new ApplianceModelResponse(applianceModel);
            }
            catch (Exception e)
            {
                return new ApplianceModelResponse($"An error occurred while saving applianceModel: {e.Message}.");
            }
        }

        public async Task<ApplianceModelResponse> UpdateAsync(long id, ApplianceModel applianceModel)
        {
            var existingApplianceModel = await _applianceModelRepository.FindByIdAsync(id);
            if (existingApplianceModel == null)
                return new ApplianceModelResponse("ApplianceModel not found.");
            existingApplianceModel.Name = applianceModel.Name;
            existingApplianceModel.Model = applianceModel.Model;
            existingApplianceModel.ImgPath = applianceModel.ImgPath;
            existingApplianceModel.PurchaseDate = applianceModel.PurchaseDate;
            existingApplianceModel.ApplianceBrandId = applianceModel.ApplianceBrandId;
            existingApplianceModel.ClientId = applianceModel.ClientId;
            try
            {
                _applianceModelRepository.Update(existingApplianceModel);
                await _unitOfWork.CompleteAsync();
                return new ApplianceModelResponse(existingApplianceModel);
            }
            catch (Exception e)
            {
                return new ApplianceModelResponse($"An error occurred while updating the applianceModel:{e.Message}");
            }
        }

        public async Task<ApplianceModelResponse> DeleteAsync(long id)
        {
            var existingApplianceModel = await _applianceModelRepository.FindByIdAsync(id);
            if (existingApplianceModel == null)
                return new ApplianceModelResponse("ApplianceModel not found.");
            try
            {
                _applianceModelRepository.Remove(existingApplianceModel);
                await _unitOfWork.CompleteAsync();
                return new ApplianceModelResponse(existingApplianceModel);
            }
            catch(Exception e)
            {
                return new ApplianceModelResponse($"An error occurred while deleting the applianceModel: {e.Message}.");
            }
        }
    }
}