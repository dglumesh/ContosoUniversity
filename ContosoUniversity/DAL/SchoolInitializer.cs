using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer: DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            //Objects from each model

            //Student List of Objects
            List<Student> studnetList= new List<Student> //var students = new List<Student>
            {
new Student{LastName="Umesh",FirstMidName="Lakshan",EnrollmentDate=DateTime.Parse("2005-09-03")},
new Student{LastName="Lahiru",FirstMidName="Malith",EnrollmentDate=DateTime.Parse("2002-03-03")},
new Student{LastName="Sampath",FirstMidName="Nalinda",EnrollmentDate=DateTime.Parse("2008-02-01")},
new Student{LastName="Wijesinghe",FirstMidName="Janith",EnrollmentDate=DateTime.Parse("2005-03-01")},
new Student{LastName="Madusanka",FirstMidName="Samira",EnrollmentDate=DateTime.Parse("2002-06-01")},
new Student{LastName="Weerasinghe",FirstMidName="Kamal",EnrollmentDate=DateTime.Parse("2006-03-06")},
new Student{LastName="Senadeera",FirstMidName="Kasun",EnrollmentDate=DateTime.Parse("2001-05-04")}
            };

            studnetList.ForEach(s => context.Students.Add(s)); //add data to object(temporary save in the RAM)context is in the RAM, LINQ query((s => context.Students.Add(s))
            context.SaveChanges(); //save data to database


            //Course List of Objects
            List<Course> courseList = new List<Course>
            {
new Course{CourseID=10,Title="MCSD",Credits=3},
new Course{CourseID=20,Title="CCNA",Credits=5},
new Course{CourseID=30,Title="CIMMA",Credits=1},
new Course{CourseID=40,Title="Msc",Credits=2},
new Course{CourseID=50,Title="MBA",Credits=4},
new Course{CourseID=60,Title="MsCS",Credits=1}

            };

            courseList.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            //Enrollments List of Objects
            List<Enrollment> enrollmentList = new List<Enrollment>
            {
new Enrollment{CourseID=10,StudentID=1,Grade=Grade.A},
new Enrollment{CourseID=20,StudentID=2,Grade=Grade.B},
new Enrollment{CourseID=60,StudentID=3,Grade=Grade.F},
new Enrollment{CourseID=20,StudentID=4,Grade=Grade.C},
new Enrollment{CourseID=30,StudentID=5},
new Enrollment{CourseID=10,StudentID=6,Grade=Grade.A},
new Enrollment{CourseID=40,StudentID=7,Grade=Grade.D}
            };

            enrollmentList.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
            //base.Seed(context);


        }
    }
}