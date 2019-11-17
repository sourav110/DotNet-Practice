using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using StudentRegistrationWebApp.Models;
using System.Data;

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
            string query = "INSERT INTO Student_tbl(StudentName, RegNo, Department, NoOfCourse, RegDate) VALUES(@StudentName, @RegNo, @Department, @NoOfCourse, @RegDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("StudentName", SqlDbType.VarChar);
            command.Parameters["StudentName"].Value = student.StudentName;

            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = student.RegNo;

            command.Parameters.Add("Department", SqlDbType.VarChar);
            command.Parameters["Department"].Value = student.Department;

            command.Parameters.Add("NoOfCourse", SqlDbType.Int);
            command.Parameters["NoOfCourse"].Value = student.NoOfCourse;

            command.Parameters.Add("RegDate", SqlDbType.Date);
            command.Parameters["RegDate"].Value = student.RegDate;

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
            string query = "SELECT StudentName, RegNo, NoOfCourse FROM Student_tbl WHERE Department = @Department";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("Department", SqlDbType.VarChar);
            command.Parameters["Department"].Value = student.Department;

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

        public List<Student> GetStudentsByDate(string fromDate, string toDate)
        {
            List<Student> studentsByDate = new List<Student>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT StudentName, RegNo, Department, NoOfCourse FROM Student_tbl WHERE RegDate BETWEEN @FromDate AND @ToDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("FromDate", SqlDbType.Date);
            command.Parameters["FromDate"].Value = fromDate;

            command.Parameters.Add("ToDate", SqlDbType.Date);
            command.Parameters["ToDate"].Value = toDate;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentName = reader["StudentName"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Department = reader["Department"].ToString();
                aStudent.NoOfCourse = Convert.ToInt32(reader["NoOfCourse"]);

                studentsByDate.Add(aStudent);
            }

            reader.Close();
            connection.Close();

            return studentsByDate;
        }
    }
}