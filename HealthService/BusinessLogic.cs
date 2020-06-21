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

            foreach (var item in patientIdentity.Appointments)
            {             
                if (item.Date.Date == appointmentDate.Date)
                {
                    return false; 
                }
            }

            return true;

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
