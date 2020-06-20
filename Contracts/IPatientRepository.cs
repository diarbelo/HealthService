using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();

        Patient GetPatientById(int patientId);

        Patient GetPatientWithDetails(int patientId);

        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
