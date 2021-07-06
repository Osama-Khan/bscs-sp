using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Final
{
    class Q10
    {
        class Student
        {
            public int Reg { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Session { get; set; }
            public int Semester { get; set; }
        }
        public static void main(string[] args)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Reg", 1.GetType());
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Age", 1.GetType());
            dataTable.Columns.Add("Session");
            dataTable.Columns.Add("Semester", 1.GetType());
            dataTable.Rows.Add(new object[] { 0, "Ali", 19, "BD", 2 });
            dataTable.Rows.Add(new object[] { 1, "Bilal", 20, "ED", 3 });
            dataTable.Rows.Add(new object[] { 2, "Daniyal", 18, "CD", 1 });
            dataTable.Rows.Add(new object[] { 3, "Faiza", 20, "AD", 4 });


            /// SOLUTION
            var students = dataTable.AsEnumerable()
                .Select((d) => new Student {
                    Reg = d.Field<int>("Reg"),
                    Name = d.Field<string>("Name"),
                    Age = d.Field<int>("Age"),
                    Session = d.Field<string>("Session"),
                    Semester = d.Field<int>("Semester")
                }).ToList();

        }
    }
}
