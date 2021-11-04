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
    public class ApplianceBrandController:ControllerBase
    {
        private readonly IApplianceBrandService _applianceBrandService;
        private readonly IMapper _mapper;

        public ApplianceBrandController(IApplianceBrandService applianceBrandService, IMapper mapper)
        {
            _applianceBrandService = applianceBrandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplianceBrandResource>> GetAllAsync()
        {
            var applianceBrands = await _applianceBrandService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ApplianceBrand>, IEnumerable<ApplianceBrandResource>>(applianceBrands);
            return resources;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _applianceBrandService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceBrandResult = _mapper.Map<ApplianceBrand, ApplianceBrandResource>(result.Resource);

            return Ok(applianceBrandResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApplianceBrandResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var applianceBrand = _mapper.Map<SaveApplianceBrandResource, ApplianceBrand>(resource);
            var result = await _applianceBrandService.SaveAsync(applianceBrand);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceBrandResource = _mapper.Map<ApplianceBrand, ApplianceBrandResource>(result.Resource);
            return Ok(applianceBrandResource); 
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveApplianceBrandResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var applianceBrand = _mapper.Map<SaveApplianceBrandResource, ApplianceBrand>(resource);
            var result = await _applianceBrandService.UpdateAsync(id, applianceBrand);
            if (!result.Success)
                return BadRequest(result.Message);

            var applianceBrandResource = _mapper.Map<ApplianceBrand, ApplianceBrandResource>(result.Resource);
            return Ok(applianceBrandResource);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _applianceBrandService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var applianceBrandResource = _mapper.Map<ApplianceBrand, ApplianceBrandResource>(result.Resource);
            return Ok(applianceBrandResource);
        }

    }
}