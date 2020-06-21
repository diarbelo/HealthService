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
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Appointment> AppointmentsByPatient(int patientId)
        {
            return FindByCondition(ap => ap.PatientId.Equals(patientId)).ToList();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid appointmentId)
        {
            return await FindByCondition(ap => ap.Id.Equals(appointmentId)).FirstOrDefaultAsync();
        }

        public void AddAppointment(Appointment appointment)
        {
            Create(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            Update(appointment);
        }
    }
}
