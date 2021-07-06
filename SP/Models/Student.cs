using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Models
{
    class Student
    {
        public string AridNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Discipline { get; set; }
        public float CGPA { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Arid Num: {0}\nName: {1}\nGender: {2}\nAge {3}",
                AridNo, FirstName + " " + LastName, Gender, Age);
        }
    }
}
