using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SP.Mid
{
    class Q3
    {
        static IEnumerable<XElement> GetResults()
        {
            var x = XElement.Load("../../Mid/Data/Result.xml").Elements("Result");
            return x;
        }

        public static void PartA(string[] args)
        {
            var res = GetResults().OrderBy(r => r.Element("Grade").Value);
            var grpExc = res.Where(r => float.Parse(r.Element("Grade").Value) > 3.5f);
            var highestInExc = grpExc.Max(r => float.Parse(r.Element("Grade").Value));
            var lowestInExc = grpExc.Min(r => float.Parse(r.Element("Grade").Value));

            var grpGd = res.Where(r => {
                var grd = float.Parse(r.Element("Grade").Value);
                return grd > 3.0f && grd <= 3.5f;
            });
            var highestInGd = grpGd.Max(r => float.Parse(r.Element("Grade").Value));
            var lowestInGd = grpGd.Min(r => float.Parse(r.Element("Grade").Value));

            var grpAvg = res.Where(r => {
                var grd = float.Parse(r.Element("Grade").Value);
                return grd > 2.5f && grd <= 3.0f;
            });
            var highestInAvg = grpAvg.Max(r => float.Parse(r.Element("Grade").Value));
            var lowestInAvg = grpAvg.Min(r => float.Parse(r.Element("Grade").Value));

            var grpPoor = res.Where(r => float.Parse(r.Element("Grade").Value) <= 2.5f);
            var highestInPoor = grpPoor.Max(r => float.Parse(r.Element("Grade").Value));
            var lowestInPoor = grpPoor.Min(r => float.Parse(r.Element("Grade").Value));

            Console.WriteLine("-------Excellent Grades:-------\n Highest: {0} \nLowest: {1}", highestInExc, lowestInExc);
            foreach (var g in grpExc)
            {
                Console.WriteLine("Reg: {0}, Grade: {1}", g.Element("RegNo").Value, g.Element("Grade").Value);
            }

            Console.WriteLine("-------Good Grades:------- \nHighest: {0} \nLowest: {1}", highestInGd, lowestInGd);
            foreach (var g in grpGd)
            {
                Console.WriteLine("Reg: {0}, Grade: {1}", g.Element("RegNo").Value, g.Element("Grade").Value);
            }

            Console.WriteLine("-------Average Grades:------- \nHighest: {0} \nLowest: {1}", highestInAvg, lowestInAvg);
            foreach (var g in grpAvg)
            {
                Console.WriteLine("Reg: {0}, Grade: {1}", g.Element("RegNo").Value, g.Element("Grade").Value);
            }

            Console.WriteLine("-------Poor Grades:------- \nHighest: {0} \nLowest: {1}", highestInPoor, lowestInPoor);
            foreach (var g in grpPoor)
            {
                Console.WriteLine("Reg: {0}, Grade: {1}", g.Element("RegNo").Value, g.Element("Grade").Value);
            }
        }

        class Result
        {
            public string RegNo { get; set; }
            public string Gender { get; set; }
            public float Grade { get; set; }
        }

        public static void PartB(string[] args)
        {
            var res = GetResults().OrderBy(r => r.Element("Grade").Value);
            var results = res.Select(r => new Result() {
                RegNo = r.Element("RegNo").Value,
                Gender = r.Element("Gender").Value,
                Grade = float.Parse(r.Element("Grade").Value)
            });
            foreach( var r in results)
            {
                Console.WriteLine("reg: {0}, gend: {1}, grd: {2}", r.RegNo, r.Gender, r.Grade);
            }
        }
    }
}
