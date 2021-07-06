using System;
using System.Collections.Generic;
using System.Linq;
using SP.Models;

namespace SP.Assignments
{
    class Week4
    {
        static void main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{AridNo="18-Arid-2091", FirstName="Kaleem", LastName="Ahmed", Gender = 'M', Discipline="BSCS", CGPA=3.52F, Age=21},
                new Student{AridNo="18-Arid-2045", FirstName="Saira", LastName="Bibi", Gender = 'F', Discipline="BSCS", CGPA=3.01F, Age=20},
                new Student{AridNo="18-Arid-2089", FirstName="Sarleem", LastName="Javeed", Gender = 'M', Discipline="BSCS", CGPA=2.80F, Age=22},
                new Student{AridNo="19-Arid-1009", FirstName="Sardar", LastName="Khalid", Gender = 'M', Discipline="MCS", CGPA=3.12F, Age=25},
                new Student{AridNo="19-Arid-1011", FirstName="maria", LastName="Safdar", Gender = 'F', Discipline="MCS", CGPA=3.90F, Age=24},
                new Student{AridNo="18-Arid-2035", FirstName="Sawair", LastName="Saleem", Gender = 'F', Discipline="BSCS", CGPA=2.71F, Age=19},
                new Student{AridNo="18-Arid-2045", FirstName="Aqsa", LastName="Ejaz", Gender = 'F', Discipline="BSCS", CGPA=3.41F, Age=23},
                new Student{AridNo="19-Arid-1209", FirstName="kamran", LastName="Kaleem", Gender = 'M', Discipline="MCS", CGPA=3.32F, Age=26},
                new Student{AridNo="19-Arid-1016", FirstName="Zeeshan", LastName="Zaheer", Gender = 'M', Discipline="MCS", CGPA=3.32F, Age=24}
            };

            /// Write down the LINQ method and print result for the following:
            // 1.1 Find and Print the Youngest Student Age
            Console.WriteLine("Youngest student age: {0}", students.Min(s => s.Age));
            // 1.2 Find and Print the Eldest Student Age
            Console.WriteLine("Eldest student age: {0}", students.Max(s => s.Age));
            // 1.3 Find the Average Age of Student
            Console.WriteLine("Average student age: {0}", students.Average(s => s.Age));
            // 1.4 Calculate the sum of ages of all students
            Console.WriteLine("Sum of student ages: {0}", students.Sum(s => s.Age));

            ///Use LINQ to the following:
            Console.WriteLine("\n---- Students From MCS ----");
            // 2.1 Find and Print all the students from MCS
            var MCS = students.Where(s => s.Discipline == "MCS");
            foreach (var mcs in MCS)
            {
                Console.WriteLine(mcs);
            }

            Console.WriteLine("\n---- MCS female students ----");
            // 2.2 Find and Print all MCS female students
            var MCSFemale = students.Where(s => s.Discipline == "MCS" && s.Gender == 'F');
            foreach (var mcsFemale in MCSFemale)
            {
                Console.WriteLine(mcsFemale);
            }

            Console.WriteLine("\n---- BSCS male students between age 20 - 25 ----");
            // 2.3 Find and Print all BSCS male students between age 20 - 25
            var Male = students.Where(s => s.Age > 20 && s.Age < 25 && s.Gender == 'M' && s.Discipline == "BSCS");
            foreach (var male in Male)
            {
                Console.WriteLine(male);
            }

            /// Convert following SQL to LINQ Method Syntax: 
            // 3.1 select * from Students order by CGPA, Age
            students.OrderBy(s => s.CGPA).ThenBy(s => s.Age);

            // 3.2 select * from Students order by CGPA desc, Age
            students.OrderByDescending(s => s.CGPA).ThenBy(s => s.Age);

            // 3.3 select * from Students order by CGPA desc, Age desc
            students.OrderByDescending(s => s.CGPA).ThenByDescending(s => s.Age);

            // 3.4 select * from Students order by Discipline, CGPA, Age
            students.OrderBy(s => s.Discipline).ThenBy(s => s.CGPA).ThenBy(s => s.Age);

            // 3.5 select * from Students order by Discipline, CGPA desc, Age asc
            students.OrderBy(s => s.Discipline).ThenByDescending(s => s.CGPA).ThenBy(s => s.Age);

            Console.ReadKey();
        }
    }
}
