using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRegistrationWebApp.Models;
using StudentRegistrationWebApp.BLL;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace StudentRegistrationWebApp
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ShowAllStudent();

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

            registrationGridView.DataSource = students;
            registrationGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string studentName = inputStudentName.Value;
            string regNo = inputRegNo.Value;
            string dept = departmentDropDownList.SelectedItem.ToString();
            int noOfCourse = Convert.ToInt32(inputNoOfCourses.Value);
            //string regDate = DateTime.Today.ToString();

            Student student = new Student(studentName, regNo, dept, noOfCourse);
            student.RegDate = DateTime.Today;

            string message = studentManager.SaveStudent(student);
            messageLabel.Text = message;

            if (message == "Added successfully")
            {
                messageLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                messageLabel.ForeColor = System.Drawing.Color.Red;
            }

            ShowAllStudent();

            ClearField();
        }

        private void ClearField()
        {
            inputStudentName.Value = String.Empty;
            inputRegNo.Value = String.Empty;
            inputNoOfCourses.Value = String.Empty;
        }

        protected void printReportButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}