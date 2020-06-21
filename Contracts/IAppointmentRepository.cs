using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> AppointmentsByPatient(int patientId);
        Task<Appointment> GetAppointmentByIdAsync(Guid appointmentId);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
    }
}
