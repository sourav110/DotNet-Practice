using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UVCourseAndResultManagementMVC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter department code")]
        [DisplayName("Code")]
        [Column(TypeName = "varchar")]
        //[Index("Ix_DepartmentCode", Order = 1, IsUnique = true)]
        [StringLength(7, ErrorMessage = "Code must be 2 to 7 character long", MinimumLength = 2)]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please enter department name")]
        [DisplayName("Name")]
        [Column(TypeName = "varchar")]
        //[Index(IsUnique = true)]
        public string DepartmentName { get; set; }
    }
}