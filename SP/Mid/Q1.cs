using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Mid
{
    class Student
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }

        public Student(string regNo, string name, DateTime dOB, char gender)
        {
            RegNo = regNo;
            Name = name;
            DOB = dOB;
            Gender = gender;
        }
    }

    class Course
    {
        public int Cid { get; set; }
        public string Name { get; set; }

        public Course(int cid, string name)
        {
            Cid = cid;
            Name = name;
        }
    }

    class Enrolment
    {
        public string RegNo { get; set; }
        public int Cid { get; set; }
        public float Grade { get; set; }

        public Enrolment(string regNo, int cid, float grade)
        {
            RegNo = regNo;
            Cid = cid;
            Grade = grade;
        }
    }

    class Q1
    {
        static List<Student> students = new List<Student>()
        {
            new Student("131", "Ali", new DateTime(2001, 10, 30), 'M'),
            new Student("132", "Ayesha", new DateTime(1999, 1, 3), 'F'),
            new Student("133", "Bilal", new DateTime(1999, 1, 3), 'M'),
            new Student("134", "Maryam", new DateTime(1999, 1, 3), 'F'),
        };
        static List<Enrolment> enrolments = new List<Enrolment>()
        {
            new Enrolment("131", 0, 3.2f),
            new Enrolment("131", 3, 3.9f),
            new Enrolment("131", 2, 1.9f),
            new Enrolment("132", 0, 2.2f),
            new Enrolment("132", 1, 4.0f),
            new Enrolment("133", 0, 2.0f),
            new Enrolment("134", 0, 3.1f),
        };
        static List<Course> courses = new List<Course>()
        {
            new Course(0, "OOP"),
            new Course(1, "MPL"),
            new Course(2, "MVC"),
            new Course(3, "PF"),
        };

        public static void PartA(string[] args)
        {
            var res = students.Join(enrolments,
                s => s.RegNo,
                e => e.RegNo,
                (s, e) => new
                {
                    s,
                    e
                })
            .Join(
                courses,
                x => x.e.Cid,
                c => c.Cid,
                (e, c) => new
                {
                    e.s.RegNo,
                    e.s.Name,
                    CourseName = c.Name,
                    e.s.DOB,
                    e.s.Gender
                }
            );
            Console.WriteLine("Student Details: ");
            foreach (var r in res)
            {
                Console.WriteLine("RegNo: {0}, Name: {1}, Course: {2}, DOB: {3}, Gender: {4}",
                    r.RegNo, r.Name, r.CourseName, r.DOB, r.Gender == 'M' ? "Male" : "Female");
                Console.WriteLine("------------------");
            }
        }

        public static void PartB(string[] args) {
            var stds = students.Join(enrolments,
                s => s.RegNo,
                e => e.RegNo,
                (s, e) => new
                {
                    s,
                    e
                })
            .Join(
                courses,
                x => x.e.Cid,
                c => c.Cid,
                (e, c) => new
                {
                    e.s.RegNo,
                    e.s.Name,
                    CourseName = c.Name,
                    e.s.DOB,
                    e.s.Gender,
                    e.e.Grade
                }
            );

            var res = stds.OrderBy(s => s.CourseName)
                .GroupBy(s => s.CourseName);
            Console.WriteLine("Student Course Groups:");
            foreach (var r in res)
            {
                Console.WriteLine("------ Course: {0} ------", r.Key);
                var top3 = r.OrderByDescending(s => s.Grade).Take(3);
                foreach(var s in top3)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
