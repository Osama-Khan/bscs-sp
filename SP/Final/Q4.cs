using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Final
{
    class Q4
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Student(int Id, string Name)
            {
                this.Id = Id;
                this.Name = Name;
            }
        }

        class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }

            public Course(int Id, string Title)
            {
                this.Id = Id;
                this.Title = Title;
            }
        }

        class Registration
        {
            public int SID { get; set; }
            public int CID { get; set; }

            public Registration(int SID, int CID)
            {
                this.SID = SID;
                this.CID = CID;
            }
        }

        public static void main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student(0, "Ali"),
                new Student(1, "Bilal"),
                new Student(2, "Junaid"),
                new Student(3, "Zohair")
            };
            List<Course> courses = new List<Course>()
            {
                new Course(0, "DDS"),
                new Course(1, "OOP"),
                new Course(2, "BA"),
                new Course(3, "CC"),
            };
            List<Registration> registrations = new List<Registration>() {
                new Registration(0, 0),
                new Registration(1, 0),
                new Registration(2, 0),
                new Registration(0, 1),
                new Registration(0, 2),
                new Registration(1, 2),
            };

            /// SOLUTION BEGINNING ///
            var q1 = students.Select(x => x.Name);
            foreach (var s in q1) Console.WriteLine(s);
            var q2 = courses.Select(x => x.Title);
            foreach (var c in q2) Console.WriteLine(c);
            var q3 = registrations.Join(
                students,
                r => r.SID,
                s => s.Id,
                (r, s) => new { r, s })
                .Join(
                courses,
                r => r.r.CID,
                c => c.Id,
                (r, c) => new { course = c, student = r.s });
            foreach(var p in q3)
            {
                Console.WriteLine("{0} has {1}", p.student.Name, p.course.Title);
            }

            var q4 = registrations.Join(
                students,
                r => true,
                s => true,
                (r, s) => new { r, s })
                .Join(
                courses,
                r => true,
                c => true,
                (r, c) => new { course = c, student = r.s }).Except(q3);
            foreach (var p in q4)
            {
                Console.WriteLine("{0} does not have {1}", p.student.Name, p.course.Title);
            }

            var q5 = courses.OrderByDescending((c) => c.Title).Select((c) => c.Title);
            foreach (var c in q5) Console.WriteLine(c);
        }
    }
}
