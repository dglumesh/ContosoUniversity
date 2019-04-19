using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{

    public enum Grade
    {
        A, B, C, D, F //enum for assign value
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; } // ?=user for it can be null. nullable

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }


    }
}