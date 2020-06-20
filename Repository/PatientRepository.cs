using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return FindAll()
                .OrderBy(pt => pt.LastName)
                .ToList();
        }

        public Patient GetPatientById(int patientId)
        {
            return FindByCondition(pt => pt.Id.Equals(patientId)).FirstOrDefault();
        }

        public Patient GetPatientWithDetails(int patientId)
        {
            return FindByCondition(pt => pt.Id.Equals(patientId))
                .Include(ap => ap.Appointments)
                .FirstOrDefault();
        }

        public void CreatePatient(Patient patient)
        {
            Create(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            Update(patient);
        }

        public void DeletePatient(Patient patient)
        {
            Delete(patient);
        }
    }
}
