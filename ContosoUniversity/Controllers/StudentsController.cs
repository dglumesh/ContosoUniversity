using ContosoUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Students
        public ActionResult Index()
        {

            return View(db.Students.ToList());
        }
      public ActionResult New()
        {
            return View("StudentForm");
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var student = db.Students.SingleOrDefault(m => m.StudentID == id);
            if (student == null)
                return HttpNotFound();

            return View();
        }
    }
}