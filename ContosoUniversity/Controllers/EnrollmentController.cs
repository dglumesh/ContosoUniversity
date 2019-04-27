using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Enrollment
        public ActionResult Index()
        {
            return View(db.Enrollments.ToList());
        }
        public ActionResult New()
        {
            var course = db.Courses.ToList();
            var student = db.Students.ToList();
            var viewModel = new StudentCourseViewModel
            {
                Course = course,
                Student =student

            };
        

            return View("EnrollmentForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Student student,Course course)
        {
            db.Students.Add(student);
            db.SaveChanges();

            db.Courses.Add(course);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}