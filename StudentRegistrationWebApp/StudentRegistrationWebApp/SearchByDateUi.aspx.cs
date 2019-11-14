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
    public partial class SearchByDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        StudentManager studentManager = new StudentManager();
        Student student = new Student();

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Value;
            string toDate = toDateTextBox.Value;

            DateTime aDate = Convert.ToDateTime(fromDate);
            DateTime bDate = Convert.ToDateTime(toDate);

            int validation = DateTime.Compare(aDate, bDate);
            if(validation > 0)
            {
                messageLabel.Text = "Date is not correct.";
                messageLabel.ForeColor = Color.Red;
                searchByDateGridView.Visible = false;
            }

            SearchAllStudentByDate(fromDate, toDate);
        }

        public void SearchAllStudentByDate(string fromDate, string toDate)
        {
            List<Student> studentsByDate = new List<Student>();
            studentsByDate = studentManager.GetStudentsByDate(fromDate, toDate);

            searchByDateGridView.DataSource = studentsByDate;
            searchByDateGridView.DataBind();
        }
    }
}