using ASPTask5.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTask5.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        [MaxLength(30)]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        [Range(0,100)]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Группа")]
        [MaxLength(20)]
        public String Group { get; set; }

        [MaxLength(25)]
        public String AdditionalSecretString { get; set; }
       
    }
}
