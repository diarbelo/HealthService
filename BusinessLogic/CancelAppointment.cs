using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CancelAppointment : ICancelAppointment
    {
        public bool CanCancel(DateTime appointmentDate)
        {
            if (DateTime.Now.Subtract(Convert.ToDateTime(appointmentDate)).TotalHours > 24)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
