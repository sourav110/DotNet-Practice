using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using StudentRegistrationWebApp.Models;
using StudentRegistrationWebApp.BLL;

namespace StudentRegistrationWebApp
{
    public partial class SearchByDepartmentUi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartmentDropDownList();
            }
        }

        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();

        private void BindDepartmentDropDownList()
        {
            departmentDropDownList.DataTextField = "DeptName";
            departmentDropDownList.DataValueField = "DeptId";
            departmentDropDownList.DataSource = departmentManager.GetDepartments();
            departmentDropDownList.DataBind();
        }

        public void ShowAllStudent()
        {
            List<Student> students = new List<Student>();
            students = studentManager.GetStudents();

            searchByDeptGridView.DataSource = students;
            searchByDeptGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            string deptName = departmentDropDownList.SelectedItem.ToString();
            student.Department = deptName;

            ShowAllStudentByDept(student);
        }

        public void ShowAllStudentByDept(Student student)
        {
            List<Student> studentsByDept = new List<Student>();
            studentsByDept = studentManager.GetStudentsByDept(student);

            searchByDeptGridView.DataSource = studentsByDept;
            searchByDeptGridView.DataBind();
        }
    }
}