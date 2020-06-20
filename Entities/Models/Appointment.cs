using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AppointmentId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date of appointment is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Appointment type is required")]
        public string AppointmentType { get; set; }

        [Required]
        public bool Active { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
