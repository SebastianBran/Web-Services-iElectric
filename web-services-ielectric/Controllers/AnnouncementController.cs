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
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcement, IMapper mapper)
        {
            _announcementService = announcement;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AnnouncementResource>> GetAllAsync()
        {
            var announcementes = await _announcementService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(announcementes);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getByIdAsync(long id)
        {
            var result = await _announcementService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResult = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAnnouncementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var announcement = _mapper.Map<SaveAnnouncementResource, Announcement>(resource);
            var result = await _announcementService.SaveAsync(announcement);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveAnnouncementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var announcement = _mapper.Map<SaveAnnouncementResource, Announcement>(resource);
            var result = await _announcementService.UpdateAsync(id, announcement);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _announcementService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }
    }
}
