using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using StudentRegistrationWebApp.Models;

namespace StudentRegistrationWebApp.DAL
{
    public class StudentGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentRegDB"].ConnectionString;

        public bool IsExistStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student_tbl WHERE RegNo = '"+student.RegNo+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Student aStudent = null;
            while (reader.Read())
            {
                aStudent = new Student();

                aStudent.StudentId = Convert.ToInt32(reader["StudentId"]);
                aStudent.StudentName = reader["StudentName"].ToString();
                aStudent.Department = reader["Department"].ToString();
                aStudent.NoOfCourse = Convert.ToInt32(reader["NoOfCourse"]);
            }

            reader.Close();
            connection.Close();

            if(aStudent != null)
            {
                return true;
            }
            
            return false;
        }

        public bool SaveStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Student_tbl(StudentName, RegNo, Department, NoOfCourse, RegDate) VALUES('"+student.StudentName+"', '"+student.RegNo+"', '"+student.Department+"', "+student.NoOfCourse+" ,'"+student.RegDate+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffect = command.ExecuteNonQuery();
            connection.Close();

            if(rowEffect > 0)
            {
                return true;
            }

            return false;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentName = reader["StudentName"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Department = reader["Department"].ToString();
                aStudent.NoOfCourse = Convert.ToInt32(reader["NoOfCourse"]);

                students.Add(aStudent);
            }

            reader.Close();
            connection.Close();

            return students;
        }

        public List<Student> GetStudentsByDept(Student student)
        {
            List<Student> studentsByDept = new List<Student>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT StudentName, RegNo, NoOfCourse FROM Student_tbl WHERE Department = '"+student.Department+"' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentName = reader["StudentName"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.NoOfCourse = Convert.ToInt32(reader["NoOfCourse"]);

                studentsByDept.Add(aStudent);
            }

            reader.Close();
            connection.Close();

            return studentsByDept;
        }
    }
}