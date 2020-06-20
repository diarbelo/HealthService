using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
