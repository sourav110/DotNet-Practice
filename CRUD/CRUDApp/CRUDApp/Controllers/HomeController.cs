using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDApp.Models;

namespace CRUDApp.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(Student student)
        {

            Student st = new Student();

            if (ModelState.IsValid)
            {
                st.Name = student.Name;
                st.Address = student.Address;

                db.Students.Add(student);
                db.SaveChanges();
            }

            return Json(true);
        }


        public JsonResult SaveStudent(Student student)
        {

            Student st = new Student();

            if (ModelState.IsValid)
            {
                st.Name = student.Name;
                st.Address = student.Address;

                db.Students.Add(student);
                db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }





        public JsonResult GetData()
        {
            var data = db.Employees.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult PostData(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        public JsonResult PostData(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Address = employee.Address;
                emp.Country = employee.Country;
                emp.Pin = employee.Pin;

                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            //var id = db.Employees.FirstOrDefault(m => m.Id == id);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

























        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}