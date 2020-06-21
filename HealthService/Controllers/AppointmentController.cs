using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthService.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IBusinessLogic _businessLogic;

        public AppointmentController(IRepositoryWrapper repository, IMapper mapper, IBusinessLogic businessLogic)
        {
            _repository = repository;
            _mapper = mapper;
            _businessLogic = businessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody]AppointmentForCreationDTO appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("Appointment object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var canAdd = await _businessLogic.CanAddAsync(appointment.PatientId, appointment.Date);

                if (!canAdd)
                {
                    return BadRequest("You cannot create another appointment for the same patient on the same day.");
                }

                var appointmentEntity = _mapper.Map<Appointment>(appointment);

                appointmentEntity.Active = true;

                _repository.Appointment.AddAppointment(appointmentEntity);
                await _repository.SaveAsync();

                var createdAppointment = _mapper.Map<AppointmentDTO>(appointmentEntity);

                return Ok(createdAppointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CancelAppointment(Guid id)
        {
            try
            {
                var appointmentEntity = await _repository.Appointment.GetAppointmentByIdAsync(id);
                if (appointmentEntity == null)
                {
                    return NotFound();
                }

                if (!_businessLogic.CanCancel(appointmentEntity.Date))
                {
                    return BadRequest($"Appointments must be canceled at least 24 hours in advance; appointment date: {appointmentEntity.Date}");
                }

                appointmentEntity.Active = false;

                _repository.Appointment.UpdateAppointment(appointmentEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}