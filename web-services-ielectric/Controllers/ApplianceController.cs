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
    public class ApplianceController:ControllerBase
    {
        private readonly IApplianceService _applianceService;
        private readonly IMapper _mapper;

        public ApplianceController(IApplianceService applianceService, IMapper mapper)
        {
            _applianceService = applianceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplianceResource>> GetAllAsync()
        {
            var appliances = await _applianceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Appliance>, IEnumerable<ApplianceResource>>(appliances);
            return resources;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _applianceService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceResult = _mapper.Map<Appliance, ApplianceResource>(result.Resource);

            return Ok(applianceResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApplianceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var appliance = _mapper.Map<SaveApplianceResource, Appliance>(resource);
            var result = await _applianceService.SaveAsync(appliance);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceResource = _mapper.Map<Appliance, ApplianceResource>(result.Resource);
            return Ok(applianceResource); 
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveApplianceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var appliance = _mapper.Map<SaveApplianceResource, Appliance>(resource);
            var result = await _applianceService.UpdateAsync(id, appliance);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceResource = _mapper.Map<Appliance, ApplianceResource>(result.Resource);
            return Ok(applianceResource);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _applianceService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceResource = _mapper.Map<Appliance, ApplianceResource>(result.Resource);
            return Ok(applianceResource);
        }

    }
}