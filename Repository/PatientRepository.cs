using Contracts;
using Entities;
using Entities.Models;
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
    }
}
