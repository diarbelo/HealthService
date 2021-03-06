﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPatientRepository Patient { get; }
        IAppointmentRepository Appointment { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
