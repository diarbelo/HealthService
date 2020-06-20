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

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            try
            {
                var patients = _repository.Patient.GetAllPatients();

                var patientsResult = _mapper.Map<IEnumerable<PatientDTO>>(patients);

                return Ok(patientsResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PatientById")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientById(id);

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
        public IActionResult GetPatientWithDetails(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientWithDetails(id);

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
        public IActionResult CreatePatient([FromBody]PatientForCreationDTO patient)
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

                var patientEntity = _mapper.Map<Patient>(patient);

                _repository.Patient.CreatePatient(patientEntity);
                _repository.Save();

                var createdPatient = _mapper.Map<PatientDTO>(patientEntity);

                return CreatedAtRoute("PatientById", new { id = createdPatient.Id }, createdPatient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody]PatientForUpdateDTO patient)
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

                var patientEntity = _repository.Patient.GetPatientById(id);
                if (patientEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(patient, patientEntity);

                _repository.Patient.UpdatePatient(patientEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound();
                }

                if (_repository.Appointment.AppointmentsByPatient(id).Any())
                {
                    return BadRequest($"cannot delete information for the patient: {patient.Name} {patient.LastName} has appointments assigned, contact at number: {patient.PhoneNumber} for cancellation");
                }

                _repository.Patient.DeletePatient(patient);
                _repository.Save();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}