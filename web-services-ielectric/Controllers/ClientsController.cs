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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var clients = await _clientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _clientService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResult = _mapper.Map<Client, ClientResource>(result.Resource);

            return Ok(clientResult);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.SaveAsync(client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

            return Ok(clientResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.UpdateAsync(id, client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _clientService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

            return Ok(clientResource);
        } 
    }
}
