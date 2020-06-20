using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
