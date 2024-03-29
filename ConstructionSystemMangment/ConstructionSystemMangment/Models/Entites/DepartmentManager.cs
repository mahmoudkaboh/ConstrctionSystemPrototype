﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionSystemMangment.Models.Entites
{
    [Table(name:"Department Manager")]
    public class DepartmentManager
    {

        [Key]
        [Required]
        public int MangerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must Be Between 2 & 50 Character")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        public Department Department { get; set; }

        public Employee Employee { get; set; }

    }
}