using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await FindAll()
                .OrderBy(pt => pt.LastName)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await FindByCondition(pt => pt.Id.Equals(patientId)).FirstOrDefaultAsync();
        }

        public async Task<Patient> GetPatientWithDetailsAsync(int patientId)
        {
            return await FindByCondition(pt => pt.Id.Equals(patientId))
                .Include(ap => ap.Appointments)
                .FirstOrDefaultAsync();
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
