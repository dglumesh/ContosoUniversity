using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Enrollment
        public ActionResult Index()
        {
            
            var enrollment = db.Enrollments.Include(e => e.Course).Include(e =>e.Student);
            return View(enrollment.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");
         


            return View();
        }
        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
            db.SaveChanges();

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", enrollment.StudentID);

            return RedirectToAction("Index");
        }
       public ActionResult Edit(int? id)
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");

            Enrollment enrollment = db.Enrollments.Find(id);

            return View(enrollment);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Enrollment enrollment)
        {
            db.Entry(enrollment).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}