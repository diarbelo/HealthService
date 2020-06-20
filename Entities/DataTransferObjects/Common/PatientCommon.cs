using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Common
{
    public abstract class PatientCommon
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(60, ErrorMessage = "Last name can't be longer than 60 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Adress is required")]
        [StringLength(100, ErrorMessage = "Adress can't be longer than 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(25, ErrorMessage = "Phone number can't be longer than 25 characters")]
        public string PhoneNumber { get; set; }
    }
}
