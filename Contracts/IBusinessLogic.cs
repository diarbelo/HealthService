using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IBusinessLogic
    {
        bool CanCancel(DateTime appointmentDate);
        bool CanAdd(int patientId, DateTime appointmentDate);
    }
}
