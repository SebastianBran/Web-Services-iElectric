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
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class UserPlansController : ControllerBase
    {
        private readonly IUserPlanService _userPlanService;
        private readonly IMapper _mapper;

        public UserPlansController(IUserPlanService userPlanService, IMapper mapper)
        {
            _userPlanService = userPlanService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserPlanResource>), 200)]
        public async Task<IEnumerable<UserPlanResource>> GetAllAsync()
        {
            var userPlans = await _userPlanService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<UserPlan>, IEnumerable<UserPlanResource>>(userPlans);
            return resources;
        }

        [HttpPost("users/{userId}/plans/{planId}")]
        public async Task<IActionResult> AssignUserPlan(int userId, int planId, [FromBody] SaveUserPlanResource resource)
        {
            var result = await _userPlanService.AssignUserPlanAsync(userId, planId, resource.DateOfUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            var UserPlanResource = _mapper.Map<UserPlan, UserPlanResource>(result.Resource);
            return Ok(UserPlanResource);
        }

        [HttpDelete("users/{userId}/plans/{planId}")]
        public async Task<IActionResult> UnassignUserPlan(int userId, int planId, [FromBody] SaveUserPlanResource resource)
        {
            var result = await _userPlanService.UnassignUserPlanAsync(userId, planId, resource.DateOfUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            var UserPlanResource = _mapper.Map<UserPlan, UserPlanResource>(result.Resource);
            return Ok(UserPlanResource);
        }
    }
}