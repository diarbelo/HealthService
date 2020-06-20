using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPatientRepository Patient { get; }
        IAppointmentRepository Appointment { get; }
        void Save();
    }
}
