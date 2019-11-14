using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystemMangment.Models.Entites
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Number Of Employees")]
        public int? NumberOfEmps { get; set; }

        public List<Employee> Employees { get; set; }

        //[ForeignKey("MangerId")]
        //public Manager Manager { get; set; }

        //public List<Employee> Employees { get; set; }

        //public virtual Employee Employee { get; set; }

        //[ForeignKey("Employee")]
        //public int? ManagerId { get; set; }
    }
}