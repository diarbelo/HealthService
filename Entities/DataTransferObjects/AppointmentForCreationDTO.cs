using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AppointmentForCreationDTO
    {
        [Required(ErrorMessage = "Date of appointment is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Appointment type is required")]
        public string AppointmentType { get; set; }

        [Required(ErrorMessage = "Patient is required")]
        public int PatientId { get; set; }
    }
}
