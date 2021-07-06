using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Models
{
    class Enrolment
    {
        public string RegNo { get; set; }
    public int Cid { get; set; }
    public float Grade { get; set; }

    public Enrolment(string regNo, int cid, float grade)
    {
        RegNo = regNo;
        Cid = cid;
        Grade = grade;
    }
}
}
