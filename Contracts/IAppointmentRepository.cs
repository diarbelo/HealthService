﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> AppointmentsByPatient(int patientId);
        Appointment GetAppointmentById(Guid appointmentId);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
    }
}
