using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationWebApp.Models;
using StudentRegistrationWebApp.DAL;

namespace StudentRegistrationWebApp.BLL
{
    
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public List<Department> GetDepartments()
        {
            return departmentGateway.GetDepartments();
        }
    }
}