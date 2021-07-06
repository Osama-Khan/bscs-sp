using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SP.AsstLabs
{
    class Lab13
    {
        static string empPath = "../../Assignments/Data/Employees.xml";
        public static void main(string[] args)
        {
            var empXml = XElement.Load(empPath).Elements("Employee");

            Console.WriteLine("---- Number of Employees ----");
            var q1 = empXml.Count();
            Console.WriteLine(q1);

            Console.WriteLine("\n---- Sum of Employee Salaries ----");
            var q2 = empXml.Sum((e) => int.Parse(e.Element("Salary").Value));
            Console.WriteLine(q2);

            Console.WriteLine("\n---- Minimum Salary ----");
            var q3 = empXml.Min((e) => int.Parse(e.Element("Salary").Value));
            Console.WriteLine(q3);

            Console.WriteLine("\n---- Maximum Salary ----");
            var q4 = empXml.Max((e) => int.Parse(e.Element("Salary").Value));
            Console.WriteLine(q4);

            Console.WriteLine("\n---- Average Salary ----");
            var q5 = empXml.Average((e) => int.Parse(e.Element("Salary").Value));
            Console.WriteLine(q5);
        }
    }
}
