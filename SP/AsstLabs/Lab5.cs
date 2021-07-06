using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.AsstLabs
{
    class Lab5
    {
        class Student
        {
            public string name { get; set; }
            public string dob { get; set; }
            public char gender { get; set; }
            public string city { get; set; }
        }
        public static void main(string[] args)
        {
            Dictionary<string, Student> sDict = new Dictionary<string, Student>();
            sDict.Add("2018-ARID-0139", new Student()
            {
                name = "Osama Khan",
                dob = "1/1/2000",
                gender = 'M',
                city = "Rawalpindi"
            });
            sDict.Add("2016-ARID-0138", new Student()
            {
                name = "Ali",
                dob = "1/1/1998",
                gender = 'M',
                city = "Islamabad"
            });
            sDict.Add("2014-ARID-0137", new Student()
            {
                name = "Nouman",
                dob = "1/1/1996",
                gender = 'M',
                city = "Taxila"
            });

            Console.WriteLine("---Student Details---");
            foreach(var s in sDict)
            {
                Console.WriteLine("\nArid#: {0}, Name: {1}, Gender: {2}", 
                    s.Key, s.Value.name, s.Value.gender);
            }
        }
    }
}
