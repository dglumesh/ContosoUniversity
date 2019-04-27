using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name ="Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name ="First Name")]
        [Required]
        public string FirstMidName { get; set; }

        [Display(Name ="Enrollment Date")]
        [Required]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } // icollection is a interface. and icollection represent a list.we does not need to create object in this situation
    }
}