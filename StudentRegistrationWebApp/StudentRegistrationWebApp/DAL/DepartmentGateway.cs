using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using StudentRegistrationWebApp.Models;

namespace StudentRegistrationWebApp.DAL
{
    public class DepartmentGateway
    {
        public List<Department> GetDepartments()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["StudentRegDB"].ConnectionString;

            List<Department> departments = new List<Department>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM dept_tbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department();
                department.DeptId = Convert.ToInt32(reader["DeptId"]);
                department.DeptName = reader["DeptName"].ToString();

                departments.Add(department);
            }

            reader.Close();
            connection.Close();

            return departments;
        }
    }
}