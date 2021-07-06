using SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SP.AsstLabs
{
    class Lab8
    {
        // 2018-ARID-0139
        public static void Task(string[] args)
        {
            var employees = new List<Employee> {
                new Employee{ Name="Osama Khan", Department="IT", Salary=70000, Gender="Male" , City="Rawalpindi"},
                new Employee{ Name="Aysha", Department="Marketing", Salary=55000, Gender="Female" , City="Karachi"},
                new Employee{ Name="Ali", Department="IT", Salary=40000, Gender="Male" , City="Rawalpindi"},
                new Employee{ Name="Sana", Department="Admin", Salary=70000,Gender="Female" , City="Islamabad"},
                new Employee{ Name="Khalid", Department="IT", Salary=77000,Gender="Male" , City="Rawalpindi"},
                new Employee{ Name="Zainab", Department="Marketing", Salary=50000,Gender="Female" , City="Karachi"},
                new Employee{ Name="Saman", Department="Admin", Salary=35000,Gender="Female" , City="Karachi"},
                new Employee{ Name="Sohail", Department="IT", Salary=90000,Gender="Male" , City="Islamabad"},
                new Employee{ Name="Nasir", Department="Admin", Salary=25000,Gender="Male" , City="Rawalpindi"},
            };

            var single = employees.Single(emp => emp.Name == "Osama Khan");
            Console.WriteLine("Single\n Name: {0}, Department: {1}", single.Name, single.Department);
            var singleOrDef = employees.SingleOrDefault(emp => emp.Name == "Osama Khan");
            Console.WriteLine("\nSingleOrDefault\n Name: {0}, Department: {1}", singleOrDef.Name, singleOrDef.Department);

            var first = employees.First(emp => emp.Name == "Osama Khan");
            Console.WriteLine("\nFirst\n Name: {0}, Department: {1}", first.Name, first.Department);
            var firstOrDef = employees.FirstOrDefault(emp => emp.Name == "Osama Khan");
            Console.WriteLine("\nFirstOrDefault\n Name: {0}, Department: {1}", firstOrDef.Name, firstOrDef.Department);

            var last = employees.Last(emp => emp.Name == "Osama Khan");
            Console.WriteLine("\nLast\n Name: {0}, Department: {1}", last.Name, last.Department);
            var lastOrDef = employees.LastOrDefault(emp => emp.Name == "Osama Khan");
            Console.WriteLine("\nLastOrDefault\n Name: {0}, Department: {1}", lastOrDef.Name, lastOrDef.Department);

            var empFull = employees.Select(x => x);
            Console.WriteLine("\nEmployee Full Select");
            foreach (var e in empFull)
            {
                Console.WriteLine("Name: {0}, City: {1}, Gender: {2}", e.Name, e.City, e.Gender);
            }

            var empPartial = employees.Select(x => new { x.Name, x.City });
            Console.WriteLine("\nEmployee Partial Select");
            foreach (var e in empPartial)
            {
                Console.WriteLine(e);
            }

            var empPartialAlias = employees.Select(x => new { n = x.Name, c = x.City });
            Console.WriteLine("\nEmployee Partial Select with Alias");
            foreach (var e in empPartialAlias)
            {
                Console.WriteLine(e);
            }

            var empName = employees.Select(x => x.Name);
            Console.WriteLine("\nEmployee Name Select");
            foreach (var e in empName)
            {
                Console.WriteLine(e);
            }

            var empMultipleSelection = employees.Select(x => new { x.Name, x.Salary }).Select(n => n.Salary);
            Console.WriteLine("\nEmployee Multiple Select");
            foreach (var e in empMultipleSelection)
            {
                Console.WriteLine(e);
            }

            var empIndexed = employees.Select((x, index) => new { ID = index, x.Name });
            Console.WriteLine("\nEmployee Indexed Select");
            foreach (var e in empIndexed)
            {
                Console.WriteLine(e);
            }
        }
    }
}
