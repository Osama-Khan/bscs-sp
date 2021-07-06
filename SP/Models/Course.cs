using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Models
{
    class Course
    {
        public int Cid { get; set; }
        public string Name { get; set; }

        public Course(int cid, string name)
        {
            Cid = cid;
            Name = name;
        }
    }
}
