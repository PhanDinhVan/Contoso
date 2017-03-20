namespace ContosoUniversity.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var students = new List<Student>
            {
                new Student { FirstMidName = "Dinh Van", LastName = "Phan", EnrollmentDate = DateTime.Parse("2017-03-16") },
                new Student { FirstMidName = "Thi Thu", LastName = "Phan", EnrollmentDate = DateTime.Parse("2017-03-16") },
                new Student { FirstMidName = "Dinh Vu", LastName = "Phan", EnrollmentDate = DateTime.Parse("2017-02-15") },
                new Student { FirstMidName = "Quynh Nhu", LastName = "Phan Thi", EnrollmentDate = DateTime.Parse("2011-01-10") },
                new Student { FirstMidName = "Song Ngan", LastName = "Tran Ngoc", EnrollmentDate = DateTime.Parse("2010-06-20") },
                new Student { FirstMidName = "Thi My", LastName = "Nguyen", EnrollmentDate = DateTime.Parse("2012-04-12") },
                new Student { FirstMidName = "Quang Sang", LastName = "Nguyen", EnrollmentDate = DateTime.Parse("2014-08-09") },
                new Student { FirstMidName = "Nhat Nam", LastName = "Dinh Tran", EnrollmentDate = DateTime.Parse("2015-11-10") },
                new Student { FirstMidName = "Quang Khai", LastName = "Le", EnrollmentDate = DateTime.Parse("2011-12-09") },
                new Student { FirstMidName = "Thanh Viet", LastName = "Nguyen", EnrollmentDate = DateTime.Parse("2013-01-02") }
            };

            foreach(Student e in students)
            {
                var studentInDB = context.Students.Where(
                    s => s.FirstMidName == e.FirstMidName &&
                    s.LastName == e.LastName &&
                    s.EnrollmentDate == e.EnrollmentDate).SingleOrDefault();
                if(studentInDB == null)
                {
                    context.Students.Add(e);
                }
            }
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = "3" },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = "3", },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = "3", },
                new Course { CourseID = 1045, Title = "Calculus", Credits = "4", },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = "4", },
                new Course { CourseID = 2021, Title = "Composition", Credits = "3", },
                new Course { CourseID = 2042, Title = "Literature", Credits = "4", }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var instructor = new List<Instructor>
            {
                new Instructor {ID = 1, LastName = "Phan", FirstMidName = "Dinh Van", HireDate = DateTime.Parse("2010-11-12") },
                new Instructor {ID = 2, LastName = "Phan", FirstMidName = "Dinh Vu", HireDate = DateTime.Parse("2011-10-15") },
                new Instructor {ID = 3, LastName = "Phan", FirstMidName = "Thi Thu", HireDate = DateTime.Parse("2012-2-10") },
                new Instructor {ID = 4, LastName = "Phan Thi", FirstMidName = "Quynh Nhu", HireDate = DateTime.Parse("2013-11-4") },
                new Instructor {ID = 5, LastName = "Tran Ngoc", FirstMidName = "Song Ngan", HireDate = DateTime.Parse("2014-7-17") },
                new Instructor {ID = 6, LastName = "Dinh Tran", FirstMidName = "Nhat Nam", HireDate = DateTime.Parse("2015-10-2") },
                new Instructor {ID = 7, LastName = "Nguyen", FirstMidName = "Thanh Viet", HireDate = DateTime.Parse("2016-1-12") },
                new Instructor {ID = 8, LastName = "Nguyen", FirstMidName = "Thi My", HireDate = DateTime.Parse("2017-8-1") },
                new Instructor {ID = 9, LastName = "Nguyen", FirstMidName = "Quang Sang", HireDate = DateTime.Parse("2009-4-1") }
            };
            instructor.ForEach(s => context.Instructor.AddOrUpdate(p => p.FirstMidName, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Dinh Van").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.A
                },
                new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Thi Thu").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Dinh Vu").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.FirstMidName == "Quynh Nhu").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.FirstMidName == "Song Ngan").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Thi My").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Song Ngan").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Quang Sang").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                 },
                new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Quang Khai").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Nhat Nam").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.FirstMidName == "Thanh Viet").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                 }
            };

            foreach(Enrollment e in enrollments)
            {
                var enrollmentDataBase = context.Enrollments.Where(
                    s =>
                    s.Student.ID == e.StudentID &&
                    s.Course.CourseID == e.CourseID).SingleOrDefault();
                if(enrollmentDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
