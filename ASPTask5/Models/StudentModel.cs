using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTask5.Models
{
    public class StudentModel
    {
        [Required]
        [Display(Name = "Имя")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Группа")]
        public String Group { get; set; }
    }
}
