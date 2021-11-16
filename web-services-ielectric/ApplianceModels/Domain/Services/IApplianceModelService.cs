﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services.Communication;

namespace web_services_ielectric.Domain.Services
{
    public interface IApplianceModelService
    {
        Task<IEnumerable<ApplianceModel>> ListAsync();
        Task<IEnumerable<ApplianceModel>> ListByApplianceBrandIdAsync(long applianceBrandId);
        Task<ApplianceModelResponse> GetByIdAsync(long id);
        Task<ApplianceModelResponse> SaveAsync(ApplianceModel applianceModel);
        Task<ApplianceModelResponse> UpdateAsync(long id, ApplianceModel applianceModel);
        Task<ApplianceModelResponse> DeleteAsync(long id);
    }
}