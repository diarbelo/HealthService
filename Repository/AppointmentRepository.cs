using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Appointment GetAppointmentById(Guid appointmentId)
        {
            return FindByCondition(ap => ap.Id.Equals(appointmentId)).FirstOrDefault();
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
