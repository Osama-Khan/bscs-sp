using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SP.Final
{
    class Q9
    {
        static void Print(XElement c)
        {
            Console.WriteLine("Title: {0} | Artist: {1} | Country: {2} | Company: {3} | Price: {4} | Year: {5}",
                    c.Element("Title").Value,
                    c.Element("Artist").Value,
                    c.Element("Country").Value,
                    c.Element("Company").Value,
                    c.Element("Price").Value,
                    c.Element("Year").Value);
        }

        public static void main(string[] args)
        {
            var catalog = XElement.Load("D:\\catalog.xml").Elements();
            // Part A
            var q1 = catalog.OrderBy(c => c.Element("Price").Value);
            foreach (var c in q1)
                Print(c);
            // Part B
            var thisYear = DateTime.Now.Year;
            var q2 = catalog.Where(c => int.Parse(c.Element("Year").Value) + 5 >= thisYear);
            foreach (var c in q2)
            {
                Print(c);
            }

            // Part C
            var q3 = catalog.Select(c => new
            {
                Title = c.Element("Title").Value,
                Price = c.Element("Price").Value,
                Year = c.Element("Year").Value
            }).OrderByDescending(c => c.Year);
            foreach (var c in q3)
            {
                Console.WriteLine("Title: {0} | Price: {1} | Year: {2}", c.Title, c.Price, c.Year);
            }

            // Part D
            var q4Oldest = catalog.Min(c => c.Element("Year").Value);
            Print(catalog.First(c => c.Element("Year").Value == q4Oldest));
            var q4Newest = catalog.Max(c => c.Element("Year").Value);
            Print(catalog.First(c => c.Element("Year").Value == q4Newest));
        }
    }
}

