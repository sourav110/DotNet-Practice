using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationWebApp.Models;
using StudentRegistrationWebApp.DAL;

namespace StudentRegistrationWebApp.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public string SaveStudent(Student student)
        {
            bool isExisted = studentGateway.IsExistStudent(student);
            if (isExisted)
            {
                return "Student Already Exists";
            }
            else
            {
                bool isSaved = studentGateway.SaveStudent(student);
                if (isSaved)
                {
                    return "Added successfully";
                }
                else
                {
                    return "Failed to save.";
                }
            }
        }

        public List<Student> GetStudents()
        {
            return studentGateway.GetStudents(); 
        }

        public List<Student> GetStudentsByDept(Student student)
        {
            return studentGateway.GetStudentsByDept(student);
        }

        public List<Student> GetStudentsByDate(string fromDate, string toDate)
        {
            return studentGateway.GetStudentsByDate(fromDate, toDate);
        }
    }
}