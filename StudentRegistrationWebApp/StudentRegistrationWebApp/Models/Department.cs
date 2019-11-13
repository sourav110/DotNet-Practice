using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationWebApp.Models
{
    public class Department
    {
        public Department()
        {
        }

        public Department(string deptName)
        {
            DeptName = deptName;
        }

        public Department(int deptId, string deptName)
        {
            DeptId = deptId;
            DeptName = deptName;
        }

        public int DeptId { set; get; }
        public string DeptName { set; get; }

    }
}