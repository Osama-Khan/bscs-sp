using System;
using System.Collections.Generic;
using System.Linq;
using SP.Models;

namespace SP.AsstLabs
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

        override public string ToString()
        {
            return string.Format("Reg: {0}, Name: {1}, Dob: {2}, Gender: {3}", RegNo, Name, DOB.ToString(), Gender);
        }
    }

    class Lab9
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

        public static void Task(string[] args)
        {
            var q1 = students.Join(enrolments,
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

            var q2 = students.Join(enrolments,
                s => s.RegNo,
                e => e.RegNo,
                (s, e) => new
                {
                    s.Name,
                    e.Cid
                });

            var q3 = enrolments.Join(courses,
                e => e.Cid,
                c => c.Cid,
                (e, c) => new
                {
                    c.Name,
                    e.RegNo
                });

            var q4 = enrolments.Join(
                   courses,
                   e => e.Cid,
                   c => c.Cid,
                   (e, c) => new
                   {
                       c.Name,
                       e.RegNo
                   }
               ).Join(students,
                a => a.RegNo,
                s => s.RegNo,
                (a, s) => new
                {
                    cName = a.Name,
                    sName = s.Name
                });

            var q5 = courses.Join(enrolments,
                c => c.Cid,
                e => e.Cid,
                (c, e) => new
                {
                    e.Grade,
                    c.Name
                });
        }
    }
}
