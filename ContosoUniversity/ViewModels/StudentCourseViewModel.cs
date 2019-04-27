using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class StudentCourseViewModel
    {
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Course> Course { get; set; }
    }
}