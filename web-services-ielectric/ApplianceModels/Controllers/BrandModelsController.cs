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
        private readonly IMapper _mapper;

        public BrandModelsController(IApplianceModelService applianceModelService, IMapper mapper)
        {
            _applianceModelService = applianceModelService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get ApplianceModels by ApplianceBrandId",
            Description = "Get ApplianceModels by ApplianceBrandId",
            OperationId = "GetApplianceModelsByApplianceBrandId")]
        [SwaggerResponse(200, "ApplianceModels returned", typeof(IEnumerable<ApplianceModelResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplianceModelResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<ApplianceModelResource>> GetAllByApplianceBrandIdAsync(long applianceBrandId)
        {
            var applianceModels = await _applianceModelService.ListByApplianceBrandIdAsync(applianceBrandId);
            var resources =
                _mapper.Map<IEnumerable<ApplianceModel>, IEnumerable<ApplianceModelResource>>(applianceModels);
            return resources;
        }

    }
}