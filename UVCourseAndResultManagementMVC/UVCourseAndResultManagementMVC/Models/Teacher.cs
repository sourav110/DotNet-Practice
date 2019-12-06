using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Services.Description;

namespace UVCourseAndResultManagementMVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please enter teacher name")]
        [Display(Name ="Name")]
        [StringLength(50)]
        public string TeacherName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage ="Please enter email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter contact no")]
        [Display(Name ="Contact No.")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name ="Credit to be taken")]
        [Required(ErrorMessage = "Please enter credit to be taken")]
        [Range(0,20)]
        public string CreditToBeTaken { get; set; }
    }
}