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
    [Route("/api/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlansController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PlanResource>> GetAllAsync()
        {
            var plans = await _planService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _planService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.UpdateAsync(id, plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _planService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);

        }

    }
}