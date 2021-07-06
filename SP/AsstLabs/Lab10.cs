using System;
using System.Collections.Generic;
using System.Linq;

namespace SP.AsstLabs
{
    class Lab10
    {
        public static void main(string[] args)
        {
            List<Student> students = new List<Student>() {
                new Student("131", "Ali", new DateTime(2001, 10, 30), 'M'),
                new Student("132", "Ayesha", new DateTime(1999, 1, 3), 'F'),
                new Student("133", "Bilal", new DateTime(1999, 1, 3), 'M'),
                new Student("134", "Maryam", new DateTime(1999, 1, 3), 'F'),
            };
            /// Students named Ali
            Console.WriteLine("\n-------Students named Ali--------");
            var q1 = students.Where((s) => s.Name == "Ali");
            foreach (var s in q1)
            {
                Console.WriteLine(s);
            }
            /// Male students with name starting with 'A'
            Console.WriteLine("\n-------Male students with name starting with 'A'--------");
            var q2 = students.Where((s) => s.Gender == 'M' && s.Name.StartsWith("A"));
            foreach (var s in q2)
            {
                Console.WriteLine(s);
            }
            /// Female students with output
            Console.WriteLine("\n-------Female students with output--------");
            var q3 = students.Where((s) =>
            {
                Console.WriteLine("Found Female Student: {0}", s.Name);
                return s.Gender == 'F';
            });
            /// Students with only Name and Gender columns
            Console.WriteLine("\n-------Students with only Name and Gender columns--------");
            var q4 = students.Select((s) => new { s.Name, s.Gender });
            foreach (var s in q4)
            {
                Console.WriteLine(s);
            }
            /// Male Students with only Name column
            Console.WriteLine("\n-------Male Students with only Name column--------");
            var q5 = students.Where((s) => s.Gender == 'M').Select((s) => s.Name);
            foreach (var s in q5)
            {
                Console.WriteLine(s);
            }
            /// Female Students with only Date of Birth column
            Console.WriteLine("\n-------Female Students with only Date of Birth column--------");
            var q6 = students.Where((s) => s.Gender == 'F').Select((s) => s.DOB);
            foreach (var s in q6)
            {
                Console.WriteLine(s);
            }
            /// Students ordered by youngest first
            Console.WriteLine("\n-------Students ordered by youngest first--------");
            var q7 = students.OrderBy((s) => s.DOB);
            foreach (var s in q7)
            {
                Console.WriteLine(s);
            }

            /// STudents ordered by eldest first
            Console.WriteLine("\n-------STudents ordered by eldest first--------");
            var q8 = students.OrderByDescending((s) => s.DOB);
            foreach (var s in q8)
            {
                Console.WriteLine(s);
            }
            /// Students ordered by regNo
            Console.WriteLine("\n-------Students ordered by regNo--------");
            var q9 = students.OrderBy((s) => s.RegNo);
            foreach (var s in q9)
            {
                Console.WriteLine(s);
            }
            /// Students Grouped by Gender
            Console.WriteLine("\n-------Students Grouped by Gender--------");
            var q10 = students.GroupBy((s) => s.Gender);
            foreach (var d in q10)
            {
                Console.WriteLine("Students with Gender: {0}", d.Key);
                foreach (var v in d)
                {
                    Console.WriteLine(v);
                }
            }
        }
    }
}

