using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorProject.Models
{
    [Table("Tbl_Student")]
    public class StudentModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NIC { get; set; }
        [Required(ErrorMessage ="Please provide a valid Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
