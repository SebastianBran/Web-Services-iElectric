using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Extensions;
using web_services_ielectric.Resources;

namespace web_services_ielectric.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianService _technicianService;
        private readonly IMapper _mapper;

        public TechniciansController(ITechnicianService technicianService, IMapper mapper)
        {
            _technicianService = technicianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TechnicianResource>> GetAllAsync()
        {
            var technicians = await _technicianService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Technician>, IEnumerable<TechnicianResource>>(technicians);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsyn(long id)
        {
            var result = await _technicianService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var technicianResult = _mapper.Map<Technician, TechnicianResource>(result.Resource);

            return Ok(technicianResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTechnicianResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var technician = _mapper.Map<SaveTechnicianResource, Technician>(resource);
            var result = await _technicianService.SaveAsync(technician);

            if (!result.Success)
                return BadRequest(result.Message);

            var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);

            return Ok(technicianResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveTechnicianResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var technician = _mapper.Map<SaveTechnicianResource, Technician>(resource);
            var result = await _technicianService.UpdateAsync(id, technician);

            if (!result.Success)
                return BadRequest(result.Message);

            var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);

            return Ok(technicianResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _technicianService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);

            return Ok(technicianResource);
        }
    }
}
