using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Extensions;
using web_services_ielectric.Resources;

namespace web_services_ielectric.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ApplianceModelController:ControllerBase
    {
        private readonly IApplianceModelService _applianceModelService;
        private readonly IMapper _mapper;

        public ApplianceModelController(IApplianceModelService applianceModelService, IMapper mapper)
        {
            _applianceModelService = applianceModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplianceModelResource>> GetAllAsync()
        {
            var applianceModels = await _applianceModelService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ApplianceModel>, IEnumerable<ApplianceModelResource>>(applianceModels);
            return resources;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _applianceModelService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceModelResult = _mapper.Map<ApplianceModel, ApplianceModelResource>(result.Resource);

            return Ok(applianceModelResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApplianceModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var applianceModel = _mapper.Map<SaveApplianceModelResource, ApplianceModel>(resource);
            var result = await _applianceModelService.SaveAsync(applianceModel);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceModelResource = _mapper.Map<ApplianceModel, ApplianceModelResource>(result.Resource);
            return Ok(applianceModelResource); 
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveApplianceModelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var applianceModel = _mapper.Map<SaveApplianceModelResource, ApplianceModel>(resource);
            var result = await _applianceModelService.UpdateAsync(id, applianceModel);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceModelResource = _mapper.Map<ApplianceModel, ApplianceModelResource>(result.Resource);
            return Ok(applianceModelResource);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _applianceModelService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceModelResource = _mapper.Map<ApplianceModel, ApplianceModelResource>(result.Resource);
            return Ok(applianceModelResource);
        }

    }
}