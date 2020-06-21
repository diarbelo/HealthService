using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBusinessLogic
    {
        bool CanCancel(DateTime appointmentDate);
        Task<bool> CanAddAsync(int patientId, DateTime appointmentDate);
    }
}
