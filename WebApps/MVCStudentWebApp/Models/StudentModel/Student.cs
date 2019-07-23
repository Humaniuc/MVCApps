using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCStudentWebApp.Models.StudentModel
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name="Name")]
        [Required]
        public string StudentName { get; set; }

        [Range(5, 50)]
        public int Age { get; set; }

        [Display(Name = "Boboc?")]
        public bool isNewlyEnrolled { get; set; }
        public string Password { get; set; }
    }
}