﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
    public class AppointmentsController: ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "Get all Appointments",
        Description = "Get of all Appointments",
        OperationId = "GetAllAppointments")]
        [SwaggerResponse(200, "All Appointments returned", typeof(IEnumerable<AppointmentResource>))]


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppointmentResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
        {
            var appointments = await _appointmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }

        [SwaggerOperation(
        Summary = "Get Appointment by Id",
        Description = "Get Appointment by Id",
        OperationId = "GetAppointmentById")]
        [SwaggerResponse(200, "Appointment returned", typeof(AppointmentResource))]

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppointmentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await _appointmentService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

            return Ok(appointmentResource);
        }

        [SwaggerOperation(
        Summary = "Save Appointment",
        Description = "Save Appointment",
        OperationId = "SaveAppointment")]
        [SwaggerResponse(200, "Appointment saved", typeof(AppointmentResource))]

        [HttpPost]
        [ProducesResponseType(typeof(AppointmentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.SaveAsync(appointment);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

            return Ok(appointmentResource);
        }

        [SwaggerOperation(
        Summary = "Update Appointment",
        Description = "Update Appointment",
        OperationId = "UpdateAppointment")]
        [SwaggerResponse(200, "Appointment updated", typeof(AppointmentResource))]

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AppointmentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.UpdateAsync(id, appointment);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }

        [SwaggerOperation(
        Summary = "Delete Appointment",
        Description = "Delete Appointment",
        OperationId = "DeleteAppointment")]
        [SwaggerResponse(200, "Appointment deleted", typeof(AppointmentResource))]

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AppointmentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _appointmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

            return Ok(appointmentResource);
        }
    }
}
