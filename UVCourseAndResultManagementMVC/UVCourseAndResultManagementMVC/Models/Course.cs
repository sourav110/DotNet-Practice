using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UVCourseAndResultManagementMVC.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please enter course code")]
        [MinLength(5, ErrorMessage = "Code must be at least 5 character")]
        [Display(Name = "Code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter credit")]
        //[StringLength(5.0, ErrorMessage = "Credit must be in range of 0.5 to 5.0", MinimumLength = 0.5)]
        public float Credit { get; set; }

        public string Description { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}