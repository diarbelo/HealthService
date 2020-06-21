using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HealthService
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IRepositoryWrapper _repository;

        public BusinessLogic(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task<bool> CanAddAsync(int patientId, DateTime appointmentDate)
        {
            var patientIdentity = await _repository.Patient.GetPatientWithDetailsAsync(patientId);

            if (!patientIdentity.Appointments.Select(x => x.Date.Date == appointmentDate.Date).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanCancel(DateTime appointmentDate)
        {
            var hours = (appointmentDate - DateTime.Now).TotalHours;

            if (hours > 24)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
