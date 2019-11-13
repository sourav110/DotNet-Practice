using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationWebApp.Models
{
    public class Student
    {
        public Student(string studentName, string regNo, string department, int noOfCourse)
        {
            StudentName = studentName;
            RegNo = regNo;
            Department = department;
            NoOfCourse = noOfCourse;
        }

        public Student(string studentName, string regNo, string department, int noOfCourse, DateTime regDate) : this(studentName, regNo, department, noOfCourse)
        {
            RegDate = regDate;
        }

        public Student(int studentId, string studentName, string regNo, string department, int noOfCourse, DateTime regDate)
        {
            StudentId = studentId;
            StudentName = studentName;
            RegNo = regNo;
            Department = department;
            NoOfCourse = noOfCourse;
            RegDate = regDate;
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RegNo { get; set; }
        public string Department { get; set; }
        public int NoOfCourse { get; set; }
        public DateTime RegDate { get; set; }
    }
}