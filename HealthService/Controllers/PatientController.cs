using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthService.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PatientController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //[HttpGet, Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _repository.Patient.GetAllPatientsAsync();

                var patientsResult = _mapper.Map<IEnumerable<PatientDTO>>(patients);

                return Ok(patientsResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PatientById")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _repository.Patient.GetPatientByIdAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }
                else
                {
                    var patientResult = _mapper.Map<PatientDTO>(patient);

                    return Ok(patientResult);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}/appointment")]
        public async Task<IActionResult> GetPatientWithDetails(int id)
        {
            try
            {
                var patient = await _repository.Patient.GetPatientWithDetailsAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }
                else
                {
                    var patientResult = _mapper.Map<PatientDTO>(patient);

                    return Ok(patientResult);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody]PatientForCreationDTO patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest("Patient object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var validatePatient = await _repository.Patient.GetPatientByIdAsync(patient.Id);
                if (validatePatient != null)
                {
                    return BadRequest($"The record {patient.Id} already exists");
                }

                var patientEntity = _mapper.Map<Patient>(patient);

                _repository.Patient.CreatePatient(patientEntity);
                await _repository.SaveAsync();

                var createdPatient = _mapper.Map<PatientDTO>(patientEntity);

                return CreatedAtRoute("PatientById", new { id = createdPatient.Id }, createdPatient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody]PatientForUpdateDTO patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest("Patient object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var patientEntity = await _repository.Patient.GetPatientByIdAsync(id);
                if (patientEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(patient, patientEntity);

                _repository.Patient.UpdatePatient(patientEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                var patient = await _repository.Patient.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    return NotFound();
                }

                if (_repository.Appointment.AppointmentsByPatient(id).Any())
                {
                    return BadRequest($"cannot delete information for the patient: {patient.Name} {patient.LastName} has appointments assigned, contact at number: {patient.PhoneNumber} for cancellation");
                }

                _repository.Patient.DeletePatient(patient);
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