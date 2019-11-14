using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystemMangment.Models.Entites
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public string Image { get; set; }

        [StringLength(15, MinimumLength = 11, ErrorMessage = "Please Enter A Valid Phone Number")]
        public string Phone { get; set; }

        public decimal? Salary { get; set; }

        public bool? Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public Employee employee { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email Addreess")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        //[ForeignKey("employee")]
        //public int? SuperId { get; set; }



        //public virtual Department Department { get; set; }

        //[ForeignKey("Department")]
        //public int? DepartmentID { get; set; }
    }
}