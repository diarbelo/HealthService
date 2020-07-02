using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(80, ErrorMessage = "Mail can't be longer than 80 characters")]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Rol is required")]
        public string UserRol { get; set; }
    }
}
