using System;
using System.Collections.Generic;
using System.Linq;
using SP.Models;

namespace SP.Assignments
{
    class Week5
    {
        public static void main(string[] args)
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

            /// Apply LINQ to print the Highest and Lowest CGPA Student's detail without using Where
            var highest = students.Max(s => s.CGPA);
            var highestS = students.First(s => s.CGPA == highest);
            var lowest = students.Min(s => s.CGPA);
            var lowestS = students.First(s => s.CGPA == lowest);
            Console.WriteLine("Highest CGPA Student:\n{0}", highestS);
            Console.WriteLine("Lowest CGPA Student:\n{0}", lowestS);

            /// Print the total number of students having the same highest and Lowest CGPA
            var countHighest = students.Count(s => s.CGPA == highest);
            var countLowest = students.Count(s => s.CGPA == lowest);
            Console.WriteLine("Number of students with highest CGPA: {0}", countHighest);
            Console.WriteLine("Number of students with lowest CGPA: {0}", countLowest);

            /// Rewrite the query 3.4 with Alias Names for the selected columns
            var query3_4 = students.Where(s => s.Gender == 'M')
                .Select(s => new { aridNum = s.AridNo, disc = s.Discipline, age = s.Age })
                .OrderBy(v => v.age);
            foreach (var detail in query3_4)
            {
                Console.WriteLine(detail);
            }

            /// Sort the entire list by Age and then only select the AridNo, FirstName, Gender and Age
            var list = students.OrderBy(s => s.Age)
                .Select(s => new { s.AridNo, s.FirstName, s.Gender, s.Age });
            foreach (var el in list)
            {
                Console.WriteLine(el);
            }

            Console.ReadKey();
        }
    }
}
