using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient> GetPatientByIdAsync(int patientId);

        Task<Patient> GetPatientWithDetailsAsync(int patientId);

        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
