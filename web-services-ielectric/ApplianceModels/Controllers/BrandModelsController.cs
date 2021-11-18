using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Resources;

namespace web_services_ielectric.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/v1/applianceBrand/{applianceBrandId}/applianceModels")]
    public class BrandModelsController:ControllerBase
    {
        private readonly IApplianceModelService _applianceModelService;
        private readonly Mapper _mapper;

        public BrandModelsController(IApplianceModelService applianceModelService, Mapper mapper)
        {
            _applianceModelService = applianceModelService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get ApplianceModels by ApplianceBrandId",
            Description = "Get ApplianceModels by ApplianceBrandId",
            OperationId = "GetApplianceModelsByApplianceBrandId")]
        [SwaggerResponse(200, "ApplianceModels returned", typeof(ApplianceModelResource))]
        [HttpGet]
        [ProducesResponseType(typeof(ApplianceModelResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<ApplianceModelResource>> GetAllByApplianceBrandIdAsync(int applianceBrandId)
        {
            var applianceModels = await _applianceModelService.ListByApplianceBrandIdAsync(applianceBrandId);
            var resources =
                _mapper.Map<IEnumerable<ApplianceModel>, IEnumerable<ApplianceModelResource>>(applianceModels);
            return resources;
        }

    }
}