using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPatientRepository _patient;
        private IAppointmentRepository _appointment;

        public IPatientRepository Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientRepository(_repoContext);
                }

                return _patient;
            }
        }

        public IAppointmentRepository Appointment
        {
            get 
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentRepository(_repoContext);
                }

                return _appointment;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
           await _repoContext.SaveChangesAsync();
        }
    }
}
